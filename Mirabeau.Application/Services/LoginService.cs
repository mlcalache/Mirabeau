using Mirabeau.Domain.Entities;
using Mirabeau.Domain.Interfaces.Services;

namespace Mirabeau.Application.Services
{
    public class LoginService : ILoginService
    {
        public bool ValidateLogin(User user)
        {
            return user.Username == "admin" && user.Password == "123";
        }
    }
}