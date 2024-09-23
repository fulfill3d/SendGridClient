using Client.Models;

namespace Client.Interfaces
{
    public interface ISendGridClient
    {
        Task<bool> SendEmailAsync(EmailMessage message);
    }
}