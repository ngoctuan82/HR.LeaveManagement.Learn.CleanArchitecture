using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Models
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}