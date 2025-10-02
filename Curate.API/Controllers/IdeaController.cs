using Curate.Application.DTO;
using Curate.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Curate.API.Controllers
{
    [Route("api/idea")]
    [ApiController]
    public class IdeaController : ControllerBase
    {
        private readonly IIdeaService _ideaService;
        public IdeaController(IIdeaService ideaService)
        {
            _ideaService = ideaService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(RequestDto requestDto) 
        {
            var result = await _ideaService.Create(requestDto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateDto updatetDto) 
        {
            var result = await _ideaService.Update(id, updatetDto);
            return Ok(result);
        }

    }
}
