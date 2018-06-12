using Domain.Base;
using Repository;
using Repository.Services;

namespace Domain.Commands
{
    /// <summary>
    /// Handles movie creation
    /// </summary>
    class CreateMovieCommandHandler : ICommandHandler<CreateMovieCommand>
    {
        private readonly MovieRepository MovieRepository;
        public CreateMovieCommand Command { get; set; }

        public CreateMovieCommandHandler(CreateMovieCommand command, MovieRepository movieRepository)
        {
            Command = command;
            MovieRepository = movieRepository;
        }

        public void Execute()
        {
            MovieRepository.Add(Command.Movie);

            if (!MovieRepository.SaveChanges())
            {
                Command.WasSuccesful = false;
                Command.ErrorMessage = "Creating failed on save";
            }
            else
                Command.WasSuccesful = true;


        }
    }
}
