using Domain.Base;
using Repository;
using Repository.Services;

namespace Domain.Commands
{
    /// <summary>
    /// Handles user authentication on system
    /// </summary>
    class LoginCommandHandler : ICommandHandler<LoginCommand>
    {
        private readonly AppDbContext Context;

        public LoginCommand Command { get; set; }

        public LoginCommandHandler(LoginCommand command, AppDbContext context)
        {
            Command = command;
            Context = context;
        }

        public void Execute()
        {
            var repository = new UserRepository(Context);

            var userRepository = repository.FindUser(Command.Email, Command.Password);

            if(userRepository == null)
            {
                Command.WasSuccesful = false;
                Command.ErrorMessage = "Senha Incorreta";
            }
            else
                Command.WasSuccesful = true;
        }
    }
}
