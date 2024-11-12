using Microsoft.AspNetCore.Mvc;
using BlogProject.Entities;
using BlogProject.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        PostService data = new PostService();
        // GET: api/<PostController>
        [HttpGet]
        public ActionResult<List<Post>> Get()
        {
            var posts = data.Get();
            return posts == null ? NotFound() : posts;
        }

        // GET api/<PostController>/5
        [HttpGet("{id}")]
        public ActionResult<Post> Get(int id)
        {
            var post = data.GetById(id);
            return post == null ? NotFound() : post;
        }

        // POST api/<PostController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Post post)
        {
            bool success = data.AddPost(post);
            return success ? true : NotFound();
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Post post)
        {
            bool success = data.Update(id, post);
            return success ? true : NotFound();
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool success = data.Delete(id);
            return success ? true : NotFound();

        }
    }
}
