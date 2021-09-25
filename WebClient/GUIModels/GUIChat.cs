using System;
using System.Collections.Generic;
using System.Text;
using WebClient.Data;

namespace WebClient.GUIModels
{
    class GUIChat : GUIModel<DataStorage>
    {
        public override void Render()
        {
            Console.Clear();
            Console.WriteLine();
            Console.Write("************************");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{Data.SelectedChat?.Name}");
            Console.ResetColor();
            Console.WriteLine("************************");
            Console.Write($"*** Hello: ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{Data.User.Name}");
            Console.ResetColor();

            string ids = string.Empty; ;
            Data.apim.GetSubsByChatIdAsync(Data.SelectedChat.ChatId).GetAwaiter().GetResult()
                .ForEach(x=>
                {
                    ids += x.UserId;
                    ids += ",";
                });
            if (ids.Length > 0)
            {
                ids = ids.Remove(ids.Length - 1);
                Data.SelectedChatUsersList = Data.apim.GetUsersByIdsAsync(ids).GetAwaiter().GetResult();
            }
            else
            {
                Data.SelectedChatUsersList = new List<UserData>();
            }
            int counter = 0;
            if(counter%6==0)
            {              
                Console.Write($"*** Users subscribed at chat: ");
                Data.SelectedChatUsersList.ForEach(x =>
                {
                    counter++;
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(x.Name);
                    Console.ResetColor();
                    Console.Write($" | ");
                });
                Console.WriteLine();
            }



            if (Data.SelectedChat!=null)
            {
                Data.LoadSelectedChatMessages();
                ids = string.Empty;
                List<UserData> users = new List<UserData>();
                Data.MessagesSelectedChat.ForEach(x=> 
                {
                    ids += x.UserId;
                    ids += ",";
                    
                });
                if (ids.Length > 0)
                {
                    ids = ids.Remove(ids.Length - 1);
                    users = Data.apim.GetUsersByIdsAsync(ids).GetAwaiter().GetResult();
                }
                if(users.Count>0)
                {
                    users.ForEach(x=> 
                    {
                        Data.MessagesSelectedChat.ForEach(m=> 
                        {
                            if (x.UserId == m.UserId) m.SenderName = x.Name;
                        });
                    });
                }
                Data.MessagesSelectedChat.ForEach(x=>
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{x.SendDate.Hour}:{x.SendDate.Minute} ");
                    Console.ResetColor();
                    Console.Write($"Sender: {x.SenderName} -> ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{x.Data}");
                    Console.ResetColor();
                });
            }


            Console.WriteLine();
            Console.Write("************************");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{Data.SelectedChat?.Name}");
            Console.ResetColor();
            Console.WriteLine("************************");
            Console.WriteLine("Press \"ESC\" for return back");
            Console.Write(Data.writedText);
            
        }
        public GUIChat(DataStorage data) : base(data)
        {
        }
    }
}
