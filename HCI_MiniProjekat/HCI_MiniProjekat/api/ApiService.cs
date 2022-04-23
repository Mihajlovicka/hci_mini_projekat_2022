using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;

namespace HCI_MiniProjekat.api
{
    public class Value
    {
        public DateTime date { get; set; }
        public string? value { get; set; }
        
    }

    public class Responce
    {
        public static string ApiKey = "N0318KS2C23K749D";
        public string? name { get; set; }
        public string? interval { get; set ; }
        public string? unit { get; set; }
        public List<Value>? data { get; set; }
    }

    public class Inflation
    { 
        public static Responce get()
        {
            string QUERY_URL = "https://www.alphavantage.co/query?function=INFLATION_EXPECTATION&apikey=" + Responce.ApiKey;
            Uri queryUri = new Uri(QUERY_URL);

            using (WebClient client = new WebClient())
            { return JsonSerializer.Deserialize<Responce>(client.DownloadString(queryUri))!; }
        }
    }
    public class RetailSales
    {
        public static Responce get()
        {
            string QUERY_URL = "https://www.alphavantage.co/query?function=RETAIL_SALES&apikey=" + Responce.ApiKey;
            Uri queryUri = new Uri(QUERY_URL);

            using (WebClient client = new WebClient())
            { return JsonSerializer.Deserialize<Responce>(client.DownloadString(queryUri))!; }
            
        }
    }

    public class CPI
    {
        public static Responce get(string interval)
        {
            string QUERY_URL = "https://www.alphavantage.co/query?function=CPI&interval=" + interval + "&apikey=" + Responce.ApiKey;
            Uri queryUri = new Uri(QUERY_URL);

            using (WebClient client = new WebClient())
            { 
                return JsonSerializer.Deserialize<Responce>(client.DownloadString(queryUri))!;
            }

        }
    }

}
