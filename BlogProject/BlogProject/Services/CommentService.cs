using Microsoft.AspNetCore.Mvc;
using BlogProject.Entities;
using BlogProject.DTO;

namespace BlogProject.Services
{
    public class CommentService
    {
        readonly IDataContext _context;
        public CommentService(IDataContext dataContext)
        {
            _context = dataContext;
            _context.LoadCategoryData();
        }
        public List<Comment> Get() => _context.CommentData;

        public Comment GetById(int id) => _context.CommentData.FirstOrDefault(x => x.Id == id);

        public bool AddComment(Comment comment)
        {
            _context.CommentData.Add(comment);
            return true;
        }
        public bool Update(int id, Comment comment)
        {
            Comment existingCommentToUpdate = _context.CommentData.FirstOrDefault(x => x.Id == id);
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
            return  _context.CommentData.Remove(_context.CommentData.FirstOrDefault(x => x.Id == id));
        }
    }
}
