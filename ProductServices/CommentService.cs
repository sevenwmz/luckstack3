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


        public ChildCommentModel GetComment(int id)
        {
            return connectedMapper.Map<ChildCommentModel>(_repo.GetSingleComment(id));
        }

        public int SaveComment(ChildCommentModel model)
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
    }
}
