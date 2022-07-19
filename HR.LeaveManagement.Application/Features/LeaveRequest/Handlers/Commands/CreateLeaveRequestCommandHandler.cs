using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private ILeaveRequestRepository _leaveRequestRepository;
        private IMapper _mapper;
        private ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
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

            return response;
        }
    }
}
