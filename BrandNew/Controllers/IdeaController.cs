using BrandNew.Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BrandNew.Controllers
{
    [Route("api/idea")]
    [ApiController]
    public class IdeaController : ControllerBase
    {
        [HttpGet]
        public RequestDto Create(RequestDto requestDto) 
        {
            return requestDto;
        }
    }
}
