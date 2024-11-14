using BlogProject.DTO;
using BlogProject.Entities;

namespace BlogProject.Services
{
    public class PostService
    {

        readonly IDataContext _context;
        public PostService(IDataContext dataContext)
        {
            _context = dataContext;
            _context.LoadCategoryData();
        }
        public List<Post> Get() => _context.PostData;

        public Post GetById(int id) => _context.PostData.FirstOrDefault(x => x.Id == id);

        public bool AddPost(Post p)
        {
            _context.PostData.Add(p);
            return true;
        }
        public bool Update(int id, Post p)
        {
            Post existingPostToUpdate = _context.PostData.FirstOrDefault(x => x.Id == id);
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
            return _context.PostData.Remove(_context.PostData.FirstOrDefault(x => x.Id == id));
        }
    }
}
