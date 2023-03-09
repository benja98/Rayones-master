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
    public interface IAcabadosService
    {
        Task InsertAcabados(Acabados acabados);

        Task<bool> UpdateAcabados(Acabados acabados);

        Task<bool> DeleteAcabados(int id);
        Task<Acabados> GetAcabadosById(int id);
        PagedList<Acabados> GetAcabados(AcabadosQueryFilter filters);
    }
}
