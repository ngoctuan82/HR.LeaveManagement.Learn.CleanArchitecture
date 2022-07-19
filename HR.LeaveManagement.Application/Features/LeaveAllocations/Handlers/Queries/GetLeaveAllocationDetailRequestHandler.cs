using AutoMapper;
using HR.LeaveManagement.Application.DTOs;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationDetailRequestHandler : IRequestHandler<GetLeaveAllocationDetailRequest, LeaveAllocationDto>
    {
        private ILeaveAllocationRepository _LeaveAllocationRepository;
        private IMapper _mapper;

        public GetLeaveAllocationDetailRequestHandler(ILeaveAllocationRepository LeaveAllocationRepository, IMapper mapper)
        {
            _LeaveAllocationRepository = LeaveAllocationRepository;
            _mapper = mapper;
        }

        async Task<LeaveAllocationDto> IRequestHandler<GetLeaveAllocationDetailRequest, LeaveAllocationDto>.Handle(GetLeaveAllocationDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _LeaveAllocationRepository.GetLeaveAllocationWithDetails(request.Id);
            return _mapper.Map<LeaveAllocationDto>(leaveAllocation);
        }
    }
}
