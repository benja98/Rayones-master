using Rayones.Core.Entidades;
using Rayones.Core.Interfaces;
using Rayones.Infrastrucure.Data;
using Rayones.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rayones.Infrastructure.Repositories
{
    public class UnitofWork : IUnitofWork
    {
        private readonly RayonesContext contex;
        private readonly IRepository<Unidades> _unidadesRepository;

        public UnitofWork(RayonesContext contex)
        {
            this.contex = contex;
        }

        public IRepository<Unidades> UnidadesRepository => _unidadesRepository?? new BaseRepository<Unidades>(contex);
        public void Dispose()
        {
            if (contex != null)
            {
                contex.Dispose();
            }
        }

        public void SaveChange()
        {
            contex.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
           await contex.SaveChangesAsync();
        }
    }
}
