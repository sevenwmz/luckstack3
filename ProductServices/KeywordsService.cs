using EntityMVC;
using RepositoryMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModel;
using ViewModel.Article;
using ViewModel.Problem;

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

        public IList<SelectListItem> GetDropDownList(bool fristKeyword = false)
        {
            IList<SelectListItem> tempKeyword = new List<SelectListItem>();
            IList<Keywords> keywords = new List<Keywords>();

            keywords = _repository.GetLevelKeywords(fristKeyword);
            foreach (var item in keywords)
            {
                tempKeyword.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }
            return tempKeyword;
        }

        public void SaveKeywords(string needSubKeyword)
        {
            IList<Keywords> keywords = new Keywords().GetKeywordList(needSubKeyword);
            Keywords saveKeyword = new Keywords();
            KeywordRepository keywordRepository = new KeywordRepository(dbContext);
            foreach (var item in keywords)
            {
                saveKeyword = keywordRepository.GetByKeyword(item);
                if (saveKeyword == null)
                {
                    saveKeyword = saveKeyword.AddNewKeyword(item);
                    keywordRepository.AddKeywordToDatabase(saveKeyword);
                }
                else
                {
                    saveKeyword = saveKeyword.AddUsed(saveKeyword);
                    keywordRepository.UpdateKeywordUsed(saveKeyword);
                }
            }
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
