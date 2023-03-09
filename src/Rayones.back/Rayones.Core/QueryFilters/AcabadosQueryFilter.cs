using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rayones.Core.QueryFilters
{
    public class AcabadosQueryFilter
    {
        public string Description { get; set; }
        public string Acabado { get; set; }
        public double PrecioAcabado { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
