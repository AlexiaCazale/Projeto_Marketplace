using Marketplace.Domain.Models;
using Marketplace.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Controllers
{
    [Route("api/tipos-transferencias")]
    [ApiController]
    public class TipoTransferenciaController : ControllerBase
    {
       private readonly TipoTransferenciaService _tipoTransferenciaService;
        public TipoTransferenciaController(TipoTransferenciaService tipoTransferenciaService) 
        {
            _tipoTransferenciaService = tipoTransferenciaService;
        }
       
        [HttpGet]
        [ProducesResponseType(typeof(List<TrnTipoTransferencia>), 200)]
        public async Task<ActionResult<List<TrnTipoTransferencia>>> Get() 
        {
            return Ok(await _tipoTransferenciaService.Get());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TrnTipoTransferencia), 200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<TrnTipoTransferencia?>> GetById([FromRoute] long id) 
        {
            return Ok(await _tipoTransferenciaService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<TrnTipoTransferencia?>> Post([FromBody] TrnTipoTransferencia request)
        {
            var tipoTransferencia = await _tipoTransferenciaService.Post(request);
            return Created(tipoTransferencia.Codigo.ToString(), tipoTransferencia);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] TrnTipoTransferencia request)
        {
            await _tipoTransferenciaService.Update(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            await _tipoTransferenciaService.Delete(id);
            return NoContent();
        }
    }
}
