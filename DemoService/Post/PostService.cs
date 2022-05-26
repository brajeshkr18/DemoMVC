using Demo.Core.EntityModel;
using DemoModel.ViewModel;
using ExpressMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using static Utility.Enums;

namespace DemoService.PostService
{
    public class PostService : IPostService
    {
        private OnBoadTaskEntities _Context = new OnBoadTaskEntities();

        public List<PostViewModel> GetPostList()
        {
            List<PostViewModel> postModel = new List<PostViewModel>();
            var postObj = _Context.Posts.Where(x=>x.IsDeleted==false).ToList();
            Mapper.Map(postObj, postModel);
            return postModel;
        }
        public PostViewModel GetPostById(int Id)
        {
            PostViewModel postViewModel = new PostViewModel();
            var postObj = _Context.Posts.Where(x => x.Id == Id).FirstOrDefault();
            Mapper.Map(postObj, postViewModel);
            return postViewModel;
        }

    }
}
