using Microsoft.AspNetCore.Mvc;
using BlogProject.Entities;
using BlogProject.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        TagService data = new TagService();
        // GET: api/<TagController>
        [HttpGet]
        public ActionResult<List<Tag>> Get()
        {
            var tags = data.Get();
            return tags == null ? NotFound() : tags;
        }

        // GET api/<TagController>/5
        [HttpGet("{id}")]
        public ActionResult<Tag> Get(int id)
        {
            var tag = data.GetById(id);
            return tag == null ? NotFound() : tag;
        }

        // POST api/<TagController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Tag tag)
        {
            bool success = data.AddTag(tag);
            return success ? true : NotFound();
        }

        // PUT api/<TagController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Tag tag)
        {
            bool success = data.Update(id, tag);
            return success ? true : NotFound();
        }

        // DELETE api/<TagController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool success = data.Delete(id);

            return success ? true : NotFound();
        }
    }
}
