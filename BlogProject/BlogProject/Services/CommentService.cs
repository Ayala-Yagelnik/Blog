using Microsoft.AspNetCore.Mvc;
using BlogProject.Entities;
using BlogProject.DTO;

namespace BlogProject.Services
{
    public class CommentService
    {
        private readonly DataContext _context = new DataContext();
        public List<Comment> Get() => _context.Comments;

        public Comment GetById(int id) => _context.Comments.FirstOrDefault(x => x.Id == id);

        public bool AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            return true;
        }
        public bool Update(int id, Comment comment)
        {
            Comment existingCommentToUpdate = _context.Comments.FirstOrDefault(x => x.Id == id);
            if (existingCommentToUpdate != null)
            {
                existingCommentToUpdate.PostId = comment.PostId;
                existingCommentToUpdate.AuthorId = comment.AuthorId;
                existingCommentToUpdate.CreatedAt = comment.CreatedAt;
                existingCommentToUpdate.Content = comment.Content;
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            return  _context.Comments.Remove(_context.Comments.FirstOrDefault(x => x.Id == id));
        }
    }
}
