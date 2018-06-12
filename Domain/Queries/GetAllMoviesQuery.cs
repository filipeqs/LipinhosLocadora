using Domain.Base;
using Repository;
using Repository.Entities;
using Repository.Services;
using System.Collections.Generic;

namespace Domain.Queries
{
    /// <summary>
    /// Query para retornar todos os filmes cadastrados
    /// </summary>
    public class GetAllMoviesQuery : IQuery<IEnumerable<Movie>>
    {
        public IEnumerable<Movie> Execute(AppDbContext context)
        {
            var repository = new MovieRepository(context);
            return repository.GetAllMovies();
        }
    }
}
