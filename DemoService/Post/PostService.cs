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
        public bool DeletePost (int Id,long LogId)
        {
            bool result;
            try
            {
                var postObj = _Context.Posts.Where(x => x.Id == Id).FirstOrDefault();
                postObj.IsDeleted = true;
                postObj.ModifiedOn = DateTime.Now;
                postObj.ModifiedBy = LogId;
                _Context.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
        public bool SavePost(PostViewModel postViewModel, long logId)
        {
            bool result;
            try
            {
                if (postViewModel.Id!=0)
                {
                    var postObj = _Context.Posts.Where(x => x.Id == postViewModel.Id).FirstOrDefault();
                    Mapper.Map(postViewModel, postObj);
                }
                else
                {
                  Post post = new Post();
                  Mapper.Map(postViewModel, post);
                  post.IsActive = true;
                  post.CreatedOn = DateTime.Now;
                  post.IsDeleted = false;
                  post.CreatedBy = logId;
                 _Context.Posts.Add(post);
                }
                _Context.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

    }
}
