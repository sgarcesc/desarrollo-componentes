using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionTecnologica.Models
{
    public class Sede
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede ser más largo de {1} caracteres.")]
        [Display(Name = "Sede")]
        public string Descripcion { get; set; }

        [Display(Name = "Ciudad")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int IdCiudad { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede ser más largo de {1} caracteres.")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        public virtual Ciudad Ciudad { get; set; }
        public virtual ICollection<Equipo> Equipos { get; set; }
    }
}
