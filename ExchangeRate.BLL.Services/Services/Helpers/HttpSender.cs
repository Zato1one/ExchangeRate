using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.BLL.Services.Services.Helpers
{
    public static class HttpSender
    {
        public static async Task<string> SendUrl(string url)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    throw new Exception();
                }
            }
        }
    }
}
