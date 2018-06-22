using System.ComponentModel;

namespace Mirabeau.UI.MVC.Models
{
    public class LoginViewModel
    {
        [DisplayName("Password")]
        public string Password { get; set; }

        [DisplayName("Username")]
        public string Username { get; set; }
    }
}