using Domain.Base;
using Repository.Entities;

namespace Domain.Commands
{
    /// <summary>
    /// Command for movie editing
    /// </summary>
    public class EditMovieCommand : ICommand
    {    
        // Output
        public bool WasSuccesful { get; set; }
        public string ErrorMessage { get; set; }

        // Input

        internal Movie Movie { get; set; }

        public EditMovieCommand(Movie movie)
        {
            Movie = movie;
        }
    }
}
