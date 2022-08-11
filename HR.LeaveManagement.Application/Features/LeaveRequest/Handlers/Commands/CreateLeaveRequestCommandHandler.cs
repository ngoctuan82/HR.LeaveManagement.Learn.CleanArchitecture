using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validators;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Models;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private ILeaveRequestRepository _leaveRequestRepository;
        private IMapper _mapper;
        private ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmailSender emailSender;

        public CreateLeaveRequestCommandHandler(
            ILeaveRequestRepository leaveRequestRepository,
            ILeaveTypeRepository leaveTypeRepository,
            IEmailSender emailSender,
            IMapper mapper
            )
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            this.emailSender = emailSender;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveRequestDTOValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);

            // Validation
            if (!validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }

            // Process
            var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);
            
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

            // Response section
            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = leaveRequest.Id;

            // send Email
            await SendEmailAsync(request);

            return response;
        }

        private async Task SendEmailAsync(CreateLeaveRequestCommand request)
        {
            var email = new Email
            {
                To = "employee@org.com",
                Body = $"Your leave request fro {request.LeaveRequestDto.StartDate} to {request.LeaveRequestDto.EndDate}" +
                        $"has been submitted successfully.",
                Subject = "Leave Request Submitted"
            };

            try
            {
                await emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {
                //log error, dont throw
            }
        }

    }
}
