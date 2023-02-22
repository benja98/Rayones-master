using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rayones.Core.Entidades
{
    public partial class Pedidos : BaseEntity
    {
        public string Observaciones { get; set; }
        public DateTime Fecha_emision { get; set; }
        public DateTime Fecha_creacion { get; set; }
        public DateTime Vendedor { get; set; }
        public string Envio_muestra { get; set; }
        public string AutorizadoPor { get; set; }

    }
}
