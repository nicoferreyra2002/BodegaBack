using Bodega.Entities;
using System.ComponentModel.DataAnnotations;

namespace   Bodega.Entities
{
    public class Invitado
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre del invitado obligatorio.")]
        public string Name { get; set; } = string.Empty;

        public int CataId { get; set; } // Clave foránea para relacionar con Cata
        public Cata Cata { get; set; }
    }
}