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
    public class GetLeaveRequestListRequestHandler : IRequestHandler<GetLeaveRequestListRequest, List<LeaveRequestDto>>
    {
        private ILeaveRequestRepository _LeaveRequestRepository;
        private IMapper _mapper;

        public GetLeaveRequestListRequestHandler(ILeaveRequestRepository LeaveRequestRepository, IMapper mapper)
        {
            _LeaveRequestRepository = LeaveRequestRepository;
            _mapper = mapper;
        }

        public ILeaveRequestRepository LeaveRequestRepository { get; }
        public IMapper Mapper { get; }

        public async Task<List<LeaveRequestDto>> Handle(GetLeaveRequestListRequest request, CancellationToken cancellationToken)
        {
            var LeaveRequests = await _LeaveRequestRepository.GetAll();
            return _mapper.Map<List<LeaveRequestDto>>(LeaveRequests);
        }
    }
}
