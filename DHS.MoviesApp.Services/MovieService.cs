using DHS.MoviesApp.Domain.Entities;
using DHS.MoviesApp.Repository.Interfaces;
using DHS.MoviesApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DHS.MoviesApp.Services
{
    public class MovieService : IMovieService
    {
        private IRepository<Movie> movieRepository;

        public MovieService(IRepository<Movie> movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public IEnumerable<Movie> GetMovies()
        {
            return movieRepository.GetAll();
        }

        public Movie GetMovieById(Guid id)
        {
            return movieRepository.Get(id);
        }

        public void Insert(Movie movie)
        {
            movieRepository.Insert(movie);
        }

        public void Update(Movie movie)
        {
            movieRepository.Update(movie);
        }

        public void Delete(Guid id)
        {
            Movie Movie = GetMovieById(id);
            movieRepository.Remove(Movie);
            movieRepository.SaveChanges();
        }
    }
}
