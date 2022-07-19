using FluentValidation;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Persistence.Contracts;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class UpdateLeaveAllocationDTOValidator : AbstractValidator<UpdateLeaveAllocationDto>
    {
        public ILeaveTypeRepository LeaveTypeRepository { get; }

        public UpdateLeaveAllocationDTOValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            LeaveTypeRepository = leaveTypeRepository;

            Include(new ILeaveAllocationDTOValidator(leaveTypeRepository));

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present.");
        }

    }
}
