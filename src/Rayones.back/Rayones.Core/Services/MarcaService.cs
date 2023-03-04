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
    public class MarcaService : IMarcaService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly PaginationOptions _paginationOptions;

        public MarcaService(IUnitofWork unitofWork, IOptions<PaginationOptions> options)
        {
            _unitofWork = unitofWork;
            _paginationOptions = options.Value;
        }

        public PagedList<Marca> GetMarca(MarcasQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var marcas = _unitofWork.MarcaRepository.GetAll();


            if (filters.Description != null)
            {
                marcas = marcas.Where(x => x.Descripcion.ToLower().Contains(filters.Description.ToLower()));
            }
            var pagedPosts = PagedList<Marca>.Create(marcas, filters.PageNumber, filters.PageSize);

            return pagedPosts;
        }


        public async Task<Marca> GetMarcaById(int id)
        {
            return await _unitofWork.MarcaRepository.GetById(id);
        }



        public async Task InsertMarca(Marca marca)
        {
            if (marca.Descripcion.Contains("ninguna"))
            {
                throw new BusinessException("Contenido no permitido");
            }

            await _unitofWork.MarcaRepository.Add(marca);
            await _unitofWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateMarca(Marca marca)
        {
            _unitofWork.MarcaRepository.Update(marca);
            await _unitofWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMarca(int id)
        {
            await _unitofWork.MarcaRepository.Delete(id);
            return true;
        }
    }
}
