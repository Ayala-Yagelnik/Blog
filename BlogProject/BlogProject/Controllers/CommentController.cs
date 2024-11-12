using Microsoft.AspNetCore.Mvc;
using BlogProject.Entities;
using BlogProject.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        CommentService data = new CommentService();
        // GET: api/<CommentController>
        [HttpGet]
        public ActionResult<List<Comment>> Get()
        {
            var comments = data.Get();
            return comments == null ? NotFound() : comments;
        }

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public ActionResult<Comment> Get(int id)
        {
            var comment = data.GetById(id);
            return comment == null ? NotFound() : comment;
        }

        // POST api/<CommentController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Comment comment)
        {
            bool success = data.AddComment(comment);
            return success ? true : NotFound();
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Comment comment)
        {
            bool success = data.Update(id, comment);
            return success ? true : NotFound();
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {

            bool success = data.Delete(id);
            return success ? true : NotFound();
        }
    }
}
