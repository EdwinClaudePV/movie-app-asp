using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieContext _context;

        public MovieController(MovieContext context)
        {
            _context = context;
        }

        // GET: api/movies
        public async Task<ActionResult<List<Movie>>> GetMovies()
        {
            //TODO : Test if the list is empty
            return await _context.Movies.ToListAsync();
        }

        // GET: api/movies/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movies = await _context.Movies.FindAsync(id);

            if (movies == null)
            {
                return NotFound();
            }

            return movies;
            
        }

        // PUT : api/movies/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.ID)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST : api/movies
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.ID }, movie);
        }

        // DELETE: api/movies/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(int id)
        {
            var movies = await _context.Movies.FindAsync(id);
            if (movies == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movies);
            await _context.SaveChangesAsync();

            return movies;
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.ID == id);
        }
    }
}
