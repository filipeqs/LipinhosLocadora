using Domain.Base;
using Repository.Entities;

namespace Domain.Commands
{
    /// <summary>
    /// Command to create movie
    /// </summary>
    public class CreateMovieCommand : ICommand
    {
        // Output
        public bool WasSuccesful { get; set; }
        public string ErrorMessage { get; set; }

        // Input
        internal Movie Movie { get; set; }

        public CreateMovieCommand(Movie movie)
        {
            Movie = movie;
        }
    }
}
