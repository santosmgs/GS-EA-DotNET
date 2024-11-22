using System.Text;
using Newtonsoft.Json;

namespace EnergyAwareness.Services
{
    public class LlamaService
    {
        private readonly HttpClient _httpClient;
        private readonly string _llamaApiUrl = "https://api.llama.com/query";

        public LlamaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> QueryLlamaAsync(string prompt)
        {
            var requestBody = new
            {
                model = "Llama-2-13b-chat",
                prompt = prompt,
                max_tokens = 50
            };

            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_llamaApiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                dynamic responseObject = JsonConvert.DeserializeObject(result);
                return responseObject?.choices[0]?.text.ToString();
            }

            return "Erro ao consultar IA Llama.";
        }
    }
}