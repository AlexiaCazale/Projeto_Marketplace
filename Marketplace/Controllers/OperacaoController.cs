using Marketplace.Domain.Models;
using Marketplace.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Controllers
{
    [Route("api/operacoes")]
    [ApiController]
    public class OperacaoController : ControllerBase
    {
        private readonly OperacaoService _operacaoService;

        public OperacaoController(OperacaoService operacaoService)
        {
           _operacaoService = operacaoService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<OprOperacao>), 200)]
        public async Task<ActionResult<List<OprOperacao>>> Get() 
        {
            return Ok(await _operacaoService.Get());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OprOperacao), 200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<OprOperacao?>> GetById([FromRoute] char id) 
        {
           return Ok(await _operacaoService.GetById(id));   
        }

        [HttpPost]
        public async Task<ActionResult<OprOperacao?>> Post([FromBody] OprOperacao request)
        {
            var operacao = await _operacaoService.Post(request);
            return Created(operacao.Codigo.ToString(), operacao);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] char id, [FromBody] OprOperacao request)
        {
            await _operacaoService.Update(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] char id)
        {
            await _operacaoService.Delete(id);
            return NoContent();
        }
    }
}



