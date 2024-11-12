using Microsoft.AspNetCore.Mvc;
using BlogProject.Entities;
using BlogProject.DTO;

namespace BlogProject.Services
{
    public class CategoryService
    {

        private readonly DataContext _context = new DataContext();
        public List<Category> Get() => _context.Categories;

        public Category GetById(int id) => _context.Categories.FirstOrDefault(x => x.Id == id);

        public bool AddCategory(Category c)
        {
            _context.Categories.Add(c);
            return true;
        }
        public bool Update(int id, Category c)
        {
            Category existingCategoryToUpdate = _context.Categories.FirstOrDefault(x => x.Id == id);
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
            return _context.Categories.Remove(_context.Categories.FirstOrDefault(x => x.Id == id));
        }
    }
}
