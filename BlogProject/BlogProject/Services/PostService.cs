using BlogProject.DTO;
using BlogProject.Entities;

namespace BlogProject.Services
{
    public class PostService
    {
        private readonly DataContext _context = new DataContext();
        
   
        public List<Post> Get() => _context.Posts;

        public Post GetById(int id) => _context.Posts.FirstOrDefault(x => x.Id == id);

        public bool AddPost(Post p)
        {
            _context.Posts.Add(p);
            return true;
        }
        public bool Update(int id, Post p)
        {
            Post existingPostToUpdate = _context.Posts.FirstOrDefault(x => x.Id == id);
            if (existingPostToUpdate != null)
            {
                existingPostToUpdate.Title = p.Title;
                existingPostToUpdate.AuthorId = p.AuthorId;
                existingPostToUpdate.Content = p.Content;
                existingPostToUpdate.CategoryId = p.CategoryId;
                existingPostToUpdate.CreatedAt = p.CreatedAt;
                existingPostToUpdate.Tags = p.Tags;
                existingPostToUpdate.ViewsAmount = p.ViewsAmount;
                existingPostToUpdate.Image = p.Image;
                existingPostToUpdate.LastViewedAt = p.LastViewedAt;
                existingPostToUpdate.LastUpdatedAt = p.LastUpdatedAt;
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            return _context.Posts.Remove(_context.Posts.FirstOrDefault(x => x.Id == id));
        }
    }
}
