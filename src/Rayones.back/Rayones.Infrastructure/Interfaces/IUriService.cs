using Rayones.Core.QueryFilters;
using System;

namespace Rayones.Infrastructure.Interfaces
{
   public interface IUriService
    {
        Uri GetCategoriasPaginationUri(CategoriasQueryFilter filter, string actionUrl);
        Uri GetMarcaPaginationUri(MarcasQueryFilter filter, string actionUrl);
        Uri GetAcabadosPaginationUri(AcabadosQueryFilter filter, string actionUrl);
        Uri GetEstadosPaginationUri(EstadosQueryFilter filter, string actionUrl);
    }
}