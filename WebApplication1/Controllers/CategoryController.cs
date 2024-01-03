using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly CategoryServices _categoryServices;
        public CategoryController(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var category = _categoryServices.GetAll();
            return View(category);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
           var category = _categoryServices.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _categoryServices.Create(category);
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }
        [HttpPut]
        public ActionResult Update(int id, Category category)
        {
            _categoryServices.Update(category);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _categoryServices.delete(id);
            return NoContent();
        }
    }
}
