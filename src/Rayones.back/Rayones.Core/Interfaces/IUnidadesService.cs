using Rayones.Core.Entidades;
using Rayones.Core.CustomEntities;
using Rayones.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rayones.Core.Interfaces
{
    public interface IUnidadesService
    {
        Task InsertUnidades(Unidades unidades);

        Task<bool> UpdateUnidades(Unidades unidades);

        Task<bool> DeleteUnidades(int id);
        Task<Unidades> GetUnidadesById(int id);
        PagedList<Unidades> GetUnidades(UnidadesQueryFilter filter);
    }
}