using FluentValidation;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class ILeaveAllocationDTOValidator : AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public ILeaveAllocationDTOValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.NumberOfDays)
                .GreaterThanOrEqualTo(0)
                .WithMessage("{PropertyName} must be before {ComparisionValue}");

            RuleFor(p => p.Period)
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be after {ComparisionValue}");

            RuleFor(p => p.LeaveTypeId)
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExists = await _leaveTypeRepository.Exists(id);
                    return !leaveTypeExists;
                })
                .WithMessage("{PropertyName} is required.");
        }
    }
}
