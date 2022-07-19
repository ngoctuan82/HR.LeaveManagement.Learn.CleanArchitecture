using AutoMapper;
using HR.LeaveManagement.Application.DTOs;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeaveRequestDetailRequestHandler : IRequestHandler<GetLeaveRequestDetailRequest, LeaveRequestDto>
    {
        private ILeaveRequestRepository _LeaveRequestRepository;
        private IMapper _mapper;

        public GetLeaveRequestDetailRequestHandler(ILeaveRequestRepository LeaveRequestRepository, IMapper mapper)
        {
            _LeaveRequestRepository = LeaveRequestRepository;
            _mapper = mapper;
        }

        async Task<LeaveRequestDto> IRequestHandler<GetLeaveRequestDetailRequest, LeaveRequestDto>.Handle(GetLeaveRequestDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _LeaveRequestRepository.GetLeaveRequestWithDetails(request.Id);
            return _mapper.Map<LeaveRequestDto>(leaveAllocation);
        }
    }
}
