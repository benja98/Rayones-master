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
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaService _marcaService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public MarcaController(IMarcaService marcaService, IMapper mapper, IUriService uriService)
        {
            _marcaService = marcaService;
            _mapper = mapper;
            _uriService = uriService;
        }


        [HttpPost]
        public async Task<ActionResult> Post(MarcaDTO _marcasDTO)
        {

            var marc = _mapper.Map<Marca>(_marcasDTO);

            await _marcaService.InsertMarca(marc);
            var respose = new ApiResponse<MarcaDTO>(_marcasDTO);
            return Ok(respose);

        }

        //obtener por ID
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var marca = await _marcaService.GetMarcaById(id);
            var marcaDTO = _mapper.Map<MarcaDTO>(marca);

            var respose = new ApiResponse<MarcaDTO>(marcaDTO);

            return Ok(marca);

        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, MarcaDTO marcaDTO)
        {

            var marca = _mapper.Map<Marca>(marcaDTO);
            marca.Id = id;
            var result = await _marcaService.UpdateMarca(marca);
            var respose = new ApiResponse<bool>(result);
            return Ok(respose);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _marcaService.DeleteMarca(id);

            var respose = new ApiResponse<bool>(result);

            return Ok(respose);

        }
    }
}
