using API.DTO;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController:ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Genre genre;
            using (PRN231SU22Context db = new PRN231SU22Context())
            {
                genre = db.Genres.FirstOrDefault(g => g.GenreId == id);
                if (genre == null) return NotFound();
                var config = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
                var mapper = config.CreateMapper();
                GenreDTO result = mapper.Map<Genre, GenreDTO>(genre);
                return Ok(result);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Genre> genres;
            using (PRN231SU22Context db = new PRN231SU22Context())
            {
                genres = db.Genres.ToList();
                if (genres == null) return NotFound();
                var config = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
                var mapper = config.CreateMapper();
                List<GenreDTO> result = genres.Select(r => mapper.Map<Genre, GenreDTO>(r)).ToList();
                return Ok(result);
            }
        }
    }
}
