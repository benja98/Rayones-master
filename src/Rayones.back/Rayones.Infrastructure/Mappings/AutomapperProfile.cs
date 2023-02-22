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

            #region Unidades
            CreateMap<Unidades, UnidadesDTO>().ReverseMap();
            #endregion


        }
    }
}
