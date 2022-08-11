using System.ComponentModel.DataAnnotations;

namespace ConsumeWebAPI.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}