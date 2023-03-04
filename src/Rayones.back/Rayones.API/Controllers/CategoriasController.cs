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
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasService _categoriasService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public CategoriasController(ICategoriasService categoriasService, IMapper mapper, IUriService uriService)
        {
            _categoriasService = categoriasService;
            _mapper = mapper;
            _uriService = uriService;
        }


        [HttpPost]
        public async Task<ActionResult> Post(CategoriasDTO _categoriasDTO)
        {

            var categorias = _mapper.Map<Categorias>(_categoriasDTO);

            await _categoriasService.InsertCategorias(categorias);
            var respose = new ApiResponse<CategoriasDTO>(_categoriasDTO);
            return Ok(respose);

        }

        //obtener por ID
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var categorias = await _categoriasService.GetCategoriasById(id);
            var _categoriasDTO = _mapper.Map<CategoriasDTO>(categorias);

            var respose = new ApiResponse<CategoriasDTO>(_categoriasDTO);

            return Ok(respose);

        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, CategoriasDTO categoriasDTO)
        {

            var categorias = _mapper.Map<Categorias>(categoriasDTO);
            categorias.Id = id;
            var result = await _categoriasService.UpdateCategorias(categorias);
            var respose = new ApiResponse<bool>(result);
            return Ok(respose);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _categoriasService.DeleteCategorias(id);

            var respose = new ApiResponse<bool>(result);

            return Ok(respose);

        }
    }
}
