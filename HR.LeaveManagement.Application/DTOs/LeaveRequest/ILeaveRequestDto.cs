using System;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public interface ILeaveRequestDto
    {
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        int LeaveTypeId { get; set; }
        string RequestComments { get; set; }
    }
}