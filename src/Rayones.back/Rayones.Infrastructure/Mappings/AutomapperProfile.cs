using AutoMapper;
using Rayones.Core.DTOs;
using Rayones.Core.Entidades;

using System;
using System.Collections.Generic;
using System.Text;

namespace Rayones.Infrastrucure.Mappings
{
    class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            /////////////////// ---- POST ---- //////////////////

            #region Dto
            CreateMap<Unidades, UnidadesDTO>().ReverseMap();
            CreateMap<Marca, MarcaDTO>().ReverseMap();
            CreateMap<Categorias, CategoriasDTO>().ReverseMap();
            CreateMap<Acabados, AcabadosDTO>().ReverseMap();
            CreateMap<Estados, EstadosDTO>().ReverseMap();
            #endregion
        }
    }
}
