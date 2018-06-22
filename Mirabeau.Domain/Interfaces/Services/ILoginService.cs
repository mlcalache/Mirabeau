using Mirabeau.Domain.Entities;

namespace Mirabeau.Domain.Interfaces.Services
{
    public interface ILoginService
    {
        bool ValidateLogin(User user);
    }
}