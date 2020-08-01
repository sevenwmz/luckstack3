using EntityMVC;
using RepositoryMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ChildAction;

namespace ProductServices
{
    public class CommentService : BaceService
    {
        public CommentsRepository _repo;
        public CommentService()
        {
            _repo = new CommentsRepository(dbContext);
        }


        public ChildCommentAjax GetComment(int id)
        {
            return connectedMapper.Map<ChildCommentAjax>(_repo.GetSingleComment(id));
        }

        public int SaveComment(ChildCommentAjax model)
        {
            Comments commentModel = connectedMapper.Map<Comments>(model);
            commentModel.FillComment(CurrenUser);
            return _repo.SaveComment(commentModel);
        }

        public ChildCommentModel GetArticleComments(int id)
        {
            ChildCommentModel model = new ChildCommentModel
            {
                  Comments = connectedMapper.Map<List<ChildCommentItem>>(_repo.GetArticleComments(id))
            };
            return model;

        }

        /// <summary>
        /// Remove comment from db
        /// </summary>
        /// <param name="deleteCommentId">Need comment id</param>
        public void DeleteCommentBy(int deleteCommentId)
        {
            _repo.DeleteCommentBy(_repo.Find(deleteCommentId));
        }
    }
}
