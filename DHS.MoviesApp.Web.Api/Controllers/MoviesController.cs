using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DHS.MoviesApp.Domain.Entities;
using DHS.MoviesApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DHS.MoviesApp.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService moviesService;
        public MoviesController(IMovieService _moviesService)
        {
            moviesService = _moviesService;
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult GetMovies()
        {
            var movies = moviesService.GetMovies();
            return Ok(movies);
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetMovieById(Guid id)
        {
            var movie = moviesService.GetMovieById(id);
            return Ok(movie);
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult AddMovie(Movie movie)
        {

            try
            {
                moviesService.Insert(movie);
                return Ok(movie);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("Edit")]
        public IActionResult EditMovie(Movie movie)
        {
            try
            {
                moviesService.Update(movie);
                return Ok(movie);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteMovie(Guid id)
        {
            try
            {
                moviesService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}