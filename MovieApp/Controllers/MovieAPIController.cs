using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Data;
using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieAPIController : ControllerBase
    {
        private readonly MovieContext _context;

        public MovieAPIController(MovieContext context)
        {
            _context = context;
        }

        // GET: api/movie/all
        [HttpGet("all")]
        public async Task<ActionResult<Movie>> GetMovies()
        {
            //return View(await _context.Students.ToListAsync());
            return await _context.Movies.FindAsync(1);
        }
    }
}
