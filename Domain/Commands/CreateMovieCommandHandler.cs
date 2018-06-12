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
        private readonly AppDbContext Context;

        public CreateMovieCommand Command { get; set; }

        public CreateMovieCommandHandler(CreateMovieCommand command, AppDbContext context)
        {
            Command = command;
            Context = context;
        }

        public void Execute()
        {

            var repository = new MovieRepository(Context);

            repository.Add(Command.Movie);

            if (!repository.SaveChanges())
            {
                Command.WasSuccesful = false;
                Command.ErrorMessage = "Creating failed on save";
            }
            else
                Command.WasSuccesful = true;


        }
    }
}
