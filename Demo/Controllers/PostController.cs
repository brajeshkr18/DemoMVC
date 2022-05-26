using DemoService.PostService;
using System.Web.Mvc;

namespace Demo.Controllers
{
    [HandleError]
    public class PostController : Controller
    {
        IPostService _postService = new PostService();
        public ActionResult GetPostList()
        {
            var postList = _postService.GetPostList();
            return View(postList);
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetPostById(int Id)
        {
            var post = _postService.GetPostById(Id);
            return View(post);
        }
    }
}