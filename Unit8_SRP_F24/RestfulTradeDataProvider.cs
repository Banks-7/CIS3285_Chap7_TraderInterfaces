
using System;
using System.Text.Json;
using Unit8_SRP_F24.Contracts;

namespace Unit8_SRP_F24;

public class RestfulTradeDataProvider : ITradeDataProvider
{
    string url;
    ILogger logger;

    public RestfulTradeDataProvider(string url, ILogger logger)
    {
        this.url = url;
        this.logger = logger;
    }

    public IEnumerable<string> ReadTradeData()
    {
        logger.LogMessage("Reading trade data from Restful API: " + url);

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = client.GetAsync(url).Result;

            response.EnsureSuccessStatusCode();

            string jsonData = response.Content.ReadAsStringAsync().Result;

            List<string>? tradeData = JsonSerializer.Deserialize<List<string>>(jsonData);

            return tradeData ?? new List<string>();
        }
    }
}
