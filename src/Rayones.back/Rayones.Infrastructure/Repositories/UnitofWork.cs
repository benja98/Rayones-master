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
        private readonly IRepository<Marca> _marcaRepository;
        private readonly IRepository<Categorias> _categoriasRepository;
        private readonly IRepository<Acabados> _acabadosRepository;
        private readonly IRepository<Estados> _estadosRepository;

        public UnitofWork(RayonesContext contex)
        {
            this.contex = contex;
        }

        public IRepository<Unidades> UnidadesRepository => _unidadesRepository?? new BaseRepository<Unidades>(contex);
        public IRepository<Marca> MarcaRepository => _marcaRepository ?? new BaseRepository<Marca>(contex);
        public IRepository<Categorias> CategoriasRepository => _categoriasRepository ?? new BaseRepository<Categorias>(contex);
        public IRepository<Acabados> AcabadosRepository => _acabadosRepository ?? new BaseRepository<Acabados>(contex);
        public IRepository<Estados> EstadosRepository => _estadosRepository ?? new BaseRepository<Estados>(contex);
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
