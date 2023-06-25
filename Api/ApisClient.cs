using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BookWorm.DTO;
using System.Text;
using UserSecrets;
using System.Windows;


namespace BookWorm.Api
{
    public static class ApisClient
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task<T> GetData<T>(string requestUrl)
        {
            try
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
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            throw new Exception("No data found");
        }


        public static async Task<List<BookDto>> SearchBookAsync(string query)
        {
            try
            {
                return await GetData<List<BookDto>>(EndPointApi.GetBaseUrlGuenbergApi() 
                    +EndPointApi.FilterByAuthorOrTitle(query));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }


        public static async Task<List<BookDto>> GetListBookAsync()
        {
            try
            {
                return await GetData<List<BookDto>>(EndPointApi.GetBaseUrlGuenbergApi() + EndPointApi.ListOfBook());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }


        public static async Task<string> GetBookTextAsync(string bookId)
        {
            try
            {
                var response = await _httpClient.GetAsync(EndPointApi.GetTextBooksUrl(bookId));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return content;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            return null;
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
                MessageBox.Show(ex.Message);
            }
            return null;
        }
        public static async Task<List<TranslationResultDto>> TranslateTextAsync(string text, string fromLang, string toLang)
        {
            Object[] body = new Object[] { new { Text = text } };
            try
            {
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
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
    }
}
