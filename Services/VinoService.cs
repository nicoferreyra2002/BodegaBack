using Bodega.Dtos;
using Bodega.Entities;
using Bodega.Repository;

namespace Bodega.Services
{
    public class VinoService : IVinoService
    {
        private readonly VinoRepository _repository;

        public VinoService(VinoRepository repository)
        {
            _repository = repository;
        }

        public List<VinoDtos> GetAllVinos()
        {
            var vinos = _repository.GetVinos();
            return vinos.Select(v => new VinoDtos
            {
                Name = v.Name,
                Variety = v.Variety,
                Year = v.Year,
                Region = v.Region,
                Stock = v.Stock
            }).ToList();
        }

        public VinoDtos GetVinoByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("El nombre no puede estar vacío.", nameof(name));
            }

            // Obtener el vino del repositorio
            var vino = _repository.GetVinoByName(name);
            if (vino == null)
            {
                return null; // O lanzar una excepción dependiendo de tu preferencia
            }

            // Mapear Vino a VinoDtos
            return new VinoDtos
            {
                Name = vino.Name,
                Variety = vino.Variety,
                Year = vino.Year,
                Region = vino.Region,
                Stock = vino.Stock
            };
        }

        public void RegisterVino(VinoDtos vinoDto)
        {

            var vino = new Vino
            {
                Name = vinoDto.Name,
                Variety = vinoDto.Variety,
                Year = vinoDto.Year,
                Region = vinoDto.Region,
                Stock = vinoDto.Stock
            };

            _repository.AddVino(vino);
        }

        public void AddStock(string name, int quantity)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("El nombre del vino no puede estar vacío.", nameof(name));
            }

            var vino = _repository.GetVinoByName(name);
            if (vino != null) // Verificar si el vino existe
            {
                vino.Stock += quantity;
                _repository.UpdateVino(vino);
            }
            else
            {
                throw new Exception($"El vino '{name}' no existe en el inventario.");
            }
        }

    }
}
