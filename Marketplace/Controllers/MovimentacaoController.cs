using Marketplace.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Marketplace.Domain.Services;

namespace Marketplace.Controllers
{
    [Route("api/movimentacoes")]
    [ApiController]
    public class MovimentacaoController : ControllerBase
    {
        private readonly MovimentacaoService _movimentacaoService;

        public MovimentacaoController(MovimentacaoService movimentacaoService) 
        {
           _movimentacaoService = movimentacaoService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CtaMovimentacao>), 200)]
        public async Task<ActionResult<List<CtaMovimentacao>>> Get()
        {
            return Ok(await  _movimentacaoService.Get());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CtaMovimentacao), 200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<CtaMovimentacao?>> GetById([FromRoute] long id) 
        {
            return Ok(await _movimentacaoService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<CtaMovimentacao?>> Post([FromBody] CtaMovimentacao request)
        {
            var movimentacao = await _movimentacaoService.Post(request);
            return Created(movimentacao.Codigo.ToString(), movimentacao);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] CtaMovimentacao request)
        {
            await _movimentacaoService.Update(id, request);
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            await _movimentacaoService.Delete(id);
            return NoContent();
        }
    }
}
