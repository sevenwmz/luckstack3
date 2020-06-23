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
    }
}
