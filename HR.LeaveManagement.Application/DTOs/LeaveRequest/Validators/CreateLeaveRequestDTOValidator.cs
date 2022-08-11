using FluentValidation;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveRequestDTOValidator : AbstractValidator<CreateLeaveRequestDto>
    {
        public ILeaveTypeRepository LeaveTypeRepository { get; }

        public CreateLeaveRequestDTOValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            LeaveTypeRepository = leaveTypeRepository;

            Include(new ILeaveRequestDTOValidator(LeaveTypeRepository));
        }

    }
}
