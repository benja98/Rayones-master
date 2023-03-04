using Microsoft.Extensions.Options;
using Rayones.Core.CustomEntities;
using Rayones.Core.Entidades;
using Rayones.Core.Exepciones;
using Rayones.Core.Interfaces;
using Rayones.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rayones.Core.Services
{
    public class CategoriasService : ICategoriasService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly PaginationOptions _paginationOptions;

        public CategoriasService(IUnitofWork unitofWork, IOptions<PaginationOptions> options)
        {
            _unitofWork = unitofWork;
            _paginationOptions = options.Value;
        }

        public PagedList<Categorias> GetCategorias(CategoriasQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var categorias = _unitofWork.CategoriasRepository.GetAll();


            if (filters.Description != null)
            {
                categorias = categorias.Where(x => x.Descripcion.ToLower().Contains(filters.Description.ToLower()));
            }
            var pagedPosts = PagedList<Categorias>.Create(categorias, filters.PageNumber, filters.PageSize);

            return pagedPosts;
        }


        public async Task<Categorias> GetCategoriasById(int id)
        {
            return await _unitofWork.CategoriasRepository.GetById(id);
        }



        public async Task InsertCategorias(Categorias categorias)
        {
            if (categorias.Descripcion.Contains("ninguna"))
            {
                throw new BusinessException("Contenido no permitido");
            }

            await _unitofWork.CategoriasRepository.Add(categorias);
            await _unitofWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateCategorias(Categorias categorias)
        {
            _unitofWork.CategoriasRepository.Update(categorias);
            await _unitofWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCategorias(int id)
        {
            await _unitofWork.CategoriasRepository.Delete(id);
            return true;
        }
    }
}
