using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rayones.Core.QueryFilters
{
    public class EstadosQueryFilter
    {
        public string Description { get; set; }

        public int Color { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
