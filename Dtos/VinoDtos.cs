﻿using System.ComponentModel.DataAnnotations;

namespace Bodega.Dtos
{
    public class VinoDtos
    {
        [Required(ErrorMessage = "Se requiere ingresar un Nombre.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ingrese una Variedad.")]
        public string Variety { get; set; } = string.Empty;

        [Range(1800, 2026, ErrorMessage = "El año debe estar entre 1700 y 2025.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Ingrese Region.")]
        public string Region { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
        public int Stock { get; set; }
    }
}
