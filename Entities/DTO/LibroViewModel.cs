using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTO
{
    public class LibroViewModel
    {
        [Required(ErrorMessage = "El titulo es requerido")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "El titulo es demasiado largo.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "El titulo solo debe contener caracteres.")]
        public string Titulo { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Ingrese un numero valido.")]
        public int Ano { get; set; }
        [Required(ErrorMessage = "El genero es requerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El genero es demasiado largo.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "El genero solo debe contener caracteres.")]
        public string Genero { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Ingrese un numero valido.")]
        public int NumeroPaginas { get; set; }
    }
}
