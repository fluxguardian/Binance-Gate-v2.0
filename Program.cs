using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Collections.Generic;

namespace Karkov
{
    class Program
    {
        // gate
        static string gateURL = "https://data.gateapi.io/api2/1/marketlist";
        static string token = "";
        static string secretToken = "";
        // binance
        static string binanceUrl = "https://api.binance.com/api/v3/ticker/price";
        static string token2 = "WJSRMFM+Rx0ottw5jxNqKblOmp/2DGs5jWN+5YunvpzdCRYszqjnfX3b";
        static string secretToken2 = "2ahfGPscAHxQ+xNTrP+FVtpuoylYGkDtKr0zE//qgPn0jBOBbbzDueLWYDdh6VbmKGllUqqxFf1XAYdRf6wQ6Q==";
        static async Task Main(string[] args)
        {
            
            BaseRequestClient BinanceUser = new BaseRequestClient(token2, secretToken2);
            BaseRequestClient GateUser = new BaseRequestClient(token2, secretToken2);

            var jsonBinance = await BinanceUser.GetRequest(binanceUrl);           
            BinanceUser.SetRequestData(jsonBinance, "symbol", "price");

            var jsonTemp = (await BinanceUser.GetRequest(gateURL))["data"];
            GateUser.SetRequestData(jsonTemp, "pair", "rate");

            CommonData Data = new CommonData(BinanceUser, GateUser);
            Data.PrintClientData();
            Thread.Sleep(50000);
        }
    }
}
