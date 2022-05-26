
using DemoModel.ViewModel;
using System.Collections.Generic;

namespace DemoService.PostService
{
    public interface IPostService
    {
        List<PostViewModel> GetPostList();
        PostViewModel GetPostById(int Id);
    }
}
