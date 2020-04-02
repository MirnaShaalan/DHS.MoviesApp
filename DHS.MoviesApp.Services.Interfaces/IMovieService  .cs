using DHS.MoviesApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DHS.MoviesApp.Services.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetMovies();

        Movie GetMovieById(Guid movieId);

        void Insert(Movie movie);

        void Update(Movie movie);

        void Delete(Guid movieId);

    }
}
