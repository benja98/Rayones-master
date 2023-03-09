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
    public class AcabadosService : IAcabadosService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly PaginationOptions _paginationOptions;

        public AcabadosService(IUnitofWork unitofWork, IOptions<PaginationOptions> options)
        {
            _unitofWork = unitofWork;
            _paginationOptions = options.Value;
        }

        public PagedList<Acabados> GetAcabados(AcabadosQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var acabados = _unitofWork.AcabadosRepository.GetAll();


            if (filters.Description != null)
            {
                acabados = acabados.Where(x => x.Descripcion.ToLower().Contains(filters.Description.ToLower()));
            }
            var pagedPosts = PagedList<Acabados>.Create(acabados, filters.PageNumber, filters.PageSize);

            return pagedPosts;
        }


        public async Task<Acabados> GetAcabadosById(int id)
        {
            return await _unitofWork.AcabadosRepository.GetById(id);
        }



        public async Task InsertAcabados(Acabados acabados)
        {
            if (acabados.Descripcion.Contains("ninguna"))
            {
                throw new BusinessException("Contenido no permitido");
            }
            if (acabados.Acabado.Contains("ninguna"))
            {
                throw new BusinessException("Contenido no permitido");
            }

            await _unitofWork.AcabadosRepository.Add(acabados);
            await _unitofWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateAcabados(Acabados acabados)
        {
            _unitofWork.AcabadosRepository.Update(acabados);
            await _unitofWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAcabados(int id)
        {
            await _unitofWork.AcabadosRepository.Delete(id);
            return true;
        }
    }
}
