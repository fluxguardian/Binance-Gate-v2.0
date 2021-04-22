using System.Collections.Generic;


namespace Karkov
{
    interface IMarketplacesData
    {
        public Dictionary<string, string> FirstMarketplace { get; set; }// SortedDictionary инфа о ценах
        public Dictionary<string, string> SecondMarketplace { get; set; }// инфа о названиях пар ( включая BTC )
        public void PrintClientData();
    }
}
