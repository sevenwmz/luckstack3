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
using ViewModel.ChildAction;
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

        /// <summary>
        /// For ajax refresh secend keyword
        /// </summary>
        /// <param name="fristKeywordId">need frist keyword id</param>
        /// <returns>return model</returns>
        public _SecendKeywordModel GetSecendKeywordBy(int fristKeywordId)
        {
            return new _SecendKeywordModel
            {
                Items = Mapper.Map<List<_SecendKeywordItem>>(_repository.GetSecendKeywordBy(fristKeywordId))
            };
        }

        public ChildKeywordModel GetChildKeywords(int takeKeywordPage)
        {
            KeywordRepository repo = new KeywordRepository(dbContext);
      
            ChildKeywordModel childKeyword = new ChildKeywordModel
            {
                Item = Mapper.Map<List<KeywordModel>>(repo.GetChildKeyword(takeKeywordPage))
            };

            return childKeyword;

        }

        public void SaveKeywords(string needSubKeyword)
        {
            IList<Keywords> keywords = new Keywords().GetKeywordList(needSubKeyword);
            foreach (var item in keywords)
            {
                _keywordsEntity = _repository.GetByKeyword(item);
                if (_keywordsEntity == null)
                {
                    _keywordsEntity = new Keywords().AddNewKeyword(item);
                    _repository.AddKeywordToDatabase(_keywordsEntity);
                }
                else
                {
                    _keywordsEntity = _keywordsEntity.AddUsed(_keywordsEntity);
                    _repository.UpdateKeywordUsed(_keywordsEntity);
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
