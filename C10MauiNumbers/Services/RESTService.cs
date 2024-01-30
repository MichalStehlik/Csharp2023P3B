using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace C10MauiNumbers.Services
{
    internal class RESTService { 
        HttpClient _httpClient;
        JsonSerializerOptions _serializerOptions;

        public RESTService()
        {
            _httpClient = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
        }

        public async Task<string> Fetch(string param)
        {
            Result = string.Empty;
            Uri uri = new Uri(
                string.Format("http://numbersapi.com/" + param
                ));
            try
            {
                HttpResponseMessage res = 
                    await _httpClient.GetAsync(uri);
                if(res.IsSuccessStatusCode)
                {
                    string content = 
                        await 
                        res.Content.ReadAsStringAsync();
                    Result = content;
                    // Items = JsonSerializer.Deserialize<List<Item>>(content, _serializerOptions)
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return Result;
        }

        public string Result { get; set; }


    }
}
