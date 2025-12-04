using Azure;
using KASHOP.DAL.DTO.Request;
using KASHOP.PL.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using KASHOP.BLL.Service;
using Microsoft.AspNetCore.Authorization;


namespace KASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly ICategoryService _categoryService;

        public CategoriesController(IStringLocalizer<SharedResource>localizer,ICategoryService categoryService)
        {
            _localizer=localizer;
            _categoryService=categoryService;
        }

        [HttpGet("")]
        public IActionResult index()
        {
            var response = _categoryService.GetAllCategories();
            return Ok(new { message = _localizer["Success"].Value, response });
        }


        [HttpPost("")]
        public IActionResult Create(CategoryRequest request)
        {
            var response= _categoryService.CreateCategory(request);
            return Ok(new { message = _localizer["Success"].Value });
        }
    }
}
