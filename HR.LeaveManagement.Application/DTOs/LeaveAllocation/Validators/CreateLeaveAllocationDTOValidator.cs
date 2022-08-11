using FluentValidation;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveAllocationDTOValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        public ILeaveTypeRepository LeaveTypeRepository { get; }

        public CreateLeaveAllocationDTOValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            LeaveTypeRepository = leaveTypeRepository;

            Include(new ILeaveAllocationDTOValidator(LeaveTypeRepository));
        }

    }
}
