using FluentValidation;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class ILeaveTypeDTOValidator : AbstractValidator<ILeaveTypeDto>
    {
        public ILeaveTypeDTOValidator()
        {

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.DefaultDays)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.")
                    .LessThan(100).WithMessage("{PropertyName} must be less than {ComparisionValue}");
        }
    }
}
