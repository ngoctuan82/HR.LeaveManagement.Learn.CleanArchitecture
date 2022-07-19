namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public interface ILeaveAllocationDto
    {
         int NumberOfDays { get; set; }
         int LeaveTypeId { get; set; }
         int Period { get; set; }
    }
}