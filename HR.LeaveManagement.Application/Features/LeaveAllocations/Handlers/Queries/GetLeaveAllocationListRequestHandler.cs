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
    public class GetLeaveAllocationListRequestHandler : IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDto>>
    {
        private ILeaveAllocationRepository _LeaveAllocationRepository;
        private IMapper _mapper;

        public GetLeaveAllocationListRequestHandler(ILeaveAllocationRepository LeaveAllocationRepository, IMapper mapper)
        {
            _LeaveAllocationRepository = LeaveAllocationRepository;
            _mapper = mapper;
        }

        public ILeaveAllocationRepository LeaveAllocationRepository { get; }
        public IMapper Mapper { get; }

        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
        {
            var LeaveAllocations = await _LeaveAllocationRepository.GetAll();
            return _mapper.Map<List<LeaveAllocationDto>>(LeaveAllocations);
        }
    }
}
