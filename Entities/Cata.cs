using System.Collections.Generic; 

namespace Bodega.Entities
{
    public class Cata
    {
        internal readonly object Invitado;

        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime Date { get; set; }

        public List<Vino> Vinos { get; set; } = new List<Vino>(); // Inicializa la lista
        public List<Invitado> Invitados { get; set; } = new List<Invitado>(); // Cambiado a una lista de Invitados
    }
}
