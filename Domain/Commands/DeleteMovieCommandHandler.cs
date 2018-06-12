using Domain.Base;
using Repository.Services;

namespace Domain.Commands
{
    /// <summary>
    /// Handles delete movie
    /// </summary>
    class DeleteMovieCommandHandler : ICommandHandler<DeleteMovieCommand>
    {
        private readonly MovieRepository MovieRepository;
        public DeleteMovieCommand Command { get; set; }

        public DeleteMovieCommandHandler(DeleteMovieCommand command, MovieRepository movieRepository)
        {
            Command = command;
            MovieRepository = movieRepository;
        }

        public void Execute()
        {
            var movieFromRepository = MovieRepository.GetById(Command.Id);

            if (movieFromRepository != null)
            {
                MovieRepository.Delete(movieFromRepository);

                if (!MovieRepository.SaveChanges())
                {
                    Command.WasSuccesful = false;
                    Command.ErrorMessage = "Failed to delete on save";
                }
                else
                    Command.WasSuccesful = true;
            }
            else
            {
                Command.WasSuccesful = false;
                Command.ErrorMessage = "Movie not found";
            }
        }
    }
}
