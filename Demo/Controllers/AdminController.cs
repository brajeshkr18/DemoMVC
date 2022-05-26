using Demo.Web.Helper;
using System.Web.Mvc;
using Utility;

namespace Demo.Controllers
{
    [CustomAuthorize]
    [RoleAuthorize(AppConstant.RoleAdmin,AppConstant.RoleSuperAdmin)]
    public class AdminController : Controller
    {
        // GET: Admin

        public ActionResult Dashboard()
        {
            return View();
        }
 
        //public ActionResult ManageAlbum(int? pageSize, int? page)
        //{

        //    int pageDataSize = (pageSize ?? 10);
        //    int pageNumber = (page ?? 1);
        //    ViewBag.PageSize = pageDataSize;
        //    var list = menuService.GetAllAlbum().ToPagedList(pageNumber, pageDataSize);
        //    return Request.IsAjaxRequest() ? (ActionResult)PartialView("_Album", list) : View(list);

        //}
        //[HttpGet]
        //public ActionResult AddAlbum(int data)
        //{
        //    AlbumViewModel ObjAlbum = new AlbumViewModel();
        //    if (data != 0)
        //    {
        //        ObjAlbum = menuService.GetAlbumById((int)data);
        //        return View(ObjAlbum);
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
        //[HttpPost]
        //public ActionResult AddAlbum(AlbumViewModel ObjAlbum)
        //{
        //    bool result;
        //    if (ObjAlbum.id == 0)
        //        result = menuService.SaveAlbum(ObjAlbum);
        //    else
        //        result = menuService.UpdateAlbum(ObjAlbum);
        //    if (result)
        //    {
        //        return RedirectToAction("ManageAlbum", new { });
        //    }
        //    return View();
        //}
        //[HttpGet]
        //public ActionResult DeleteGalleryImage(int data)
        //{
        //    bool result=false;
        //    if (data != 0)
        //        result = menuService.DeleteGalleryItemById(data, UserAuthenticate.LogId);
        //    if (result)
        //    {
        //        return RedirectToAction("ManageGallery", new { });
        //    }
        //    return View();
        //}
       
       
    }
}