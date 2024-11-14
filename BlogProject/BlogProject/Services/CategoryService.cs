using Microsoft.AspNetCore.Mvc;
using BlogProject.Entities;
using BlogProject.DTO;

namespace BlogProject.Services
{
    public class CategoryService
    {

        readonly IDataContext _context ;
        public CategoryService(IDataContext dataContext)
        {
            _context = dataContext;
            _context.LoadCategoryData();
        }
        public List<Category> Get() => _context.CategoryData;

        public Category GetById(int id) => _context.CategoryData.FirstOrDefault(x => x.Id == id);

        public bool AddCategory(Category c)
        {
            _context.CategoryData.Add(c);
            return true;
        }
        public bool Update(int id, Category c)
        {
            Category existingCategoryToUpdate = _context.CategoryData.FirstOrDefault(x => x.Id == id);
            if (existingCategoryToUpdate != null)
            {
                existingCategoryToUpdate.Name = c.Name;
                existingCategoryToUpdate.ParentID = c.ParentID;
                existingCategoryToUpdate.Description = c.Description;
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            return _context.CategoryData.Remove(_context.CategoryData.FirstOrDefault(x => x.Id == id));
        }
    }
}
