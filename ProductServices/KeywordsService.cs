using EntityMVC;
using RepositoryMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Article;

namespace ProductServices
{
    public class KeywordsService : BaceService
    {
        private Keywords _keywordsEntity;
        private KeywordRepository _repository;
        public KeywordsService()
        {
            _keywordsEntity = new Keywords();
            _repository = new KeywordRepository(dbContext);
        }

        public void SaveKeywords(int articleId, ArticleNewModel model)
        {
            //Save keywords and into n:n table.
            IList<Keywords> keywords = _keywordsEntity.GetKeywordList(model.Keywords);
            foreach (var item in keywords)
            {
                int keywordId = 0;
                Keywords temp = _repository.GetByKeyword(item);
                if (temp == null)
                {
                    _keywordsEntity = _keywordsEntity.AddNewKeyword(item);
                    keywordId = _repository.AddKeywordToDatabase(_keywordsEntity);
                }
                else
                {
                    temp = temp.AddUsed(temp);
                    keywordId = _repository.UpdateKeywordUsed(temp);
                }
                new KeywordAndArticleRepository(dbContext).AddDatabase(articleId, keywordId);
            }
        }
        public void SaveKeywords(int articleId, AritcleEditModel model)
        {
            //Save keywords and into n:n table.
            IList<Keywords> keywords = _keywordsEntity.GetKeywordList(model.Keywords);
            foreach (var item in keywords)
            {
                int keywordId = 0;
                Keywords temp = _repository.GetByKeyword(item);
                if (temp == null)
                {
                    _keywordsEntity = _keywordsEntity.AddNewKeyword(item);
                    keywordId = _repository.AddKeywordToDatabase(_keywordsEntity);
                }
                else
                {
                    temp = temp.AddUsed(temp);
                    keywordId = _repository.UpdateKeywordUsed(temp);
                }
                new KeywordAndArticleRepository(dbContext).AddDatabase(articleId, keywordId);
            }
        }
    }
}
