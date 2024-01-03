using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : Controller
    {
        private readonly NewsServices _newsServices;

        public NewsController(NewsServices newsServices)
        {
            _newsServices = newsServices;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var news = _newsServices.GetAll();
            return View(news);
        }
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var news = _newsServices.GetById(id);
            if(news == null)
            {
                return NotFound();
            }
            return View(news);
        }
        [HttpPost]
        public ActionResult Create(News news)
        {
            _newsServices.Create(news);
            return CreatedAtAction(nameof(Details), new {id = news.Id},news);
        }
        [HttpPut]
        public ActionResult Update(int id ,News news)
        {
            _newsServices.Update(news);
            return Ok(id);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _newsServices.Delete(id);
            return NoContent();
        }
    }
}
