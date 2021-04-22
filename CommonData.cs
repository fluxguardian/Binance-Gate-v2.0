using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkov
{
    public class CommonData : IMarketplacesData
    {
        public Dictionary<string, string> FirstMarketplace { get; set; }// SortedDictionary инфа о ценах
        public Dictionary<string, string> SecondMarketplace { get; set; }// инфа о названиях пар ( включая BTC )
        public CommonData(BaseRequestClient first, BaseRequestClient second)
        {
            FirstMarketplace = new Dictionary<string, string>();
            SecondMarketplace = new Dictionary<string, string>();

            foreach (var item1 in first.MarketPlace)
            {
                foreach (var item2 in second.MarketPlace)
                {
                    if (item1.Key == item2.Key)
                    {
                        FirstMarketplace.Add(item1.Key, item1.Value);
                        SecondMarketplace.Add(item2.Key, item2.Value);
                    }
                }
            }
        }
        public void PrintClientData()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Pair/BTC\tFirst market\t\tSecond market");
            Console.ResetColor();

            foreach (var item1 in FirstMarketplace)
            {
                foreach(var item2 in SecondMarketplace)
                {
                    if (item1.Key == item2.Key)
                    {
                        Console.WriteLine($"{item1.Key.Replace("BTC", "")}\t\t{item1.Value}\t\t{item2.Value}");
                        Console.WriteLine();
                        //break;// мб оптимизация (тип если нашел совпадение ключей - дальше нет смысла идти)
                    }                   
                }                                        
            }
        }
    }
}
