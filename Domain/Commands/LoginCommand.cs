using Domain.Base;

namespace Domain.Commands
{
    /// <summary>
    /// Command for user authentication on system
    /// </summary>
    public class LoginCommand : ICommand
    {
        // Output
        public bool WasSuccesful { get; set; }
        public string ErrorMessage { get; set; }
    
        // Input
        internal string Email { get; set; }
        internal string Password { get; set; }

        public LoginCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
