using Marketplace.Domain.Models;
using Marketplace.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Controllers
{
    [Route("api/enderecos")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _enderecoService;
        public EnderecoController(EnderecoService enderecoService)
        {
          _enderecoService = enderecoService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<EndEndereco>), 200)]
        public async Task<ActionResult<List<EndEndereco>>> Get()
        {
            return Ok(await _enderecoService.Get());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EndEndereco), 200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<EndEndereco?>> GetById([FromRoute] long id)
        {
          return Ok( await _enderecoService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<EndEndereco?>> Post([FromBody] EndEndereco request)
        {
            var endereco = await _enderecoService.Post(request);
            return Created(endereco.Codigo.ToString(), endereco);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] EndEndereco request)
        {
            await _enderecoService.Update(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            await _enderecoService.Delete(id);
            return NoContent();
        }
    }
}
