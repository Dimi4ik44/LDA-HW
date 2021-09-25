using System;
using System.Net.Http;
using System.Threading.Tasks;
using WebClient.Data;
using WebClient.GUIModels;
using System.Threading;


namespace WebClient
{
    public enum AppState
    {
        MainMenu = 0,
        ChatMenu,
        Exit
    }
    class Application
    {
        DataStorage data = new DataStorage("http://localhost:5000");
        AppState appState = AppState.MainMenu;
        

        public string UserName { get; set; }
        public void Start()
        {
            Console.WriteLine("Write your name");
            string name = Console.ReadLine();

            data.LoadBaseData(name);
            data.LoadSubscribedChats();
            data.SelectChat(1);
            while (applieState())
            {
               
            }    
               
            
        }
        public bool applieState()
        {
            switch (appState)
            {
                case AppState.MainMenu:
                    new GUIMainMenu(data).Render();
                    Console.WriteLine("Select chat \"Write chatId\" else write -1 to exit");
                    int select;
                    Int32.TryParse(Console.ReadLine(), out select);
                    if(select == -1)
                    {
                        appState = AppState.Exit;
                        return true;
                    }
                    data.SelectChat(select);
                    if (!data.SelectedChatIsNotNull())
                    {
                        return true;
                    }
                    appState = AppState.ChatMenu;
                    return true;
                case AppState.ChatMenu:
                    if (!data.SelectedChatIsNotNull())
                    {
                        appState = AppState.MainMenu;
                        return true;
                    }
                    CancellationTokenSource source = new CancellationTokenSource();
                    CancellationToken token = source.Token;
                    Task chatGuiRefresh = new Task(() =>
                    {
                        while (!token.IsCancellationRequested)
                        {
                            new GUIChat(data).Render();
                            Task.Delay(3000).Wait();
                        }
                    }, token);
                    chatGuiRefresh.Start();
                    data.writedText = string.Empty;
                    while (true)
                    {
                        var key = Console.ReadKey();
                        data.writedText += key.KeyChar;
                        if (key.Key == ConsoleKey.Enter)
                        {
                            string temp = data.writedText.Trim();
                            temp = temp.Replace("\r", string.Empty);
                            temp = temp.Replace("\n", string.Empty);
                            if(temp.Length > 0)
                            {
                                Task send = new Task(() =>
                                {

                                    try
                                    {
                                        data.apim.SendMessageToChatAsync(temp, data.SelectedChat.ChatId).GetAwaiter().GetResult(); 
                                    }
                                    catch (HttpRequestException e)
                                    {
                                        throw new Exception(e.Message);
                                    }
                                    finally
                                    {
                                        data.writedText = string.Empty;
                                    }
                                });
                                send.Start();
                            }                           
                        }
                        else if (key.Key == ConsoleKey.Backspace)
                        {
                            if(data.writedText.Length >= 3)
                            {
                                data.writedText = data.writedText.Remove(data.writedText.Length - 2);
                            }
                            
                        }
                        else if (key.Key == ConsoleKey.Escape)
                        {
                            source.Cancel();
                            appState = AppState.MainMenu;
                            break;
                        }
                        else if(key.Key == ConsoleKey.F1)
                        {
                            data.apim.SubscribeOnChatAsync().GetAwaiter().GetResult();
                        }
                    }
                    return true;
                case AppState.Exit:

                    return false;
                default:
                    throw new Exception("Bad app state");
            }
        }





    }
}
