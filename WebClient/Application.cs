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

namespace WebClient
{
    class Application
    {
        HttpClient client = new HttpClient();
        UriBuilder ub = new UriBuilder("http://localhost:5000");
        UserData userData = new UserData();
        List<ChatData> chats = new List<ChatData>();
        JsonSerializerOptions serializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };



        public string UserName { get; set; }
        public async void Start()
        {
            string name = Console.ReadLine();
            Task GetOrCreateUser = new Task(() =>
            {
                try
                {
                    userData = GetUserByNameAsync($"{name}").GetAwaiter().GetResult();
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
                    chats = GetChatsAsync().GetAwaiter().GetResult();
                }
                catch (HttpRequestException e)
                {
                    throw new Exception(e.Message);
                }
            });

            GetOrCreateUser.Start();
            getChats.Start();

            Console.ReadLine();
            try
            {
                Task sendMessage = SendMessageToChatAsync("TestMessageClient", 1);
            }
            catch(HttpRequestException e)
            {
                throw new Exception(e.Message);
            }
            Console.ReadLine();


        }


        
        public async Task<UserData> CreateUserAsync(UserDto user)
        {
            UriBuilder uriBuilder = new UriBuilder(ub.Uri.ToString());
            uriBuilder.Path = "user/add";
            using (StringContent stringContext = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage response = await client.PostAsync(uriBuilder.Uri, stringContext))
                {
                    Console.WriteLine(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                    if(response.StatusCode == HttpStatusCode.OK)
                    {
                        Console.WriteLine("UserAdd");
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

                Console.WriteLine(response.StatusCode);
                if(response.StatusCode == HttpStatusCode.OK)
                {
                    Console.WriteLine("UserFound");
                    return JsonSerializer.Deserialize<UserData>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult(), serializeOptions);
                    
                }
                else if(response.StatusCode == HttpStatusCode.NoContent)
                {
                    UserDto user = new UserDto() { Name = $"{name}" };
                    return CreateUserAsync(user).GetAwaiter().GetResult();
                }
                else throw new Exception("Problem getting user by name");
                
            }
                
        }

        public async Task<List<ChatData>> GetChatsAsync()
        {
            UriBuilder uriBuilder = new UriBuilder(ub.Uri.ToString());
            uriBuilder.Path = $"chat";
            using (HttpResponseMessage response = await client.GetAsync(uriBuilder.Uri))
            {

                Console.WriteLine(response.StatusCode);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Console.WriteLine("ChatsGetSeccesful");
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
        public async Task SendMessageToChatAsync(string message, int chatId)
        {
            {
                MessageDto mess = new MessageDto() { ChatId = chatId, Data = message, UserId = userData.UserId };
                UriBuilder uriBuilder = new UriBuilder(ub.Uri.ToString());
                uriBuilder.Path = "message/send";
                using (StringContent stringContext = new StringContent(JsonSerializer.Serialize(message), Encoding.UTF8, "application/json"))
                {
                    using (HttpResponseMessage response = await client.PostAsync(uriBuilder.Uri, stringContext))
                    {
                        Console.WriteLine(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            Console.WriteLine("MessageSendSecces");
                        }
                        else throw new Exception($"Problem sending message to {mess.ChatId} : {mess.Data}");
                    }

                }
            }

        }

    }
}
