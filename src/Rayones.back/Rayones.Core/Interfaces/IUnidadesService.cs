using Rayones.Core.Entidades;
using Rayones.Core.CustomEntities;
using Rayones.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rayones.Core.Interfaces
{
    public interface IUnidadesService
    {
        Task InsertPost(Unidades unidad);

        Task<bool> UpdatePost(Unidades unidad);

        Task<bool> DeletePost(int id);
        Task<Unidades> GetPostById(int id);
        PagedList<Unidades> GetPosts(UnidadesQueryFilter filter);
    }
}