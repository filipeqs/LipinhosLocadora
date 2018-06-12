namespace Domain.Base
{
    /// <summary>
    /// Classe base para todos os comandos
    /// </summary>
    public interface ICommand
    {
        bool WasSuccesful { get; set; }
        string ErrorMessage { get; set; }
    }
}
