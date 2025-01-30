using Marketplace.Domain.Querys;
using Marketplace.Domain.Models;
using Marketplace.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Marketplace.Domain.Commands;
using MediatR;
using Marketplace.Infra.Repositories;

namespace Marketplace.Controllers
{
    [Route("api/contatos")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly ContatoService _contatoService;
        private readonly IMediator _mediator; //reduz o acoplamento entre os componentes
        public ContatoController(ContatoService contatoService, IMediator mediator)
        {
            _contatoService = contatoService;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CntContato>), 200)]
        public async Task<ActionResult<List<CntContato>>> Get()
        {
            return Ok(await _contatoService.Get());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CntContato), 200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<CntContato?>> GetById([FromRoute] long id) 
        {
            return Ok(await _contatoService.GetById(id));
        }

        [HttpGet("contatoInfraQuery/{id}")]
        [ProducesResponseType(typeof(ContatoInfraQuery), 200)]
        public async Task<ActionResult<ContatoInfraQuery?>> GetByIdInfraQuery(long id)
        {
            return Ok(await _contatoService.GetByIdInfraQuery(id));
        }

        [HttpPut("contatoCommandQuery/{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] ContatoUpdateCommand request)
        {
            await _contatoService.UpdateAsync(id, request);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CntContato?>> Post([FromBody] CntContato request)
        {
            var contato = await _contatoService.Post(request);
            return Created(contato.Codigo.ToString(), contato);
        }

        //[HttpPost("contatoPostCommand")]
        //public async Task<ActionResult<ContatoInfraQuery?>> Create([FromBody] ContatoCreateCommand request)
        //{
        //    var contato = await _contatoService.Create(request);
        //    return Created(contato.Codigo.ToString(), contato);
        //}


        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update([FromRoute] long id, [FromBody] CntContato request)
        //{ 
        //    await _contatoService.Update(id, request);
        //    return NoContent();
        //}

        [HttpDelete("delteCommand/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        {
            await _contatoService.Delete(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            await _contatoService.Delete(id);
            return NoContent();
        }
    }
}
