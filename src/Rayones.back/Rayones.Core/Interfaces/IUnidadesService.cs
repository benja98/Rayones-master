using Rayones.Core.Entidades;
using Rayones.Core.CustomEntities;
using Rayones.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rayones.Core.Interfaces
{
    public interface IUnidadesService
    {
        Task InsertUnidades(Unidades unidad);

        Task<bool> UpdateUnidades(Unidades unidad);

        Task<bool> DeleteUnidades(int id);
        Task<Unidades> GetUnidadesById(int id);
        PagedList<Unidades> GetUnidades(UnidadesQueryFilter filter);
    }
}