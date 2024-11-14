using Microsoft.AspNetCore.Mvc;
using BlogProject.Entities;
using BlogProject.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly CategoryService _data;
        public CategoryController(CategoryService categoryService)
        {
            _data = categoryService;
        }

        // GET: api/<CategoryContoller>
        [HttpGet]
        public ActionResult<List<Category>> Get()
        {
           var categories= _data.Get();
            if (categories==null)
            {
                return NotFound();
            }
            return categories;
        }

        // GET api/<CategoryContoller>/5
        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
           var category = _data.GetById(id);
            return category==null? NotFound() : category;
        }

        // POST api/<CategoryContoller>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Category category)
        {
            bool success=_data.AddCategory(category);
         return   success ?true: NotFound();
        }

        // PUT api/<CategoryContoller>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Category category)
        {
            bool success = _data.Update(id, category);
           
                return success? true: NotFound();
        }

        // DELETE api/<CategoryContoller>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool success = _data.Delete(id);
                return success? true:NotFound();
        }
    }
}
