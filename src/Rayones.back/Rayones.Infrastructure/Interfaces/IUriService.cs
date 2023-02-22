using Rayones.Core.QueryFilters;
using System;

namespace Rayones.Infrastructure.Interfaces
{
   public interface IUriService
    {
        Uri GetUnidadesPaginationUri(UnidadesQueryFilter filter, string actionUrl);
    }
}