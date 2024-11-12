using Microsoft.AspNetCore.Mvc;
using BlogProject.Entities;
using BlogProject.DTO;

namespace BlogProject.Services
{
    public class UserService
    {
        private readonly DataContext _context = new DataContext();
        

        public List<User> Get() => _context.Users;
      
        public User GetById(int id) => _context.Users.FirstOrDefault(x => x.Id == id);

        public bool AddUser(User user)
        {
            _context.Users.Add(user);
            return true;
        }
        public bool Update(int id, User user)
        {
            User existingUserToUpdate = _context.Users.FirstOrDefault(x => x.Id == id);
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
            return _context.Users.Remove(_context.Users.FirstOrDefault(x => x.Id == id));
        }

    }
}
