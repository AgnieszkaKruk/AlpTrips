using AlpsTrips.MVC.Models;

namespace AlpsTrips.MVC.Services
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmailOptions emailOptions);
    }
}