using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class UpdateLeaveTypeDTOValidator : AbstractValidator<UpdateLeaveTypeDto>
    {
        public UpdateLeaveTypeDTOValidator()
        {
            Include(new ILeaveTypeDTOValidator());

            RuleFor(p => p.Id)
                .NotNull()
                .WithMessage("{PropertyName} must be present");
        }
    }
}
