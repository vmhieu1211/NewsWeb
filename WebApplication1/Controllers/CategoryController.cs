using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IRepository<Category> _repository;
        public CategoryController(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var category = _repository.GetAll();
            return View(category);
        }

        public IActionResult Details(int id)
        {
           var category = _repository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        public IActionResult Create(Category category)
        {
            _repository.Create(category);
            return CreatedAtAction(nameof(Details), new { id = category.Id }, category);
        }
        public IActionResult Update(int id, Category category)
        {
            _repository.Update(category);
            return Ok(id);
        }
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}
