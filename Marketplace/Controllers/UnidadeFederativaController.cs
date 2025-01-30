using Marketplace.Domain.Models;
using Marketplace.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Controllers
{
    [Route("api/unidades-federativas")]
    [ApiController]
    public class UnidadeFederativaController : ControllerBase
    {
        private readonly UnidadeFederativaService _unidadeFederativaService;

        public UnidadeFederativaController(UnidadeFederativaService unidadeFederativaService){
            _unidadeFederativaService = unidadeFederativaService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<EndUnidadeFederativa>), 200)]
        public async Task<ActionResult<List<EndUnidadeFederativa>>> Get()
        {
            return Ok(await _unidadeFederativaService.Get());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EndUnidadeFederativa), 200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<EndUnidadeFederativa?>> GetById([FromRoute] long id)
        {
            return Ok(await _unidadeFederativaService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<EndUnidadeFederativa?>> Post([FromBody] EndUnidadeFederativa request)
        {
            var unidadeFederativa = await _unidadeFederativaService.Post(request);
            return Created(unidadeFederativa.Codigo.ToString(), unidadeFederativa);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] EndUnidadeFederativa request)
        {
            await _unidadeFederativaService.Update(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            await _unidadeFederativaService.Delete(id);
            return NoContent();
        }

    }
}
