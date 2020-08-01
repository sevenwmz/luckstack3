using ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.ChildAction;

namespace WebUI.Controllers
{
    public class CommentController : BaseController
    {
        private CommentService _service;

        public CommentController()
        {
            _service = new CommentService();
        }
        // GET: Comment
        public ActionResult _CommentAjax(int id)
        {
            return View(_service.GetComment(id));
        }


        [HttpPost]
        public ActionResult _CommentAjax(ChildCommentAjax model)
        {
            int id = _service.SaveComment(model);
            return Redirect($"/Comment/_CommentAjax?id={id}");
        }


        public ActionResult _Comments(int id)
        {
            return View(_service.GetArticleComments(id));
        }
        
        public void _CommentDelete(int deleteCommentId,int commentAuthorId)
        {
            if (commentAuthorId != _service.CurrentUserId)
            {
                throw new Exception("Is not currentUser");
            }
            _service.DeleteCommentBy(deleteCommentId);
        }
    }
}