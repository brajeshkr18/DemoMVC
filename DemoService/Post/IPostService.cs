
using DemoModel.ViewModel;
using System.Collections.Generic;

namespace DemoService.PostService
{
    public interface IPostService
    {
        List<PostViewModel> GetPostList();
        PostViewModel GetPostById(int Id);
        bool DeletePost(int Id, long logId);
        bool SavePost(PostViewModel postViewModel, long logId);
    }
}
