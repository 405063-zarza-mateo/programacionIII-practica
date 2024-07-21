using AutoMapper;
using deportesApi.Dtos;
using deportesApi.models;
using deportesApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace deportesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocioController : ControllerBase
    {
        private readonly ISocioService _service;
        private readonly IMapper _mapper;

        public SocioController(ISocioService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        // GET: api/<SocioController>
        [HttpGet("GetAllSocios")]
        public async Task<ActionResult<SocioDto>> GetAll()
        {
            List<Socio> responseService = await _service.GetAllAsync();
            if (responseService.Count == 0)
            {
                return NotFound();
            }
            List<SocioDto> listaFinal = new List<SocioDto>();
            foreach (var item in responseService)
            {
                if (item.Activo)
                {
                    listaFinal.Add(_mapper.Map<SocioDto>(item));
                }
            }

            return Ok(listaFinal);
        }

        // GET api/<SocioController>/5
        [HttpGet("GetById")]
        public async Task<ActionResult<SocioDto>> GetById(Guid id)
        {
            Socio socio = await _service.GetById(id);

            if (socio != null)
            {
                if (socio.Activo)
                {
                    return Ok(_mapper.Map<SocioDto>(socio));
                }
                else { return BadRequest(); }
            }
                return BadRequest();
        }

        // POST api/<SocioController>
        [HttpPost("PostNewSocio")]
        public async Task<ActionResult<Socio>> Post([FromBody] SocioPostDto s)
        {
            Socio nuevo = _mapper.Map<Socio>(s);
            nuevo.Id = Guid.NewGuid();
            nuevo.FechaAlta = DateTime.Now;
            Socio response = await _service.PostSocioAsync(nuevo);

            return Ok(response);
        }



        // GET: api/<SocioController>
        [HttpGet("GetAllDeportes")]
        public async Task<ActionResult<List<DeporteDto>>> GetAllDeportes()
        {
            List<Deporte> deportes = await _service.GetDeportesAsync();
            List<DeporteDto> deportesFinal = _mapper.Map<List<DeporteDto>>(deportes);
            return Ok(deportesFinal);
        }
    }
}
