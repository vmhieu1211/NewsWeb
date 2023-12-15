using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IRepository<Category> _repository;
        public CategoryController(IRepository<Category> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var category = _repository.GetAll();
            return View(category);
        }
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
           var category = _repository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _repository.Create(category);
            return CreatedAtAction(nameof(Details), new { id = category.Id }, category);
        }
        [HttpPut]
        public IActionResult Update(int id, Category category)
        {
            _repository.Update(category);
            return Ok(id);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}
