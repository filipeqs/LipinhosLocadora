using Repository;

namespace Domain.Base
{
    public interface IQuery<TOutput>
    {
        TOutput Execute(AppDbContext context);
    }
}
