using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Libro
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public string Genero { get; set; }
        public int NumeroPaginas { get; set; }
    }
}
