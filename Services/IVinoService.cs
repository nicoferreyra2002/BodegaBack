using System.Runtime.CompilerServices;
using Bodega.Dtos;

namespace Bodega.Services
{
    public interface IVinoService
    {
        List<VinoDtos> GetAllVinos();
        VinoDtos GetVinoByName(string name);

        void RegisterVino(VinoDtos vinoDtos);

        void AddStock(string name, int quantify);
    }
}
