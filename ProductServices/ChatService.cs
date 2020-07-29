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
    public class ChatService : BaceService
    {
        private ChatRepository _repo;

        public ChatService()
        {
            _repo = new ChatRepository(dbContext);
        }


        public ChatRoomModel GetHistoryChat(int count)
        {
            IList<Chat> chats = _repo.GetChatHistory(count);
            ChatRoomModel model = new ChatRoomModel
            {
                ChatRooms = connectedMapper.Map<List<ChatItemModel>>(chats)
            };
            model.CurrentUserId = CurrentUserId;
            return model;
        }

        public int SaveCurrentChat(ChatItemModel chatModel)
        {
            Chat newChat = connectedMapper.Map<Chat>(chatModel);
            newChat.PublishTime = DateTime.Now;
            newChat.Reply = null;
            newChat.Author = CurrenUser;

            return _repo.SaveChat(newChat);
        }

        public ChatItemModel GetChat(int id)
        {
            return connectedMapper.Map<ChatItemModel>(_repo.GetChat(id));
        }
    }
}
