//using BlogProject.Entities;
//using CsvHelper;
//using CsvHelper.Configuration;
//using Microsoft.Extensions.Logging;
//using System.Formats.Asn1;
//using System.Globalization;

//namespace BlogProject.DTO
//{
//    public class DataContext : IDataContext
//    {
//        readonly DataPathes _path;

//        public List<Category> CategoryData { get ; set ; }
//        public List<Comment> CommentData { get; set; }
//        public List<Post> PostData { get; set; }
//        public List<Tag> TagData { get; set; }
//        public List<User> UserData { get; set; }

//        public DataContext(DataPathes path)
//        {
//           _path = path;
//        }

//        public List<Category> LoadCategoryData()
//        {
//            try
//            {
//                using (var reader = new StreamReader(_path.CategoryPath))
//                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
//                {
//                    CategoryData = csv.GetRecords<Category>().ToList();
//                }
//                return CategoryData;
//            }
//            catch
//            {
//                return null;
//            }
//        }

//        public bool SaveCategoryData()
//        {
//            try
//            {
//                if (File.Exists(_path.CategoryPath))
//                    File.Delete(_path.CategoryPath);
//                using (var writer = new StreamWriter(_path.CategoryPath))
//                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
//                {
//                    csv.WriteRecords(CategoryData);
//                }
//                return true;
//            }
//            catch
//            {
//                return false;
//            }
//        }

//        public List<Comment> LoadCommentData()
//        {
//            try
//            {
//                using (var reader = new StreamReader(_path.CommentPath))
//                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
//                {
//                    CommentData = csv.GetRecords<Comment>().ToList();
//                }
//                return CommentData;
//            }
//            catch
//            {
//                return null;
//            }
//        }

//        public bool SaveCommentData()
//        {
//            try
//            {
//                if (File.Exists(_path.CommentPath))
//                    File.Delete(_path.CommentPath);
//                using (var writer = new StreamWriter(_path.CommentPath))
//                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
//                {
//                    csv.WriteRecords(CommentData);
//                }
//                return true;
//            }
//            catch
//            {
//                return false;
//            }
//        }

//        public List<Post> LoadPostData()
//        {
//            try
//            {
//                using (var reader = new StreamReader(_path.PostPath))
//                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
//                {
//                    PostData = csv.GetRecords<Post>().ToList();
//                }
//                return PostData;
//            }
//            catch
//            {
//                return null;
//            }
//        }

//        public bool SavePostData()
//        {
//            try
//            {
//                if (File.Exists(_path.PostPath))
//                    File.Delete(_path.PostPath);
//                using (var writer = new StreamWriter(_path.PostPath))
//                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
//                {
//                    csv.WriteRecords(PostData);
//                }
//                return true;
//            }
//            catch
//            {
//                return false;
//            }
//        }

//        public List<Tag> LoadTagData()
//        {
//            try
//            {
//                using (var reader = new StreamReader(_path.TagPath))
//                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
//                {
//                    TagData = csv.GetRecords<Tag>().ToList();
//                }
//                return TagData;
//            }
//            catch
//            {
//                return null;
//            }
//        }

//        public bool SaveTagData()
//        {
//            try
//            {
//                if (File.Exists(_path.TagPath))
//                    File.Delete(_path.TagPath);
//                using (var writer = new StreamWriter(_path.TagPath))
//                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
//                {
//                    csv.WriteRecords(TagData);
//                }
//                return true;
//            }
//            catch
//            {
//                return false;
//            }
//        }

//        public List<User> LoadUserData()
//        {
//            try
//            {
//                using (var reader = new StreamReader(_path.UserPath))
//                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
//                {
//                    UserData = csv.GetRecords<User>().ToList();
//                }
//                return UserData;
//            }
//            catch
//            {
//                return null;
//            }
//        }

//        public bool SaveUserData()
//        {
//            try
//            {
//                if (File.Exists(_path.UserPath))
//                    File.Delete(_path.UserPath);
//                using (var writer = new StreamWriter(_path.UserPath))
//                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
//                {
//                    csv.WriteRecords(UserData);
//                }
//                return true;
//            }
//            catch
//            {
//                return false;
//            }
//        }



