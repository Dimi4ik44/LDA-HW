using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HW13_16
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            Dictionary<int, List<Person>> groptByAge = new Dictionary<int, List<Person>>();
            Random rnd = new Random();
            List<string> existNames = new List<string>();
            List<string> nameList = new List<string>() {"John","Andrew","Jui","Josh","Terri", "Liam", "Noah","Oliver","Olivia",
            "Emma","Ava","Charlotte","Elijah","Henry","Lucas","Mia","Issabella"};
            using (StreamWriter sw = new StreamWriter("File.txt"))
            {
                for (int i = 0; i < 5; i++)
                {                   
                    sw.WriteLine($"{nameList[rnd.Next(nameList.Count)]+rnd.Next(100)}:{rnd.Next(1,100)}");
                }
            }
            using (StreamReader sr = new StreamReader("File.txt"))
            {
                string sa = sr.ReadToEnd();
                foreach (string item in sa.Split('\n'))
                {
                    if(item != string.Empty)
                    {
                        string[] spl = item.Split(':');
                        if(!Int32.TryParse(spl[1], out int age))
                        {
                            throw new Exception("Age cant parsed");
                        }
                        persons.Add(new Person(spl[0],age));
                    }
                }
            }

            persons.ForEach(x => 
            { 
                if(!existNames.Contains(x.Name))
                {
                    existNames.Add(x.Name);
                }
            });

            var a = persons.GroupBy(x => x.Age).ToList();
            var b = a.Where(x => x.Key < 14 || x.Key > 79).ToList();
            using (StreamWriter sw = new StreamWriter("File.txt",true))
            {
                sw.WriteLine("Age:Names");
                a.ForEach(x=> { 
                    sw.WriteLine($"Age:{x.Key}");
                    sw.Write("   ");
                    x.ToList().ForEach(x=>sw.Write($"{x.Name} "));
                    sw.WriteLine();
                });
            }
            using (StreamWriter sw = new StreamWriter("Result.txt"))
            {
                var max = a.Max(x=>x.ToList().Count);
                var min = a.Min(x => x.ToList().Count);
                var average = Math.Round(a.Average(x => x.ToList().Count));
                var lessThan14AndMoreThen79 = 0;
                List<string> popular = new List<string>();
                List<string> rare = new List<string>();
                List<string> aver = new List<string>();
                a.ForEach(x => 
                { 
                    if (x.ToList().Count == max)
                    {
                        popular.Add($"{x.Key}");
                    }
                    if (x.ToList().Count == min)
                    {
                        rare.Add($"{x.Key}");
                    }
                    if (x.ToList().Count == average)
                    {
                        aver.Add($"{x.Key}");
                    }
                });
                sw.WriteLine($"Matches:{max} - Popular age:");
                popular.ForEach(x=>sw.Write($"{x} "));
                sw.WriteLine();
                sw.WriteLine($"Matches:{min} - Rare age: ");
                rare.ForEach(x => sw.Write($"{x} "));
                sw.WriteLine();
                sw.WriteLine($"Matches:{average} - Average age: ");
                aver.ForEach(x => sw.Write($"{x} "));
                sw.WriteLine();
                b.ForEach(x=>lessThan14AndMoreThen79 += x.ToList().Count);
                sw.WriteLine($"lessThan14AndMoreThen79: {lessThan14AndMoreThen79}");
            }
            b = a.Where(x => x.Key > 14 || x.Key < 79).ToList();
            WebClient wc = new WebClient();
            List<string> names = new List<string>();
            b.ForEach(x=>x.ToList().ForEach(x=> 
            { 
                if(!names.Contains(x.Name))
                {
                    names.Add(x.Name);
                }
            }));
            string data = string.Empty;
            names.ForEach(x=>data+=$"{x},");
            if(data[data.Length-1]==',')
            {
                data = data.Remove(data.Length-1);
            }
            wc.AddAsync(data).GetAwaiter().GetResult();





        }
    }
}
