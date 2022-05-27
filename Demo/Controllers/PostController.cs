using Demo.Web.Helper;
using DemoModel.ViewModel;
using DemoService.PostService;
using PagedList;
using System;
using System.Web.Mvc;
using Utility;

namespace Demo.Controllers
{
    [HandleError]
    [CustomAuthorize]
    [RoleAuthorize(AppConstant.RoleAdmin, AppConstant.RoleSuperAdmin,AppConstant.RoleUser)]
    public class PostController : Controller
    {
        IPostService _postService = new PostService();
        public ActionResult ManagePosts(int? pageSize, int? page)
        {
            int pageDataSize = (pageSize ?? 10);
            int pageNumber = (page ?? 1);
            ViewBag.PageSize = pageDataSize;
            var postList = _postService.GetPostList().ToPagedList(pageNumber, pageDataSize); ;
            return Request.IsAjaxRequest() ? (ActionResult)PartialView("_Posts", postList) : View(postList);
        }
        public ActionResult AddPost(int Id)
         {
            if (Id!=0)
            {
                var post = _postService.GetPostById(Id);
                return View(post);
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddPost(PostViewModel postViewModel)
        {
            _postService.SavePost(postViewModel, Convert.ToInt32(UserAuthenticate.LogId));
            return RedirectToAction("ManagePosts");
        }
        public JsonResult DeletePost(int Id)
        {
            string status = string.Empty;
            try
            {
                bool result = _postService.DeletePost(Id, Convert.ToInt32(UserAuthenticate.LogId));
                if (result)
                    status = "Success";
                else
                    status = "Failure";
            }
            catch(Exception ex){
                status = ex.Message;
            }
            return Json(new { status = status });

        }
    }
}