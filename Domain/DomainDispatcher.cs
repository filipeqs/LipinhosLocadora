using Domain.Base;
using Domain.Commands;
using Repository;
using Repository.Services;

namespace Domain
{
    public class DomainDispatcher
    {
        private readonly AppDbContext Context;

        public DomainDispatcher(AppDbContext context)
        {
            Context = context;
        }
        
        public void ExecuteCommand(ICommand command)
        {
            if (command.GetType() == typeof(LoginCommand))
            {
                var authCommand = (LoginCommand)command;
                var handler = new LoginCommandHandler(authCommand, Context);
                handler.Execute();  
            }

            if (command.GetType() == typeof(CreateMovieCommand))
            {
                var createMovieCommand = (CreateMovieCommand)command;
                var handler = new CreateMovieCommandHandler(createMovieCommand, Context);
                handler.Execute();
            }

            if (command.GetType() == typeof(EditMovieCommand))
            {
                var editCommand = (EditMovieCommand)command;
                var handler = new EditMovieCommandHandler(editCommand, Context);
                handler.Execute();
            }
        }

        public T ExecuteQuery<T>(IQuery<T> query) => query.Execute(Context);
    }
}
