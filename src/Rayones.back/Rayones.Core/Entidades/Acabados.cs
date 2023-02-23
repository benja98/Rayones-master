using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rayones.Core.Entidades
{
    public partial class Acabados : BaseEntity
    {
        public string Descripcion { get; set; }
        public string Acabado { get; set; }
        public double PrecioAcabado { get; set; }
    }
}
