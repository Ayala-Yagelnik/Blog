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
        public bool LoadCategoryData();
        public bool SaveCategoryData();
        public bool LoadCommentData();
        public bool SaveCommentData();
        public bool LoadPostData();
        public bool SavePostData();
        public bool LoadTagData();
        public bool SaveTagData();
        public bool LoadUserData();
        public bool SaveUserData();
    }
}
