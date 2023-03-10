using Rayones.Core.Entidades;
using Rayones.Core.CustomEntities;
using Rayones.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rayones.Core.Interfaces
{
    public interface IEstadosService
    {
        Task InsertEstados(Estados estados);

        Task<bool> UpdateEstados(Estados estados);

        Task<bool> DeleteEstados(int id);
        Task<Estados> GetEstadosById(int id);
        PagedList<Estados> GetEstados(EstadosQueryFilter filter);
    }
}
