using BlogProject.Entities;

namespace BlogProject.DTO
{
    public class DataContext
    {
        public List<Category> Categories { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Post> Posts { get; set; }
        public List<Tag> Tags { get; set; }
        public List<User> Users { get; set; }


        public DataContext()
        {
            Categories = new List<Category>()
            {
                new Category
                {
                    Id = 1,
                    Name = "Category 3",
                    Description = "Description of Category 3",
                    ParentID = 2
                }
            };
            Comments = new List<Comment>(){
            new Comment
            {
                Id =1,
                Content ="hello to every one!!!",
                AuthorId =1,
                PostId =1,
                CreatedAt =DateTime.Now
            },
            new Comment
            {
                Id =2,
                Content ="hello to every body!!!",
                AuthorId =1,
                PostId =1,
                CreatedAt =DateTime.Now
            },
            new Comment
            {
                Id =3,
                Content ="hi every one!!!",
                AuthorId =2,
                PostId =1,
                CreatedAt =DateTime.Now
            }};
            Posts = new List<Post>(){
            new Post
            {
                Id = 3,
                Title = "Third Post",
                Content = "This is the content of the third post.",
                AuthorId = 2,
                CategoryId = 1,
                CreatedAt = DateTime.Now,
                Tags = new List<Tag> { new Tag { Id = 5, Name = "Tag5" }, new Tag { Id = 6, Name = "Tag6" } },
                ViewsAmount = 200,
                Image = new byte[] { 0x11, 0x22, 0x33 },
                LastUpdatedAt = DateTime.Now,
                LastViewedAt = DateTime.Now
            } };
            Tags = new List<Tag>(){
            new Tag
            {
                Id=1,
                Name="popular",
                UsageAmount=2,
                Description="manny people read this post",
                CreatorId=1,
                IsActive=true,

            },
            new Tag
            {
                Id=2,
                Name="supported",
                UsageAmount=1,
                Description="the creator give support to the readers",
                CreatorId=1,
                IsActive=true,
            }};
            Users = new List<User>(){
            new User
            {
                Id=214834921,
                Name="Ayala",
                Icon=default,
                Country="Israel",
                Bio="a student of computer programming",
                Email="a83245064@gmail.com",
                Password="1234",
                PhoneNumber="0583245064",
                RegistrationDate=DateTime.Now
            },
            new User
            {
                Id = 1,
                Name = "Alice",
                Email = "alice@example.com",
                Password = "password123",
                PhoneNumber = "1234567890",
                Country = "USA",
                Icon = new byte[] { 0x12, 0x34, 0x56 },
                Bio = "Hello, I'm Alice!",
                RegistrationDate = DateTime.Now
            },
            new User
            {
                Id = 2,
                Name = "Bob",
                Email = "bob@example.com",
                Password = "password456",
                PhoneNumber = "9876543210",
                Country = "Canada",
                Icon = new byte[] { 0xAB, 0xCD, 0xEF },
                Bio = "Hi, I'm Bob!",
                RegistrationDate = DateTime.Now
            }};
        }
    }
}
