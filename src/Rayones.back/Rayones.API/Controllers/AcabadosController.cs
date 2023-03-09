using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class AcabadosController : ControllerBase
    {
        private readonly IAcabadosService _acabadosservice;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public AcabadosController(IAcabadosService acabadosService, IMapper mapper, IUriService uriService)
        {
            _acabadosservice = acabadosService;
            _mapper = mapper;
            _uriService = uriService;
        }


        [HttpPost]
        public async Task<ActionResult> Post(AcabadosDTO _acabadosDTO)
        {

            var acabados = _mapper.Map<Acabados>(_acabadosDTO);

            await _acabadosservice.InsertAcabados(acabados);
            var respose = new ApiResponse<AcabadosDTO>(_acabadosDTO);
            return Ok(respose);

        }

        //obtener por ID
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var acabados = await _acabadosservice.GetAcabadosById(id);
            var _acabadosDTO = _mapper.Map<AcabadosDTO>(acabados);

            var respose = new ApiResponse<AcabadosDTO>(_acabadosDTO);

            return Ok(respose);

        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, AcabadosDTO acabadosDTO)
        {

            var acabados = _mapper.Map<Acabados>(acabadosDTO);
            acabados.Id = id;
            var result = await _acabadosservice.UpdateAcabados(acabados);
            var respose = new ApiResponse<bool>(result);
            return Ok(respose);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _acabadosservice.DeleteAcabados(id);

            var respose = new ApiResponse<bool>(result);

            return Ok(respose);

        }
    }
}
