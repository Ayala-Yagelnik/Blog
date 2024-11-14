using BlogProject.DTO;
using BlogProject.Entities;

namespace BlogProject.Services
{
    public class TagService
    {
        readonly IDataContext _context;
        public TagService(IDataContext dataContext)
        {
            _context = dataContext;
            _context.LoadCategoryData();
        }
        public List<Tag> Get() => _context.TagData;
        public Tag GetById(int id) => _context.TagData.FirstOrDefault(x => x.Id == id);
        public bool AddTag(Tag t)
        {
            _context.TagData.Add(t);
            return true;
        }
        public bool Update(int id, Tag t)
        {
            Tag existingTagToUpdate = _context.TagData.FirstOrDefault(x => x.Id == id);
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
            return _context.TagData.Remove(_context.TagData.FirstOrDefault(x => x.Id == id));
        }
    }
}
