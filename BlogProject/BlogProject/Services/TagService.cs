using BlogProject.DTO;
using BlogProject.Entities;

namespace BlogProject.Services
{
    public class TagService
    {
        private readonly DataContext _context = new DataContext();
       
        public List<Tag> Get() => _context.Tags;
        public Tag GetById(int id) => _context.Tags.FirstOrDefault(x => x.Id == id);
        public bool AddTag(Tag t)
        {
            _context.Tags.Add(t);
            return true;
        }
        public bool Update(int id, Tag t)
        {
            Tag existingTagToUpdate = _context.Tags.FirstOrDefault(x => x.Id == id);
            if (existingTagToUpdate != null)
            {
                existingTagToUpdate.Name = t.Name;
                existingTagToUpdate.UsageAmount = t.UsageAmount;
                existingTagToUpdate.Description = t.Description;
                existingTagToUpdate.CreatorId = t.CreatorId;
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            return _context.Tags.Remove(_context.Tags.FirstOrDefault(x => x.Id == id));
        }
    }
}
