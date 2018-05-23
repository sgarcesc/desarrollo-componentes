using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionTecnologica.Models
{
    public class Departamento
    {
        [Key]
        [Display(Name = "Departamento")]
        [Column("IdDepartameto")]
        public int IdDepartamento { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(70, ErrorMessage = "El campo {0} no puede ser más largo de {1} caracteres.")]
        [Display(Name = "Departamento")]
        public string Nombre { get; set; }

        [Display(Name = "Pais")]
        public int IdPais { get; set; }

        public virtual ICollection<Ciudad> Ciudades { get; set; }
        public virtual Pais Pais { get; set; }
    }
}
