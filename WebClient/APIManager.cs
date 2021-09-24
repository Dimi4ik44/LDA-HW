using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using ServerAPI.DTO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using WebClient.Data;
using ServerAPI.Models;

namespace WebClient.Data
{
    class APIManager
    {
        public DataStorage data { get; set; }
        public HttpClient client { get; set; }
        UriBuilder ub;
        JsonSerializerOptions serializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        public APIManager(string uri,DataStorage _data,JsonSerializerOptions options = null)
        {
            client = new HttpClient();
            ub = new UriBuilder(uri);
            options = options == null ?
            new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            } : options;
            data = _data;
        }
        public async Task<UserData> CreateUserAsync(UserDto user)
        {
            UriBuilder uriBuilder = new UriBuilder(ub.Uri.ToString());
            uriBuilder.Path = "user/add";
            using (StringContent stringContext = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage response = await client.PostAsync(uriBuilder.Uri, stringContext))
                {
                    //Console.WriteLine(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        //Console.WriteLine("UserAdd");
                        return GetUserByNameAsync(user.Name).GetAwaiter().GetResult();
                    }
                    else throw new Exception("Problem creating user");
                }

            }
        }
        public async Task<UserData> GetUserByNameAsync(string name)
        {
            UriBuilder uriBuilder = new UriBuilder(ub.Uri.ToString());
            uriBuilder.Path = $"user/byname/{name}";

            using (HttpResponseMessage response = await client.GetAsync(uriBuilder.Uri))
            {

                //Console.WriteLine(response.StatusCode);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //Console.WriteLine("UserFound");
                    return JsonSerializer.Deserialize<UserData>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult(), serializeOptions);

                }
                else if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    UserDto user = new UserDto() { Name = $"{name}" };
                    return CreateUserAsync(user).GetAwaiter().GetResult();
                }
                else throw new Exception("Problem getting user by name");

            }

        }
        public async Task<List<UserData>> GetUsersByIdsAsync(string idlist)
        {
            UriBuilder uriBuilder = new UriBuilder(ub.Uri.ToString());
            uriBuilder.Path = $"user/arrayid/{idlist}";
            using (HttpResponseMessage response = await client.GetAsync(uriBuilder.Uri))
            {

                //Console.WriteLine(response.StatusCode);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //Console.WriteLine("UsersByListIdSeccesful");
                    return JsonSerializer.Deserialize<List<UserData>>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult(), serializeOptions);

                }
                else if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    Console.WriteLine("ChatsByListIdGetNoContent");
                    return new List<UserData>();
                }
                else throw new Exception("Problem getting UsersByListId");

            }

        }

        public async Task<List<ChatData>> GetChatsAsync()
        {
            UriBuilder uriBuilder = new UriBuilder(ub.Uri.ToString());
            uriBuilder.Path = $"chat";
            using (HttpResponseMessage response = await client.GetAsync(uriBuilder.Uri))
            {

                //Console.WriteLine(response.StatusCode);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //Console.WriteLine("ChatsGetSeccesful");
                    return JsonSerializer.Deserialize<List<ChatData>>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult(), serializeOptions);

                }
                else if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    Console.WriteLine("ChatsGetNoContent");
                    return new List<ChatData>();
                }
                else throw new Exception("Problem getting user by name");

            }

        }
        public async Task<List<ChatData>> GetChatsByIdsAsync(string idlist)
        {
            UriBuilder uriBuilder = new UriBuilder(ub.Uri.ToString());
            uriBuilder.Path = $"chat/arrayid/{idlist}";
            using (HttpResponseMessage response = await client.GetAsync(uriBuilder.Uri))
            {

                //Console.WriteLine(response.StatusCode);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //Console.WriteLine("ChatsByListIdSeccesful");
                    return JsonSerializer.Deserialize<List<ChatData>>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult(), serializeOptions);

                }
                else if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    Console.WriteLine("ChatsByListIdGetNoContent");
                    return new List<ChatData>();
                }
                else throw new Exception("Problem getting ChatsByListId");

            }

        }

        public async Task<List<SubscriptionsData>> GetSubsByUserIdAsync(int userid)
        {
            UriBuilder uriBuilder = new UriBuilder(ub.Uri.ToString());
            uriBuilder.Path = $"subscriptions/byuser/{userid}";
            using (HttpResponseMessage response = await client.GetAsync(uriBuilder.Uri))
            {

                //Console.WriteLine(response.StatusCode);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //Console.WriteLine("SubsSeccesful");
                    return JsonSerializer.Deserialize<List<SubscriptionsData>>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult(), serializeOptions);

                }
                else if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    Console.WriteLine("SubsGetNoContent");
                    return new List<SubscriptionsData>();
                }
                else throw new Exception("Problem getting user Subs by ID");

            }

        }
        public async Task<List<MessageData>> GetMessagesByChatIdAsync(int id)
        {
            UriBuilder uriBuilder = new UriBuilder(ub.Uri.ToString());
            uriBuilder.Path = $"message/chat/{id}";

            using (HttpResponseMessage response = await client.GetAsync(uriBuilder.Uri))
            {

                //Console.WriteLine(response.StatusCode);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //Console.WriteLine("MessagesFound");
                    return JsonSerializer.Deserialize<List<MessageData>>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult(), serializeOptions);

                }
                else if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return new List<MessageData>();
                }
                else throw new Exception("Problem getting messages by chatId");

            }

        }
        public async Task SendMessageToChatAsync(string message, int chatId)
        {
            {
                MessageDto mess = new MessageDto() { ChatId = chatId, Data = message, UserId = data.User.UserId };
                if (mess.Data == "")
                {
                    throw new Exception($"Message is Empty");
                }
                UriBuilder uriBuilder = new UriBuilder(ub.Uri.ToString());
                uriBuilder.Path = "message/send";
                using (StringContent stringContext = new StringContent(JsonSerializer.Serialize(mess), Encoding.UTF8, "application/json"))
                {
                    using (HttpResponseMessage response = await client.PostAsync(uriBuilder.Uri, stringContext))
                    {
                        //Console.WriteLine(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            //Console.WriteLine("MessageSendSecces");
                        }
                        else throw new Exception($"Problem sending message to {mess.ChatId} : {mess.Data}");
                    }

                }
            }

        }
    }
}
