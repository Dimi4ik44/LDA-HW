using System;
using System.Collections.Generic;
using System.Text;
using WebClient.Data;

namespace WebClient.GUIModels
{
    class GUIMainMenu : GUIModel<DataStorage>
    {
        public override void Render()
        {
            Console.Clear();
            Console.Write("************************");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Welcome To WebAPIChhat");
            Console.ResetColor();
            Console.WriteLine("************************");
            Console.Write($"*** Hello: ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{Data.User.Name}");
            Console.ResetColor();
            Console.Write($"*** Active Chats ->");
            int counter = 0;
            foreach (ChatData chat in Data.Chats)
            {
                counter++;
                if (counter%4==0)
                {
                    Console.WriteLine();
                    Console.Write($"*** Active Chats ->");
                }
                Console.Write($" Chat ID: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{chat.ChatId}");
                Console.ResetColor();
                Console.Write($" : ");
                Console.Write($"Chat Name: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{chat.Name}");
                Console.ResetColor();
                Console.Write($" | ");
                
            }
            int countersu = 0;
            Console.WriteLine();
            Console.Write($"*** YOU Subscribed on->");
            foreach (ChatData sub in Data.SubscribedChats)
            {
                countersu++;
                if (countersu % 4 == 0)
                {
                    Console.WriteLine();
                    Console.Write($"*** YOU Subscribed on->");
                }
                Console.Write($" Chat ID: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{sub.ChatId}");
                Console.ResetColor();
                Console.Write($" : ");
                Console.Write($"Chat Name: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{sub.Name}");
                Console.ResetColor();
                Console.Write($" | ");

            }
            Console.WriteLine();
            Console.Write("************************");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Welcome To WebAPIChhat");
            Console.ResetColor();
            Console.WriteLine("************************");
        }
        public GUIMainMenu(DataStorage data) : base(data)
        {
        }
    }
}
