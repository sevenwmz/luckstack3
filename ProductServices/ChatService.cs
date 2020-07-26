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
        public ChatRoomModel GetHistoryChat(int count)
        {
            IList<Chat> chats = new ChatRepository(dbContext).GetChatHistory(count);
            ChatRoomModel model = new ChatRoomModel
            {
                ChatRooms = connectedMapper.Map<List<ChatRoomModel>>(chats)
            };
            if (CurrentUserId != null)
            {
                model.CurrentUserId = CurrenUser.Id;
                model.UserName = CurrenUser.UserName;
                model.UserLevel = CurrenUser.Level;
            }
            return model;
        }

        public void SaveCurrentChat(ChatRoomModel chatModel)
        {
            
        }
    }
}
