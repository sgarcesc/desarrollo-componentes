using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionTecnologica.Models
{
    public class Departamento
    {
        [Key]
        public int IdDepartameto { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(70, ErrorMessage = "El campo {0} no puede ser más largo de {1} caracteres.")]
        public string Nombre { get; set; }

        public int IdPais { get; set; }

        public virtual ICollection<Ciudad> Ciudades { get; set; }
        public virtual Pais Pais { get; set; }
    }
}
