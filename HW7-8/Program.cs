using System;
using HW7_8.Products;

namespace HW7_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Product p = new Fruit("s",DateTime.Now,2,100,100,null);
            Console.WriteLine(p._Brand.Name);
            Random rnd = new Random();
            Shop[] shops = new Shop[3];
            Positions positions = new Positions(new Position[] {
            new Position("Janitor",50),
            new Position("Cashier",100),
            new Position("Administrator",200),
            new Position("Manager",150),
            new Position("Curier",40),
            //new Position("Owner",77777),
            });

            for (int i = 0; i < shops.Length; i++)
            {
                shops[i] = InitShop(i,"RandName"+i,i,i,positions);
            }
        }
        static public Shop InitShop(int id, string name,int countOfStocks, int countOfShowCases, Positions positions)
        {
            Employee[] employees = new Employee[5] {
                new Employee("Vasya", 20, "I am Vasya", positions.GetPositionById(0)),
                new Employee("Petya", 23, "I am Petya", positions.GetPositionById(1)),
                new Employee("Masha", 18, "I am Masha", positions.GetPositionById(2)),
                new Employee("Olya", 19, "I am Olya", positions.GetPositionById(3)),
                new Employee("Ahmed", 33, "I am Ahmed", positions.GetPositionById(4)),
            };
            StockRoom[] stocks = new StockRoom[countOfStocks];
            for (int i = 0; i < stocks.Length; i++)
            {
                stocks[i] = new StockRoom(i);
            }
            ShowCase[] showCases = new ShowCase[countOfShowCases];
            for (int i = 0; i < showCases.Length; i++)
            {
                showCases[i] = new ShowCase(i);
            }
            return new Shop(id,name,employees,stocks,showCases, positions);
        }
    }
}
