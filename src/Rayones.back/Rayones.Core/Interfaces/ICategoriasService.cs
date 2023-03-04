using Rayones.Core.CustomEntities;
using Rayones.Core.Entidades;
using Rayones.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rayones.Core.Interfaces
{
    public interface ICategoriasService
    {
        Task InsertCategorias(Categorias categorias);

        Task<bool> UpdateCategorias(Categorias categorias);

        Task<bool> DeleteCategorias(int id);
        Task<Categorias> GetCategoriasById(int id);
        PagedList<Categorias> GetCategorias(CategoriasQueryFilter filter);
    }
}
