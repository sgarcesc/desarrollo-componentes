using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionTecnologica.Models
{
    public class Ciudad
    {
        [Key]
        [Display(Name = "Ciudad")]
        public int IdCiudad { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(70, ErrorMessage = "El campo {0} no puede ser más largo de {1} caracteres.")]
        [Display(Name = "Ciudad")]
        public string Nombre { get; set; }

        [Display(Name = "Departamento")]
        public int IdDepartamento { get; set; }

        [NotMapped]
        [Display(Name = "Pais")]
        public int IdPais { get; set; }

        public virtual Departamento Departamento { get; set; }
        public virtual ICollection<Sede> Sedes { get; set; }
    }
}
