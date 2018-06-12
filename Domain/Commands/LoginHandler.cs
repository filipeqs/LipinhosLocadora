using Domain.Base;
using Repository;
using Repository.Services;

namespace Domain.Commands
{
    class LoginHandler : ICommandHandler<LoginCommand>
    {
        private readonly AppDbContext Context;

        public LoginCommand Command { get; set; }

        public LoginHandler(LoginCommand command, AppDbContext context)
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
