using HR.LeaveManagement.Application.DTOs.Common;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validators;
using System;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest
{
    // could be more specific for certain purpose, multiple define for a dto is ok .
    public class UpdateLeaveRequestDto : BaseDTO, ILeaveRequestDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public string RequestComments { get; set; }
    }
}
