using Microsoft.EntityFrameworkCore;
using Bodega.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Bodega.Repository
{
    public class VinoRepository
    {
        private readonly BodegaContext _context;

        public VinoRepository()
        {
            // Configura las opciones para el contexto
            var optionsBuilder = new DbContextOptionsBuilder<BodegaContext>();
            object value = optionsBuilder.UseSqlite("Data Source=BodegaVinos.db");

            _context = new BodegaContext(optionsBuilder.Options);

            // Asegura que la base de datos se cree si no existe
            _context.Database.EnsureCreated();
        }


        // Método para obtener todos los vinos
        public List<Vino> GetVinos() => _context.Vinos.ToList();

        // Método para obtener un vino por nombre (sin distinción de mayúsculas y minúsculas)
        public Vino GetVinoByName(string name)
        {
            return _context.Vinos
                .FirstOrDefault(v => v.Name.ToLower() == name.ToLower());
        }

        // Método para agregar un nuevo vino
        public void AddVino(Vino vino)
        {
            _context.Vinos.Add(vino);
            _context.SaveChanges(); // Guarda los cambios en la base de datos
        }

        // Método para actualizar un vino existente
        public void UpdateVino(Vino vino)
        {
            var existingVino = GetVinoByName(vino.Name);
            if (existingVino != null)
            {
                existingVino.Variety = vino.Variety;
                existingVino.Year = vino.Year;
                existingVino.Region = vino.Region;
                existingVino.Stock = vino.Stock;
                _context.SaveChanges(); // Guarda los cambios en la base de datos
            }
        }
    }
}
