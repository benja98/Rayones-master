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
    public class EstadosService : IEstadosService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly PaginationOptions _paginationOptions;

        public EstadosService(IUnitofWork unitofWork, IOptions<PaginationOptions> options)
        {
            _unitofWork = unitofWork;
            _paginationOptions = options.Value;
        }

        public PagedList<Estados> GetEstados(EstadosQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var estados = _unitofWork.EstadosRepository.GetAll();


            if (filters.Description != null)
            {
                estados = estados.Where(x => x.Descripcion.ToLower().Contains(filters.Description.ToLower()));
            }
            var pagedPosts = PagedList<Estados>.Create(estados, filters.PageNumber, filters.PageSize);

            return pagedPosts;
        }


        public async Task<Estados> GetEstadosById(int id)
        {
            return await _unitofWork.EstadosRepository.GetById(id);
        }



        public async Task InsertEstados(Estados estados)
        {
            if (estados.Descripcion.Contains("ninguna"))
            {
                throw new BusinessException("Contenido no permitido");
            }

            await _unitofWork.EstadosRepository.Add(estados);
            await _unitofWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateEstados(Estados estados)
        {
            _unitofWork.EstadosRepository.Update(estados);
            await _unitofWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEstados(int id)
        {
            await _unitofWork.EstadosRepository.Delete(id);
            return true;
        }
    }
}
