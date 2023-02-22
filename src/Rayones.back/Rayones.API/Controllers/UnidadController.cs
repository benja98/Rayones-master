using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Rayones.API.Responses;
using Rayones.Core.DTOs;
using Rayones.Core.Entidades;
using Rayones.Core.Interfaces;
using Rayones.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Rayones.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadController : ControllerBase
    {
        private readonly IUnidadesService _unidadesService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public UnidadController(IUnidadesService unidadesService,IMapper mapper, IUriService uriService)
        {
            _unidadesService = unidadesService;
            _mapper = mapper;
            _uriService = uriService;
        }


        [HttpPost]
        public async Task<ActionResult> Post(UnidadesDTO _unidadesDTO)
        {

            var unidade = _mapper.Map<Unidades>(_unidadesDTO);

            await _unidadesService.InsertPost(unidade);
            var respose = new ApiResponse<UnidadesDTO>(_unidadesDTO);


            return Ok(respose);

        }

    }
}
