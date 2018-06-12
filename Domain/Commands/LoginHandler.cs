using Domain.Base;

namespace Domain.Commands
{
    class LoginHandler : ICommandHandler<LoginCommand>
    {
        public LoginCommand Command { get; set; }

        public LoginHandler(LoginCommand command)
        {
            Command = command;
        }

        public void Execute()
        {
            // Vericar se usuario existe no banco
            // se sim
            // a senha é igual?
            // e sim
            Command.WasSuccesful = true;

            // É nao
            Command.WasSuccesful = false;
            Command.ErrorMessage = "Senha Incorreta";
        }
    }
}
