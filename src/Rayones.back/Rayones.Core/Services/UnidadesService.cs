using Microsoft.Extensions.Options;
using Rayones.Core.Entidades;
using Rayones.Core.Interfaces;
using Rayones.Core.CustomEntities;
using Rayones.Core.Exepciones;
using Rayones.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rayones.Core.Services
{
    public class UnidadesService : IUnidadesService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly PaginationOptions _paginationOptions;

        public UnidadesService(IUnitofWork unitofWork, IOptions<PaginationOptions> options)
        {
            _unitofWork = unitofWork;
            _paginationOptions = options.Value;
        }

        public PagedList<Unidades> GetUnidades(UnidadesQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var unidades = _unitofWork.UnidadesRepository.GetAll();


            if (filters.Description != null)
            {
                unidades = unidades.Where(x => x.Descripcion.ToLower().Contains(filters.Description.ToLower()));
            }
            var pagedPosts = PagedList<Unidades>.Create(unidades, filters.PageNumber, filters.PageSize);

            return pagedPosts;
        }


        public async Task<Unidades> GetUnidadesById(int id)
        {
            return await _unitofWork.UnidadesRepository.GetById(id);
        }



        public async Task InsertUnidades(Unidades unidad)
        {
            if (unidad.Descripcion.Contains("ninguna"))
            {
                throw new BusinessException("Contenido no permitido");
            }

            await _unitofWork.UnidadesRepository.Add(unidad);
            await _unitofWork.SaveChangesAsync(); 
        }

        public async Task<bool> UpdateUnidades(Unidades unidad)
        {
              _unitofWork.UnidadesRepository.Update(unidad);
           await  _unitofWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUnidades(int id)
        {
            await _unitofWork.UnidadesRepository.Delete(id);
            return true;
        }






    }
}
