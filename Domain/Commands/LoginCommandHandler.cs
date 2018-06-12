using Domain.Base;
using Repository.Services;

namespace Domain.Commands
{
    /// <summary>
    /// Handles user authentication on system
    /// </summary>
    class LoginCommandHandler : ICommandHandler<LoginCommand>
    {
        private readonly UserRepository UserRepository;
        public LoginCommand Command { get; set; }

        public LoginCommandHandler(LoginCommand command, UserRepository userRepository)
        {
            Command = command;
            UserRepository = userRepository;
        }

        public void Execute()
        {
            var userFromRepository = UserRepository.FindUser(Command.Email, Command.Password);

            if(userFromRepository == null)
            {
                Command.WasSuccesful = false;
                Command.ErrorMessage = "Senha Incorreta";
            }
            else
                Command.WasSuccesful = true;
        }
    }
}
