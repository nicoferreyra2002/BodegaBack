using System.ComponentModel.DataAnnotations;

namespace Bodega.Entities
{
    public class Vino
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar un Nombre.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ingrese una Variedad.")]
        public string Variety { get; set; } = string.Empty;

        [Range(1800, 2026, ErrorMessage = "El año debe estar entre 1800 y 2026.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Ingrese Region.")]
        public string Region { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
        public int Stock;
    }
}
