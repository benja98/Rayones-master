using Rayones.Core.Entidades;
using Rayones.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rayones.Core.Interfaces
{
    public interface IUnitofWork : IDisposable
    {
        //IUnidadesRepository OtroRepository { get; }

        IRepository<Unidades> UnidadesRepository { get; }

        void SaveChange();
        Task SaveChangesAsync();




    }
}
