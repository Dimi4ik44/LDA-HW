using System;
using System.Net.Http;
using System.Threading.Tasks;
using WebClient.Data;
using WebClient.GUIModels;
using System.Threading;


namespace WebClient
{
    class Application
    {
        DataStorage data = new DataStorage("http://localhost:5000");
        APIManager apim;
        

        public string UserName { get; set; }
        public void Start()
        {
            apim = new APIManager("http://localhost:5000", data);
            Console.WriteLine("Write your name");
            string name = Console.ReadLine();

            data.LoadBaseData(name);
            data.LoadSubscribedChats();

            data.SelectChat(1);
            
            new GUIMainMenu(data).Render();
            Console.WriteLine("Select chat \"Write chatId\"");
            int select;
            Int32.TryParse(Console.ReadLine(),out select);
            data.SelectChat(select);
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            Task chatGuiRefresh = new Task(()=> 
            { 
                while(!token.IsCancellationRequested)
                {
                    new GUIChat(data).Render();
                    Task.Delay(3000).Wait();
                }
            },token);
            chatGuiRefresh.Start();
            while(true)
            {
                var key = Console.ReadKey();
                data.writedText += key.KeyChar;
                if(key.Key==ConsoleKey.Enter)
                {
                    Task send = new Task(()=> 
                    {
                        data.writedText = data.writedText.Replace("\r", string.Empty);
                        data.writedText = data.writedText.Replace("\n", string.Empty);
                        try
                        {
                            data.apim.SendMessageToChatAsync(data.writedText, data.SelectedChat.ChatId).GetAwaiter().GetResult();
                            data.writedText = string.Empty;
                        }
                        catch (HttpRequestException e)
                        {
                            throw new Exception(e.Message);
                        }
                    });
                    send.Start();
                }else if(key.Key==ConsoleKey.Backspace)
                {
                    data.writedText = data.writedText.Remove(data.writedText.Length - 2);
                }
                else if(key.Key==ConsoleKey.Escape)
                {
                    source.Cancel();
                    break;
                }
            }
            new GUIMainMenu(data).Render();

            Console.ReadLine();


        }


        
        

    }
}
