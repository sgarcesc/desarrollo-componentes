using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionTecnologica.Models
{
    public class Equipo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Número de Serie")]
        public string NumeroSerie { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Tipo de Equipo")]
        public int IdTipoEquipo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Sede")]
        public int IdSede { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Fecha de Compra")]
        public DateTime FechaCompra { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Fecha Expiración de Garantía")]
        public DateTime FechaExpiracionGarantia { get; set; }


        [ForeignKey("IdTipoEquipo")]
        public virtual TipoEquipo TipoEquipo { get; set; }

        [ForeignKey("IdSede")]
        public virtual Sede Sede { get; set; }
    }
}
