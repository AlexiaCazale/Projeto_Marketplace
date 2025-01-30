using Marketplace.Domain.Models;
using Marketplace.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Controllers
{
    [Route("api/contato-enderecos")]
    [ApiController]
    public class ContatoEnderecoController : ControllerBase
    {
        private readonly ContatoEnderecoService _contatoEnderecoService;

        public ContatoEnderecoController(ContatoEnderecoService ccontatoEnderecoService)
        {
          _contatoEnderecoService = ccontatoEnderecoService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CntEndContatoEndereco), 200)]
        public async Task<ActionResult<List<CntEndContatoEndereco>>> Get() 
        {
           return Ok(await _contatoEnderecoService.Get());  
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CntEndContatoEndereco), 200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<CntEndContatoEndereco?>> GetById([FromRoute] long id) 
        {
            return Ok(await _contatoEnderecoService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<CntEndContatoEndereco?>> Post([FromBody] CntEndContatoEndereco request)
        {
            var contatoEndereco = await _contatoEnderecoService.Post(request);
            return Created(contatoEndereco.Codigo.ToString(), contatoEndereco);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] CntEndContatoEndereco request)
        {
            await _contatoEnderecoService.Update(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            await _contatoEnderecoService.Delete(id);
            return NoContent();
        }
    }
}
