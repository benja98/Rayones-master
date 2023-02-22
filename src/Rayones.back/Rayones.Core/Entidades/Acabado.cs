using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rayones.Core.Entidades
{
    public partial class Acabado : BaseEntity
    {
        public string Descripcion { get; set; }
        // dudas con campo acabado, tiene el mismo nombre de la clase
        public string acabado { get; set; }
        public double PrecioAcabado { get; set; }
    }
}
