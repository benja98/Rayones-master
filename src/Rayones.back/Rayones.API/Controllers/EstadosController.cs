using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rayones.API.Responses;
using Rayones.Core.DTOs;
using Rayones.Core.Entidades;
using Rayones.Core.Interfaces;
using Rayones.Core.Services;
using Rayones.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Rayones.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private readonly IEstadosService _estadosservice;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        // GET: EstadosController
        public EstadosController(IEstadosService estadosService, IMapper mapper, IUriService uriService)
        {
            _estadosservice = estadosService;
            _mapper = mapper;
            _uriService = uriService;
        }


        [HttpPost]
        public async Task<ActionResult> Post(EstadosDTO _estadosDTO)
        {

            var estados = _mapper.Map<Estados>(_estadosDTO);

            await _estadosservice.InsertEstados(estados);
            var respose = new ApiResponse<EstadosDTO>(_estadosDTO);
            return Ok(respose);

        }

        //obtener por ID
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var estados = await _estadosservice.GetEstadosById(id);
            var _estadosDTO = _mapper.Map<EstadosDTO>(estados);

            var respose = new ApiResponse<EstadosDTO>(_estadosDTO);

            return Ok(respose);

        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, Estados estadosDTO)
        {

            var estados = _mapper.Map<Estados>(estadosDTO);
            estados.Id = id;
            var result = await _estadosservice.UpdateEstados(estados);
            var respose = new ApiResponse<bool>(result);
            return Ok(respose);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _estadosservice.DeleteEstados(id);

            var respose = new ApiResponse<bool>(result);

            return Ok(respose);

        }
    }
}
