using EntityMVC;
using RepositoryMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Message;

namespace ProductServices
{
    public class MessageMineService : BaceService
    {
        private MessageMineRepository _repo;
        public MessageMineService()
        {
            _repo = new MessageMineRepository(dbContext);
        }


        public MineModel GetMessage(int pageIndex, int pageSize)
        {
            IList<MessageMine> tempMessageMine = new List<MessageMine>();

            tempMessageMine = new MessageMineRepository(dbContext).GetMessage(pageSize, pageIndex);
            MineModel messageMine = new MineModel
            {
                Items = Mapper.Map<List<MineModel>>(tempMessageMine),
            };
            return messageMine;
        }

        public int GetCurrentUserMessageCount()
        {
            return new MessageMineRepository(dbContext).MessageCount(CurrentUserId.Value);
        }

        public void ChangeHasRead(int id)
        {
            new MessageMineRepository(dbContext).GetFindMessage(id).HasRead = true;
        }

        public void RemoveMessage(int id)
        {
            MessageMineRepository repo = new MessageMineRepository(dbContext);
            repo.RemoveMessage(repo.GetFindMessage(id));
        }

        public bool HasNewMessage()
        {
            if (!CurrentUserId.HasValue)
            {
                return false;
            }
            IList<MessageMine> messages = _repo.HasNewMessage(CurrentUserId.Value);

            bool result = false;
            foreach (var item in messages)
            {
                if (!item.HasRead)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}
