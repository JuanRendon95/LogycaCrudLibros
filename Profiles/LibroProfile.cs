using AutoMapper;
using Entities.DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudLibrosLogyca.Profiles
{
    public class LibroProfile : Profile
    {
        public LibroProfile()
        {
            CreateMap<Libro, LibroViewModel>().ReverseMap();
        }
    }
}
