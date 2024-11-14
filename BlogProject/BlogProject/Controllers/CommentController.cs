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
        readonly CommentService _data;
        public CommentController(CommentService commentService)
        {
            _data = commentService;
        }
        // GET: api/<CommentController>
        [HttpGet]
        public ActionResult<List<Comment>> Get()
        {
            var comments = _data.Get();
            return comments == null ? NotFound() : comments;
        }

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public ActionResult<Comment> Get(int id)
        {
            var comment = _data.GetById(id);
            return comment == null ? NotFound() : comment;
        }

        // POST api/<CommentController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Comment comment)
        {
            bool success = _data.AddComment(comment);
            return success ? true : NotFound();
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Comment comment)
        {
            bool success = _data.Update(id, comment);
            return success ? true : NotFound();
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {

            bool success = _data.Delete(id);
            return success ? true : NotFound();
        }
    }
}
