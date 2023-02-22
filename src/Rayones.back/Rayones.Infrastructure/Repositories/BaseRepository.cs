using Microsoft.EntityFrameworkCore;
using Rayones.Infrastrucure.Data;
using Rayones.Core.Entidades;
using Rayones.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rayones.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly RayonesContext _context;

        /// <summary>
        /// se matricula la entidad 
        /// </summary>
        protected readonly DbSet<T> _entities;

        public BaseRepository(RayonesContext context)
        {
            _context = context;
            //Registramos la entidad
            _entities = context.Set<T>();
        }

        public  IEnumerable<T> GetAll()
        {
            return  _entities.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _context.AddAsync(entity);

        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _context.Remove(entity);
        }
    }
}
