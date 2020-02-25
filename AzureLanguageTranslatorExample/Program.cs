using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace AzureLanguageTranslatorExample
{
    
    class Program
    {
        private const string TRANSLATOR_SUBSCRIPTION_KEY = "";
        private const string TRANSLATOR_ENDPOINT = "";
        private static readonly string subscriprionKey = "a690eef67c4c4d08bfd44c0a27b78502";
        private static readonly string endPoint = "https://api.cognitive.microsofttranslator.com";


        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //string route = "/translate?api-version=3.0&to=ru&to=it";
            string route = "/translate?api-version=3.0&to=zh-Hant&toScript=Latn";
            Console.WriteLine("Введите фразу, которую хотите перевести");
            string inputText = Console.ReadLine();
            inputText = "You are really cool programmers and I hope that you'll do you best to realize you potential.";
            await TranslateTextAsync(subscriprionKey, endPoint, route, inputText);
            Console.ReadLine();
        }

        public static async Task TranslateTextAsync(string subscriptionKey, 
            string endPoint, string route, string inputText)
        {
            object[] body = new object[] { new { Text = inputText } };
            var requestBody = JsonConvert.SerializeObject(body);
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(endPoint + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                HttpResponseMessage httpResponse = await client.SendAsync(request).ConfigureAwait(false);
                string result = await httpResponse.Content.ReadAsStringAsync();
                TranslationResult[] deserializedOutput = JsonConvert.DeserializeObject<TranslationResult[]>(result);
                foreach (TranslationResult res in deserializedOutput)
                {
                    Console.WriteLine($"Обнаружен язык {res.DetectedLanguage.Language} с достоверностью {res.DetectedLanguage.Score}");
                    foreach (Translation translation in res.Translations)
                    {
                        Console.WriteLine($"Перевод на {translation.To}: {translation.Text}");
                    }
                }
            }
        }
    }
}
