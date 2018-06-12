namespace Domain.Base
{
    public interface ICommandHandler<T> where T : ICommand
    {
        T Command { get; set; }
        void Execute();
    }
}
