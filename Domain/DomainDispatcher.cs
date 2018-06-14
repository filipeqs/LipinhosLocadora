using Domain.Base;
using Domain.Commands;
using Repository;
using Repository.Services;

namespace Domain
{
    public class DomainDispatcher
    {
        private readonly AppDbContext Context;
        private readonly UserRepository UserRepository;

        public DomainDispatcher(AppDbContext context, MovieRepository movieRepository, UserRepository userRepository)
        {
            Context = context;
            MovieRepository = movieRepository;
            UserRepository = userRepository;
        }

        public MovieRepository MovieRepository { get; }

        public void ExecuteCommand(ICommand command)
        {
            //var commandName = command.GetType().Name;
            //var handler = GetType().Assembly.GetTypes().FirstOrDefault(f => f.Name == $"{commandName}Handler");
            //if (handler != null)
            //{
            //    var handlerInstace = Activator.CreateInstance(handler, command, null);
            //    var handlerMethod = handler.GetMethods().FirstOrDefault(f => f.Name == "Execute");
            //    if (handlerMethod != null)
            //        handlerMethod.Invoke(handlerInstace, new object[] { });
            //}

            if (command.GetType() == typeof(LoginCommand))
            {
                var authCommand = (LoginCommand)command;
                var handler = new LoginCommandHandler(authCommand, UserRepository);
                handler.Execute();
            }

            if (command.GetType() == typeof(CreateMovieCommand))
            {
                var createMovieCommand = (CreateMovieCommand)command;
                var handler = new CreateMovieCommandHandler(createMovieCommand, MovieRepository);
                handler.Execute();
            }

            if (command.GetType() == typeof(EditMovieCommand))
            {
                var editCommand = (EditMovieCommand)command;
                var handler = new EditMovieCommandHandler(editCommand, Context, MovieRepository);
                handler.Execute();
            }

            if (command.GetType() == typeof(DeleteMovieCommand))
            {
                var deleteCommand = (DeleteMovieCommand)command;
                var handler = new DeleteMovieCommandHandler(deleteCommand, MovieRepository);
                handler.Execute();
            }
        }

        public T ExecuteQuery<T>(IQuery<T> query) => query.Execute(Context);
    }
}
