using Marketplace.Domain.Models;
using Marketplace.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Controllers
{
    [Route("api/cidades")]
    [ApiController]
    public class CidadeController : ControllerBase
    {

        private readonly CidadeService _cidadeService;
        public CidadeController(CidadeService cidadeService)
        {
            _cidadeService = cidadeService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<EndCidade>), 200)]
        public async Task<ActionResult<List<EndCidade?>>> Get()
        {
            return Ok(await _cidadeService.Get());  
        }

   
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EndCidade), 200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<EndCidade?>> GetById([FromRoute] long id) 
        {
            return Ok(await _cidadeService.GetById(id));    
        }

        [HttpPost]
        public async Task<ActionResult<EndCidade?>> Post([FromBody] EndCidade request)
        {
            var cidade = await _cidadeService.Post(request);    
            return Created(cidade.Codigo.ToString(), cidade);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] EndCidade request)
        {
            await _cidadeService.Update(id, request);
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            await _cidadeService.Delete(id);
            return NoContent();
        }
    }
}
