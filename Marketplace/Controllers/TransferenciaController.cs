using Marketplace.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Marketplace.Domain.Services;

namespace Marketplace.Controllers
{
    [Route("api/transferencias")]
    [ApiController]
    public class TransferenciaController : ControllerBase
    {
        private readonly TransferenciaService _trasnferenciaService;

        public TransferenciaController(TransferenciaService transferenciaService)
        {
           _trasnferenciaService = transferenciaService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TrnTransferencia>), 200)]
        public async Task<ActionResult<List<TrnTransferencia>>> Get()
        {
            return Ok(await _trasnferenciaService.Get());   
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TrnTransferencia), 200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<TrnTransferencia?>> GetById([FromRoute] long id)
        {
            return Ok(await _trasnferenciaService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<TrnTransferencia?>> Post([FromBody] TrnTransferencia request)
        {
            var transferencia = await _trasnferenciaService.Post(request);
            return Created(transferencia.Codigo.ToString(), transferencia);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] TrnTransferencia request)
        {
            await _trasnferenciaService.Update(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            await _trasnferenciaService.Delete(id);
            return NoContent();
        }
    }
}