//        public class DataPathes
//        {
//            public string CategoryPath { get; set; } = Path.Combine(AppContext.BaseDirectory, "Data", "category_data.csv");
//            public string CommentPath { get; set; } = Path.Combine(AppContext.BaseDirectory, "Data", "comment_data.csv");
//            public string PostPath { get; set; } = Path.Combine(AppContext.BaseDirectory, "Data", "post_data.csv");
//            public string TagPath { get; set; } = Path.Combine(AppContext.BaseDirectory, "Data", "tag_data.csv");
//            public string UserPath { get; set; } = Path.Combine(AppContext.BaseDirectory, "Data", "user_data.csv");
//        }
//    }
//}

using BlogProject.Entities;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace BlogProject.DTO
{
    public class DataContext : IDataContext
    {
        private readonly DataPathes _path;

        public List<Category> CategoryData { get; set; }
        public List<Comment> CommentData { get; set; }
        public List<Post> PostData { get; set; }
        public List<Tag> TagData { get; set; }
        public List<User> UserData { get; set; }

        public DataContext(DataPathes path)
        {
            _path = path;
            CategoryData = new List<Category>();
            CommentData = new List<Comment>();
            PostData = new List<Post>();
            TagData = new List<Tag>();
            UserData = new List<User>();
        }
 

        public List<Category> LoadCategoryData()
        {
            try
            {
                using (var reader = new StreamReader(_path.CategoryPath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    CategoryData = csv.GetRecords<Category>().ToList();
                }
                return CategoryData;
            }
            catch
            {
                return null;
            }
        }

        public bool SaveCategoryData()
        {
            try
            {
                if (File.Exists(_path.CategoryPath))
                    File.Delete(_path.CategoryPath);
                using (var writer = new StreamWriter(_path.CategoryPath))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(CategoryData);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Comment> LoadCommentData()
        {
            try
            {
                using (var reader = new StreamReader(_path.CommentPath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    CommentData = csv.GetRecords<Comment>().ToList();
                }
                return CommentData;
            }
            catch
            {
                return null;
            }
        }

        public bool SaveCommentData()
        {
            try
            {
                if (File.Exists(_path.CommentPath))
                    File.Delete(_path.CommentPath);
                using (var writer = new StreamWriter(_path.CommentPath))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(CommentData);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Post> LoadPostData()
        {
            try
            {
                using (var reader = new StreamReader(_path.PostPath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    PostData = csv.GetRecords<Post>().ToList();
                }
                return PostData;
            }
            catch
            {
                return null;
            }
        }

        public bool SavePostData()
        {
            try
            {
                if (File.Exists(_path.PostPath))
                    File.Delete(_path.PostPath);
                using (var writer = new StreamWriter(_path.PostPath))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(PostData);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Tag> LoadTagData()
        {
            try
            {
                using (var reader = new StreamReader(_path.TagPath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    TagData = csv.GetRecords<Tag>().ToList();
                }
                return TagData;
            }
            catch
            {
                return null;
            }
        }

        public bool SaveTagData()
        {
            try
            {
                if (File.Exists(_path.TagPath))
                    File.Delete(_path.TagPath);
                using (var writer = new StreamWriter(_path.TagPath))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(TagData);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<User> LoadUserData()
        {
            try
            {
                using (var reader = new StreamReader(_path.UserPath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    UserData = csv.GetRecords<User>().ToList();
                }
                return UserData;
            }
            catch
            {
                return null;
            }
        }

        public bool SaveUserData()
        {
            try
            {
                if (File.Exists(_path.UserPath))
                    File.Delete(_path.UserPath);
                using (var writer = new StreamWriter(_path.UserPath))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(UserData);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public class DataPathes
        {
            public string CategoryPath { get; set; } = Path.Combine(AppContext.BaseDirectory, "Data", "category_data.csv");
            public string CommentPath { get; set; } = Path.Combine(AppContext.BaseDirectory, "Data", "comment_data.csv");
            public string PostPath { get; set; } = Path.Combine(AppContext.BaseDirectory, "Data", "post_data.csv");
            public string TagPath { get; set; } = Path.Combine(AppContext.BaseDirectory, "Data", "tag_data.csv");
            public string UserPath { get; set; } = Path.Combine(AppContext.BaseDirectory, "Data", "user_data.csv");
        }
    }
}
