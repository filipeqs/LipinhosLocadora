﻿using Domain.Base;
using Repository;
using Repository.Services;
using System.Linq;

namespace Domain.Commands
{
    /// <summary>
    /// Handles movie editing
    /// </summary>
    class EditMovieCommandHandler : ICommandHandler<EditMovieCommand>
    {
        private readonly AppDbContext Context;
        private readonly MovieRepository MovieRepository;

        public EditMovieCommand Command { get; set; }

        public EditMovieCommandHandler(EditMovieCommand command, AppDbContext context, MovieRepository movieRepository)
        {
            Command = command;
            Context = context;
            MovieRepository = movieRepository;
        }

        public void Execute()
        {
            var movieFromRepository = Context.Movies.FirstOrDefault(m => m.Id == Command.Movie.Id);

            if (movieFromRepository != null)
            {
                MovieRepository.EditMovie(Command.Movie);

                if (!MovieRepository.SaveChanges())
                {
                    Command.WasSuccesful = false;
                    Command.ErrorMessage = "Failed to Edit on save";
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
