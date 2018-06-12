using Domain.Base;
using Domain.Commands;
using Repository;
using Repository.Services;

namespace Domain
{
    public class DomainDispatcher
    {
        private readonly AppDbContext Context;
        private readonly MovieRepository MovieRepository;

        public DomainDispatcher(AppDbContext context)
        {
            Context = context;
            MovieRepository = new MovieRepository(context);
        }
        
        public void ExecuteCommand(ICommand command)
        {
            if (command.GetType() == typeof(LoginCommand))
            {
                var authCommand = (LoginCommand)command;
                var handler = new LoginHandler(authCommand, Context);
                handler.Execute();  
            }
        }

        public T ExecuteQuery<T>(IQuery<T> query) => query.Execute(Context);
    }
}
