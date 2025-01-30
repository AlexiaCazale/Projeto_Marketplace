using Marketplace.Domain.Models;
using Marketplace.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Controllers
{
    [Route("api/contas")]
    [ApiController]

    public class ContaController : ControllerBase
    {
       private readonly ContaService _contaService;

        public ContaController(ContaService contaService) 
        {
            _contaService = contaService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CtaConta), 200)]
        public async Task<ActionResult<List<CtaConta>>> Get() 
        {
            return Ok(await _contaService.Get());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CtaConta), 200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<CtaConta?>> GetById([FromRoute] long id) 
        {
            return Ok(await _contaService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<CtaConta?>> Post([FromBody] CtaConta request)
        {
            var conta = await _contaService.Post(request);
            return Created(conta.Codigo.ToString(), conta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] CtaConta request)
        {
            await _contaService.Update(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            await _contaService.Delete(id);
            return NoContent();
        }
    }
}
