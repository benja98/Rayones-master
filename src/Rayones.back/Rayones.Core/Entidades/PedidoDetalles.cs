using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rayones.Core.Entidades
{
    public partial class PedidoDetalles : BaseEntity
    {
        public string Color { get; set; }
        public double PrecioUnitario { get; set; }
        public double PrecioTotal { get; set; }

    }
}
