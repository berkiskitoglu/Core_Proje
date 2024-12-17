using Core_Proje_Api.DAL.ApiContext;
using Core_Proje_Api.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
            var c = new Context();
            return Ok(c.Categories.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult CategoryGet(int id)
        {
            var c = new Context();
            var value = c.Categories.Find(id);
            if(value == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(value);
            }
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            using var c = new Context();
            c.Add(category);
            c.SaveChanges();
            return Created("", category);
        }
        [HttpDelete]
        public IActionResult CategoryDelete(int id)
        {
            using var c = new Context();
            var values = c.Categories.Find(id);
            if(values == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(values);
                c.SaveChanges();
                return NoContent();
            }
        }
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            using var c = new Context();
            var values = c.Find<Category>(category.CategoryID);
            if(values == null)
            {
                return NotFound();
            }
            else
            {
                values.CategoryName = category.CategoryName;
                c.Update(values);
                c.SaveChanges();
                return NoContent();
            }
        }
           
    }
}
