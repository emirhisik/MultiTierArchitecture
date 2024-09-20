using Microsoft.AspNetCore.Mvc;
using MultiTierArchitecture.Business.Abstract;
using MultiTierArchitecture.Entities;

namespace MultiTierArchitecture.Presentation.Controllers
{
    public class ContentController : ControllerBase
    {
        private readonly IContentService _contentService;

        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddContent([FromBody] Content content)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _contentService.AddAsync(content);
            return Ok();
        }
    }
}
