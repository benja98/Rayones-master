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

            await _unidadesService.InsertUnidades(unidade);
            var respose = new ApiResponse<UnidadesDTO>(_unidadesDTO);


            return Ok(respose);

        }

        //obtener por ID
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var unidad = await _unidadesService.GetUnidadesById(id);
            var unidadDTO = _mapper.Map<UnidadesDTO>(unidad);

            var respose = new ApiResponse<UnidadesDTO>(unidadDTO);

            return Ok(respose);

        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, UnidadesDTO _unidadesDTO)
        {

            var unidad = _mapper.Map<Unidades>(_unidadesDTO);
            unidad.Id = id;
            var result = await _unidadesService.UpdateUnidades(unidad);
            var respose = new ApiResponse<bool>(result);


            return Ok(respose);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _unidadesService.DeleteUnidades(id);

            var respose = new ApiResponse<bool>(result);

            return Ok(respose);

        }

    }
}
