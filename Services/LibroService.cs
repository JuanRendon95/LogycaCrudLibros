using Entities.Models;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class LibroService : ILibroService
    {
        private readonly IRepository<Libro> _repository;

        public LibroService(IRepository<Libro> repository)
        {
            _repository = repository;
        }

        public void ValidarExistencia(int idLibro)
        {
            Libro libro = _repository.GetById(idLibro);

            if (libro == null)
                throw new Exception($"No existe ningun libro asociado al ID: {idLibro}");
        }
    }
}
