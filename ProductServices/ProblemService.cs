using EntityMVC;
using RepositoryMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Problem;

namespace ProductServices
{
    public class ProblemService : BaceService
    {
        private Problem _problemEntity;
        private ProblemRepository _repository;
        public ProblemService()
        {
            _problemEntity = new Problem();
            _repository = new ProblemRepository(dbContext);
        }

        #region Problem New
        public int Add(ProblemNewModel model)
        {
            _problemEntity = connectedMapper.Map<Problem>(model);
            _problemEntity.Author = CurrenUser;
            _problemEntity.Publish(model.RewardMoney);
            _problemEntity.HelpFrom = new UserRepository(dbContext).GetBy(model.HelpFrom);

            _problemEntity.OwnKeyword = new List<KeywordsAndProblem>();
            _problemEntity.OwnKeyword.Add(new KeywordsAndProblem { Problem = _problemEntity, KeywordId = model.FristDropDownKeywordsId.Value });
            _problemEntity.OwnKeyword.Add(new KeywordsAndProblem { Problem = _problemEntity, KeywordId = model.SecendDropDownKeywordsId.Value });

            if (model.NeedSubKeyword != null)
            {
                SaveKeyword(model.NeedSubKeyword);
            }
            //BMoney minus change
            _problemEntity.Author.Wallet = new List<BMoney>();
            _problemEntity.Author.Wallet.Add(new BMoney().PublicProblemMinusBMoney
                (model.RewardMoney, new BMoneyRepository(dbContext).GetByAuthorBMoney(CurrentUserId)));
            int problemId = _repository.Add(_problemEntity);
            return problemId; /*repository.Add(_problemEntity);*/
        }

        public ProblemSingleModel GetSingelProblem(int id)
        {
            Problem repoProblem = new Problem();
            repoProblem = new ProblemRepository(dbContext).FindSingleProblem(id);
            ProblemSingleModel singleModel = connectedMapper.Map<ProblemSingleModel>(repoProblem);

            return singleModel;
        }

        #endregion

        #region Problem Index
        /// <summary>
        /// Count total problem number
        /// </summary>
        /// <returns>Return all problem number</returns>
        public int Count()
        {
            return _repository.Count();
        }

        public ProblemIndexModel GetIndexPage(int pageSize, int pageIndex)
        {
            IList<Problem> tempProblem = new List<Problem>();
            tempProblem = _repository.GetProblems(pageSize, pageIndex);
            ProblemIndexModel model = new ProblemIndexModel
            {
                Items = connectedMapper.Map<List<ProblemItemModel>>(tempProblem)
            };

            return model;
        }
        #endregion

        #region Problem Edit
        public ProblemEditModel GetEditProblem(int id)
        {
            _problemEntity = _repository.GetEditProblem(id);

            ProblemEditModel problemEditModel = new ProblemEditModel();
            problemEditModel = connectedMapper.Map<ProblemEditModel>(_problemEntity);

            var keywords = new KeywordAndProblemRepository(dbContext).GetKeywords(id);
            string keyWordOfProblem = string.Empty;
            foreach (var item in keywords)
            {
                keyWordOfProblem += item.Keyword.Name + " ";
            }
            problemEditModel.NeedSubKeyword = keyWordOfProblem;
            return problemEditModel;
        }
        public void Update(ProblemEditModel model)
        {
            _problemEntity = _repository.GetEditProblem(model.Id);
            _problemEntity.OwnKeyword.Clear();
            _problemEntity = connectedMapper.Map<Problem>(model);
            _problemEntity.Author = CurrenUser;

            _repository.UpdateEditProblem(_problemEntity);

            {
                //Save keywords and into n:n table.
                new KeywordsService().SaveKeywords(model.NeedSubKeyword);
                new KeywordAndProblemService().SaveMiddleTale(model.Id, model.NeedSubKeyword);
            }
        }
        #endregion

        #region Problem Single


        #endregion
        private void SaveKeyword(string Keywords)
        {
            _problemEntity.OwnKeyword = new List<KeywordsAndProblem>();
            IList<Keywords> keywords = new Keywords().GetKeywordList(Keywords);
            Keywords checkExist = new Keywords();
            foreach (var item in keywords)
            {
                checkExist = new KeywordRepository(dbContext).FindKeyword(item.Name);
                if (checkExist == null)
                {
                    _problemEntity.OwnKeyword.Add(new KeywordsAndProblem
                    { Problem = _problemEntity, Keyword = new Keywords { Name = item.Name, Used = 1 } });
                }
                else
                {
                    checkExist.Used += 1;
                    _problemEntity.OwnKeyword.Add(new KeywordsAndProblem
                    { Problem = _problemEntity, Keyword = checkExist });
                }
            }
        }
    }
}
