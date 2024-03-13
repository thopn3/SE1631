using API.Models;
using API.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        // Get all Movies
        [HttpGet]
        public IActionResult Get()
        {
            List<Movie> movies;
            using (PRN231SU22Context db = new PRN231SU22Context())
            {
                movies = db.Movies.Include(m => m.Genre).ToList();
                if (movies == null)
                {
                    return NotFound(); // Status code: 404
                }
                var config = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));
                var mapper = config.CreateMapper();
                List<MovieDTO> result = movies.Select(r => mapper.Map<Movie, MovieDTO>(r)).ToList();
                return Ok(result);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Movie movie;
            using (PRN231SU22Context db = new PRN231SU22Context())
            {
                movie = db.Movies.Include(m => m.Genre).FirstOrDefault(m1=>m1.MovieId==id);
                if (movie == null)
                {
                    return NotFound(); // Status code: 404
                }
                var config = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));
                var mapper = config.CreateMapper();
                MovieDTO result = mapper.Map<Movie, MovieDTO>(movie);
                return Ok(result);
            }
        }

        [HttpGet("search")]
        public IActionResult Get(string title)
        {
            List<Movie> movies;
            using (PRN231SU22Context db = new PRN231SU22Context())
            {
                if (title == null || title == "")
                {
                    movies = db.Movies.Include(m => m.Genre).ToList();
                }
                else
                {
                    movies = db.Movies.Include(m => m.Genre).Where(m=>m.Title.Contains(title)).ToList();
                }
                if(movies == null)
                {
                    return NotFound(); // Status code: 404
                }
                var config = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));
                var mapper = config.CreateMapper();
                List<MovieDTO> result = movies.Select(r => mapper.Map<Movie, MovieDTO>(r)).ToList();
                return Ok(result);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)
        {
            using (PRN231SU22Context db = new PRN231SU22Context())
            {
                try
                {
                    Console.WriteLine(movie);
                    db.Movies.Add(movie);
                    db.SaveChanges();
                    return Ok(movie);
                }
                catch (Exception)
                {
                    return Conflict(); // Status code: 409 - Conflic response
                }
            }
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody] Movie movie)
        {
            Movie movies;
            using (PRN231SU22Context db = new PRN231SU22Context())
            {
                movies = db.Movies.Include(m => m.Genre).FirstOrDefault(m1 => m1.MovieId == id);
                if (movies == null)
                {
                    return NotFound();
                }
                db.Entry<Movie>(movies).State = EntityState.Detached;
                db.Movies.Update(movie);
                db.SaveChanges();
                return Ok(movie);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Movie movie;
            using (PRN231SU22Context db = new PRN231SU22Context())
            {
                movie = db.Movies.Include(m => m.Genre).FirstOrDefault(m1 => m1.MovieId == id);
                if (movie == null) 
                    return NotFound();
                db.Movies.Remove(movie);
                db.SaveChanges();
                return Ok(movie);
            }
        }
    }
}
