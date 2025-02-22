using System.ComponentModel;

namespace StradaTechnicalInterview.Models.Application
{
    public class LoginModel
    {
        [DefaultValue("test")]
        public string Username { get; set; }

        [DefaultValue("password")]
        public string Password { get; set; } = "password";
    }
}