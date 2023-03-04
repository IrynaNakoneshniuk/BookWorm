using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BookWorm.DTO;
using System.Text;
using UserSecrets;

namespace BookWorm.Api
{
    public static class ApisClient
    {
        private static readonly HttpClient _httpClient = new HttpClient();


        public static async Task<T> GetData<T>(string requestUrl)
        {
            var response = await _httpClient.GetAsync(requestUrl);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                JObject obj = JObject.Parse(content);
                var parseJson = obj["results"].ToString();
                T result = JsonConvert.DeserializeObject<T>(parseJson);
                return result;
            }
            throw new Exception($"Не вдалося виконати пошук. Код статусу: {response.StatusCode}");
        }


        public static async Task<BookDto> SearchBookAsync(string query)
        {
            var apiUrl = EndPointApi.GetBaseUrlGuenbergApi() + EndPointApi.FilterByAuthorOrTitle(query);
            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                BookDto result = JsonConvert.DeserializeObject<BookDto>(content);
                return result;
            }

            throw new Exception($"Не вдалося виконати пошук. Код статусу: {response.StatusCode}");
        }


        public static async Task<List<BookDto>> GetListBookAsync()
        {
            try
            {
                return await GetData<List<BookDto>>(EndPointApi.GetBaseUrlGuenbergApi() + EndPointApi.ListOfBook());
            }
            catch (Exception ex)
            {
                throw new Exception($"Не вдалося виконати пошук");
            }
        }


        public static async Task<string> GetBookTextAsync(string bookId)
        {
            var response = await _httpClient.GetAsync(EndPointApi.GetTextBooksUrl(bookId));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }

            throw new Exception($"Не вдалося отримати текст книги. Код статусу: {response.StatusCode}");
        }


        public static async Task<List<BookDto>> GetBooksBylanguage(string language)
        {
            try
            {
                return await GetData<List<BookDto>>(EndPointApi.GetBaseUrlGuenbergApi()
                + EndPointApi.FilterByLanguages(language));
            }
            catch (Exception ex)
            {
                throw new Exception($"Не вдалося виконати пошук");
            }
        }
        public static async Task<List<TranslationResultDto>> TranslateText(string text, string fromLang, string toLang)
        {
            Object[] body = new Object[] { new { Text = text } };
            var requestBody = JsonConvert.SerializeObject(body);
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(EndPointApi.TranslatorEndPoint(fromLang, toLang));
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", Secrets.ApiKey);
                request.Headers.Add("Ocp-Apim-Subscription-Region", "westeurope");
                var response = await _httpClient.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<TranslationResultDto>>(responseBody);
                return result;
            }
        }
    }
}
