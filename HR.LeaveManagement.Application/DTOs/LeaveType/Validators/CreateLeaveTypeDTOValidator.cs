using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveTypeDTOValidator : AbstractValidator<CreateLeaveTypeDto>
    {
        public CreateLeaveTypeDTOValidator()
        {
            Include(new ILeaveTypeDTOValidator());
        }
    }
}
