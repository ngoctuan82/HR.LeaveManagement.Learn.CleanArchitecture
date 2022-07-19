using HR.LeaveManagement.Application.DTOs.Common;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validators;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation
{
    public class UpdateLeaveAllocationDto : BaseDTO, ILeaveAllocationDto
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
