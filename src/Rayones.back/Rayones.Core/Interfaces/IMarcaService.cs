using Rayones.Core.Entidades;
using Rayones.Core.CustomEntities;
using Rayones.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Rayones.Core.Interfaces
{
    public interface IMarcaService
    {
        Task InsertMarca(Marca marca);

        Task<bool> UpdateMarca(Marca marca);

        Task<bool> DeleteMarca(int id);
        Task<Marca> GetMarcaById(int id);
        PagedList<Marca> GetMarca(MarcasQueryFilter filter);
    }
}
