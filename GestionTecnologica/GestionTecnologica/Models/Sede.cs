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

        public int IdCiudad { get; set; }
        
        public string Direccion { get; set; }

        public virtual Ciudad Ciudad { get; set; }
    }
}
