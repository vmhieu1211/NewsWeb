using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : Controller
    {
        private readonly IRepository<News> _repository;

        public NewsController(IRepository<News> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var news = _repository.GetAll();
            return View(news);
        }
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var news = _repository.GetById(id);
            if(news == null)
            {
                return NotFound();
            }
            return View(news);
        }
        [HttpPost]
        public ActionResult Create(News news)
        {
            _repository.Create(news);
            return CreatedAtAction(nameof(Details), new {id = news.Id},news);
        }
        [HttpPut]
        public ActionResult Update(int id ,News news)
        {
            _repository.Update(news);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}
