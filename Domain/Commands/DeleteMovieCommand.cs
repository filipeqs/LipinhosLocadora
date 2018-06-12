using Domain.Base;

namespace Domain.Commands
{
    /// <summary>
    /// Command to delete movie
    /// </summary>
    public class DeleteMovieCommand : ICommand
    {
        // Output
        public bool WasSuccesful { get; set; }
        public string ErrorMessage { get; set; }

        //Input
        public int Id { get; set; }

        public DeleteMovieCommand(int id)
        {
            Id = id;
        }
    }
}
