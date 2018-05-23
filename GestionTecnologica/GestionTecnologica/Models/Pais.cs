using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionTecnologica.Models
{
    public class Pais
    {
        [Key]
        [Display(Name = "Pais")]
        public int IdPais { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede ser más largo de {1} caracteres.")]
        [Display(Name = "Pais")]
        public string Nombre { get; set; }

        public virtual ICollection<Departamento> Departamentos { get; set; }
    }
}
