using EntityMVC;
using RepositoryMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public int Add(ProblemNewModel model)
        {
            _problemEntity = connectedMapper.Map<Problem>(model);
            _problemEntity.Author = CurrenUser;
            _problemEntity.PublishTime = DateTime.Now;
            _problemEntity.HelpFrom = new UserRepository(dbContext).GetBy(model.HelpFrom);

            //save keywords
            new KeywordsService().SaveKeywords(model.NeedSubKeyword);

            IList<Keywords> keywords = new Keywords().GetKeywordList(model.NeedSubKeyword);
            KeywordRepository keywordRepository = new KeywordRepository(dbContext);
            _problemEntity.OwnKeyword = new List<KeywordsAndProblem>();
            foreach (var item in keywords)
            {
                _problemEntity.OwnKeyword.Select(k => k.Keyword.Name = item.Name);
            }

            //BMoney minus change
            new BMoneyService().PublishProblem(model.RewardMoney);


            return _repository.Add(_problemEntity);
        }

        public ProblemEditModel GetEditProblem(int id)
        {
            _problemEntity = _repository.GetEditProblem(id);

            ProblemEditModel problemEditModel = new ProblemEditModel();
            problemEditModel = connectedMapper.Map<ProblemEditModel>(_problemEntity);

            //BMoneyRepository moneyRepository = new BMoneyRepository(dbContext);
            //problemEditModel.HelpFrom = _problemEntity.HelpFrom.UserName;
            //problemEditModel.HasLeftMoney = new BMoneyRepository(dbContext).GetByAuthorBMoney(CurrentUserId).LeftBMoney > 0;

            var keywords = new KeywordAndProblemRepository(dbContext).GetKeywords(id);
            string keyWordOfProblem = string.Empty;
            foreach (var item in keywords)
            {
                keyWordOfProblem += item.Keyword.Name + " ";
            }
            problemEditModel.NeedSubKeyword = keyWordOfProblem;
            return problemEditModel;
        }

        public void Update(ProblemNewModel model)
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
    }
}
