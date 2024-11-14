using BlogProject.Entities;

namespace BlogProject.DTO
{
    public interface IDataContext
    {
        public List<Category> CategoryData { get; set; }
        public List<Comment> CommentData { get; set; }
        public List<Post> PostData { get; set; }
        public List<Tag> TagData { get; set; }
        public List<User> UserData { get; set; }
        public List<Category> LoadCategoryData();
        public bool SaveCategoryData();
        public List<Comment> LoadCommentData();
        public bool SaveCommentData();
        public List<Post> LoadPostData();
        public bool SavePostData();
        public List<Tag> LoadTagData();
        public bool SaveTagData();
        public List<User> LoadUserData();
        public bool SaveUserData();
    }
}
