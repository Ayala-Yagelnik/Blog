using BlogProject.DTO;
using BlogProject.Entities;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UnitTest
{
    internal class FakeContext : IDataContext
    {

        public List<Category> CategoryData { get; set; }
        public List<Comment> CommentData { get; set; }
        public List<Post> PostData { get; set; }
        public List<Tag> TagData { get; set; }
        public List<User> UserData { get; set; }


        public bool LoadCategoryData()
        {

            try
            {
                CategoryData = new List<Category> { new Category()
                {
                    Id = 1,
                    Name = "Category 3",
                    Description = "Description of Category 3",
                    ParentID = 2
                } };
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SaveCategoryData()
        {
            return true;
        }

        public bool LoadCommentData()
        {
            try
            {
                CommentData = new List<Comment>(){
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
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SaveCommentData()
        {
            return true;
        }

        public bool LoadPostData()
        {
            try
            {
                PostData = new List<Post>(){
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
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SavePostData()
        {
            return true;
        }

        public bool LoadTagData()
        {
            try
            {
                TagData = new List<Tag>(){
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
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SaveTagData()
        {
            return true;
        }

        public bool LoadUserData()
        {
            try
            {

                UserData = new List<User>(){
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
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool SaveUserData()
        {
            return true;
        }
    }
}
