using System.ComponentModel.DataAnnotations;

namespace GestionTecnologica.Models
{
    public class TipoEquipo
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public bool Habilitado { get; set; }
    }
}
