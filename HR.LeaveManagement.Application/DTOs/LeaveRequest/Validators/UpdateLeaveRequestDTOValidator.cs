using FluentValidation;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class UpdateLeaveRequestDTOValidator : AbstractValidator<UpdateLeaveRequestDto>
    {
        public ILeaveTypeRepository LeaveTypeRepository { get; }

        public UpdateLeaveRequestDTOValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            LeaveTypeRepository = leaveTypeRepository;

            Include(new ILeaveRequestDTOValidator(LeaveTypeRepository));

            RuleFor(p=>p.Id).NotNull().WithMessage("{PropertyName} must be present.");
        }

    }
}
