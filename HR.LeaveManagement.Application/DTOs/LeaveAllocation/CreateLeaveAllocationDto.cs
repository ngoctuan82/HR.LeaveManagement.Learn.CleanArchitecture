using HR.LeaveManagement.Application.DTOs.LeaveType.Validators;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation
{
    /// <summary>
    /// This dont need to inherit from baseDTO because we dont need id when create an item in db
    /// </summary>
    public class CreateLeaveAllocationDto : ILeaveAllocationDto
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
