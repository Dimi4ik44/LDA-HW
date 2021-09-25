using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.Data
{
    class DataStorage
    {
        public UserData User { get; set; }
        public List<ChatData> Chats { get; set; }
        public List<ChatData> SubscribedChats { get; set; }
        public ChatData SelectedChat { get; set; }
        public List<MessageData> MessagesSelectedChat { get; set; }
        public APIManager apim { get; set; }
        public string writedText { get; set; }
        public DataStorage(string apimanagerUri)
        {
            apim = new APIManager(apimanagerUri, this);
            User = new UserData();
            Chats = new List<ChatData>();
            SubscribedChats = new List<ChatData>();
            MessagesSelectedChat = new List<MessageData>();
            SelectedChat = null;
        }
        public async void LoadBaseData(string username)
        {
            Task GetOrCreateUser = new Task(() =>
            {
                try
                {
                    User = apim.GetUserByNameAsync($"{username}").GetAwaiter().GetResult();
                }
                catch (HttpRequestException e)
                {
                    throw new Exception(e.Message);
                }
            });
            Task getChats = new Task(() =>
            {
                try
                {
                    Chats = apim.GetChatsAsync().GetAwaiter().GetResult();
                }
                catch (HttpRequestException e)
                {
                    throw new Exception(e.Message);
                }
            });
            GetOrCreateUser.Start();
            getChats.Start();
            Task.WhenAll(GetOrCreateUser, getChats).Wait();
        }
        public async void LoadSubscribedChats()
        {
            Task getSubsByUserId = new Task(() =>
            {
                string ids = string.Empty;
                try
                {
                    apim.GetSubsByUserIdAsync(User.UserId).GetAwaiter().GetResult().ForEach(x =>
                    {
                        ids += x.ChatId;
                        ids += ",";
                    });
                    if (ids.Length > 0)
                    {
                        ids = ids.Remove(ids.Length - 1);
                        SubscribedChats = apim.GetChatsByIdsAsync(ids).GetAwaiter().GetResult();
                    }
                    else
                    {
                        SubscribedChats = new List<ChatData>();
                    }
                }
                catch (HttpRequestException e)
                {
                    throw new Exception(e.Message);
                }
            });
            getSubsByUserId.Start();
            getSubsByUserId.Wait();
        }
        public async void LoadSelectedChatMessages()
        {
            Task getMessages = new Task(() =>
            {
                try
                {
                    MessagesSelectedChat = apim.GetMessagesByChatIdAsync(SelectedChat.ChatId).GetAwaiter().GetResult();
                }
                catch (HttpRequestException e)
                {
                    throw new Exception(e.Message);
                }
            });
            getMessages.Start();
            getMessages.Wait();
        }
        public void SelectChat(int chatId)
        {
            if(Chats.Count > 0)
            {
                SelectedChat = Chats.Where(x => x.ChatId == chatId).FirstOrDefault();
            }
            
        }
        public bool SelectedChatIsNotNull()
        {
            if(SelectedChat != null)
            {
                return true;
            }
            return false;
        }

    }
}
