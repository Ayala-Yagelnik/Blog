using Microsoft.AspNetCore.Mvc;
using BlogProject.Entities;
using BlogProject.DTO;

namespace BlogProject.Services
{
    public class UserService
    {
        readonly IDataContext _context;
        public UserService(IDataContext dataContext)
        {
            _context = dataContext;
            _context.LoadCategoryData();
        }


        public List<User> Get() => _context.UserData;
      
        public User GetById(int id) => _context.UserData.FirstOrDefault(x => x.Id == id);

        public bool AddUser(User user)
        {
            _context.UserData.Add(user);
            return true;
        }
        public bool Update(int id, User user)
        {
            User existingUserToUpdate = _context.UserData.FirstOrDefault(x => x.Id == id);
            if (existingUserToUpdate != null)
            {
                existingUserToUpdate.Name = user.Name;
                existingUserToUpdate.Email = user.Email;
                existingUserToUpdate.Password = user.Password;
                existingUserToUpdate.PhoneNumber = user.PhoneNumber;
                existingUserToUpdate.Country = user.Country;
                existingUserToUpdate.Icon = user.Icon;
                existingUserToUpdate.Bio = user.Bio;
                existingUserToUpdate.RegistrationDate = user.RegistrationDate;
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            return _context.UserData.Remove(_context.UserData.FirstOrDefault(x => x.Id == id));
        }

    }
}
