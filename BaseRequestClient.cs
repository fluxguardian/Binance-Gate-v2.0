﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Karkov
{
    public class BaseRequestClient : IClientData
    {
        public SortedDictionary<string, string> MarketPlace { get; set; }
        public HttpClient Client { get; set; }
        public string Token { get; set; } 
        public string SecretToken { get; set; } 
        public BaseRequestClient(string token, string secretToken)
        {
            MarketPlace = new SortedDictionary<string, string>();

            Client = new HttpClient();
            Client.DefaultRequestHeaders.Add("apiKey", token);
            Client.DefaultRequestHeaders.Add("secretKey", secretToken);
        }

        public async Task<JToken> GetRequest(string url)
        {
            var response = Client.GetStringAsync(url);
            var json = (JToken)JsonConvert.DeserializeObject(await response);
            
            return json;
        }

        public void PrintClientData()
        {
            foreach (var v in MarketPlace)
            {
                Console.WriteLine("Pars: " + v.Key);
                Console.WriteLine("Price:" + v.Value);
                Console.WriteLine();
            }
        }

        public void SetRequestData(JToken jsonList, string key, string value)
        {
            foreach (var item in jsonList)
            {
                if (item[key].ToString().ToUpper().EndsWith("BTC"))
                {
                     MarketPlace.Add(
                        item[key].ToString().Replace("_", "").ToUpper(),
                        item[value].ToString());
                }
            }
        }     
    }
}
