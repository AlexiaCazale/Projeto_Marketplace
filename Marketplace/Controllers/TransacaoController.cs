using Marketplace.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Marketplace.Domain.Services;

namespace Marketplace.Controllers
{
    [Route("api/transacoes")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly TransacaoService _transacaoService;
        public TransacaoController(TransacaoService transacaoService)
        { 
           _transacaoService = transacaoService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TrnTransacao>), 200)]
        public async Task<ActionResult<List<TrnTransacao>>> Get() 
        {
           return Ok(await _transacaoService.Get());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TrnTransacao), 200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<TrnTransacao?>> GetById([FromRoute] long id) 
        {
            return Ok(await _transacaoService.GetById(id)); 
        }

        [HttpPost]
        public async Task<ActionResult<TrnTransacao?>> Post([FromBody] TrnTransacao request)
        {
            var transacao = await _transacaoService.Post(request);
            return Created(transacao.Codigo.ToString(), transacao);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] TrnTransacao request)
        {
            await _transacaoService.Update(id, request);
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            await _transacaoService.Delete(id);
            return NoContent();
        }
    }
}
