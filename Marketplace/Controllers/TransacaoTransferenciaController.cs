using Marketplace.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Marketplace.Domain.Services;

namespace Marketplace.Controllers
{
    [Route("api/transacoes-transferencias")]
    [ApiController]
    public class TransacaoTransferenciaController : ControllerBase
    {
        private readonly TransacaoTransferenciaService _transacaoTransferenciaService;

        public TransacaoTransferenciaController(TransacaoTransferenciaService transacaoTransferenciaService) 
        {
           _transacaoTransferenciaService = transacaoTransferenciaService;  
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TrnTransacaoTransferencia>), 200)]
        public async Task<ActionResult<List<TrnTransacaoTransferencia>>> Get() 
        {
          return Ok(await _transacaoTransferenciaService.Get());    
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TrnTransacaoTransferencia), 200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<TrnTransacaoTransferencia?>> GetById([FromRoute] long id) 
        {
            return Ok(await _transacaoTransferenciaService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<TrnTransacaoTransferencia?>> Post([FromBody] TrnTransacaoTransferencia request)
        {
            var transacaoTransferencia = await _transacaoTransferenciaService.Post(request);
            return Created(transacaoTransferencia.Codigo.ToString(), transacaoTransferencia);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] TrnTransacaoTransferencia request)
        {
            await _transacaoTransferenciaService.Update(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            await _transacaoTransferenciaService.Delete(id);
            return NoContent();
        }
    }
}
