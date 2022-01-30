using AutoMapper;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudLibrosLogyca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly IRepository<Libro> _repository;
        private readonly ILibroService _libroService;
        private readonly IMapper _mapper;

        public LibrosController(IRepository<Libro> repository, IMapper mapper, ILibroService libroService)
        {
            _repository = repository;
            _libroService = libroService;
            _mapper = mapper;
        }

        // GET: api/<LibrosController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

        // GET api/<LibrosController>/5
        [HttpGet("{idLibro}")]
        public IActionResult Get(int idLibro)
        {
            if (idLibro <= 0)
                return BadRequest("Ingrese un ID valido.");

            return Ok(JsonConvert.SerializeObject(_repository.GetById(idLibro)));
        }

        // POST api/<LibrosController>
        [HttpPost]
        public IActionResult Post([FromBody] LibroViewModel libro)
        {
            if (!ModelState.IsValid)
                return BadRequest(JsonConvert.SerializeObject(ModelState));

            try
            {
                _repository.Add(_mapper.Map<Libro>(libro));
            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject($"Ha ocurrido un error guardando el libro: {ex.Message}"));
            }

            return Ok(JsonConvert.SerializeObject("Libro almacenado correctamente"));
        }

        // PUT api/<LibrosController>/5
        [HttpPut("{idLibro}")]
        public IActionResult Put(int idLibro, [FromBody] LibroViewModel libro)
        {
            if (!ModelState.IsValid)
                return BadRequest(JsonConvert.SerializeObject(ModelState));

            try
            {
                _libroService.ValidarExistencia(idLibro);
                Libro libroUpdate = _mapper.Map<Libro>(libro);
                libroUpdate.ID = idLibro;
                _repository.Update(libroUpdate);
            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject($"Ha ocurrido un error guardando el libro: {ex.Message}"));
            }

            return Ok(JsonConvert.SerializeObject("Libro actualizado correctamente."));
        }

        // DELETE api/<LibrosController>/5
        [HttpDelete("{idLibro}")]
        public IActionResult Delete(int idLibro)
        {
            if (idLibro <= 0)
                return BadRequest(JsonConvert.SerializeObject("Ingrese un ID valido."));

            try
            {
                _libroService.ValidarExistencia(idLibro);
                _repository.Delete(idLibro);
            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject($"Ha ocurrido un error eliminando el libro: {ex.Message}"));
            }

            return Ok(JsonConvert.SerializeObject("Libro eliminado correctamente"));
        }
    }
}
