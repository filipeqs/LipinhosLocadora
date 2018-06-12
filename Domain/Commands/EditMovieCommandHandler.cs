using Domain.Base;
using Repository;
using Repository.Services;
using System.Linq;

namespace Domain.Commands
{
    /// <summary>
    /// Handles movie editing
    /// </summary>
    class EditMovieCommandHandler : ICommandHandler<EditMovieCommand>
    {
        private readonly AppDbContext Context;

        public EditMovieCommand Command { get; set; }

        public EditMovieCommandHandler(EditMovieCommand command, AppDbContext context)
        {
            Command = command;
            Context = context;
        }

        public void Execute()
        {
            var movieRepository = Context.Movies.FirstOrDefault(m => m.Id == Command.Movie.Id);

            if(movieRepository == null)
                Command.WasSuccesful = false;

            else
            {
                var repository = new MovieRepository(Context);
                repository.EditMovie(Command.Movie);
                Command.WasSuccesful = true;
            }
        }
    }
}
