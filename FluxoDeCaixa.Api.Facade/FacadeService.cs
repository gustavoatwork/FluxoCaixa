using FluxoDeCaixa.Api.Facade.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Api.Facade
{
    internal class FacadeService : IFacadeService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public FacadeService(
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public async Task<string> Get(string path, string payload, string serviceName)
        {
            path = string.Format(path, payload);
            return await SendRequest(path, payload, HttpMethod.Get, serviceName);
        }

        public async Task<string> Post(string path, object payload, string serviceName)
        {
            return await SendRequest(path, payload, HttpMethod.Post, serviceName);
        }

        private Dictionary<string, string> GetHeaders()
        {
            var dic = new Dictionary<string, string>
            {
                { "Authorization", _httpContextAccessor.HttpContext.Request.Headers["Authorization"] }
            };

            return dic;
        }

        private async Task<string> SendRequest(string path, object payload, HttpMethod method, string serviceName)
        {
            try
            {
                using HttpClient httpClient = _httpClientFactory.CreateClient();
                httpClient.BaseAddress = Configuration.GetBaseAddress(serviceName);
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

                var headers = GetHeaders();

                var httpRequestMessage = GetHttpRequestMessage(httpClient, headers, httpContent, method, path);

                var response = await httpClient.SendAsync(httpRequestMessage);

                var responseString = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"ErrorMessage: {responseString} StatusCode: {response.StatusCode}");

                return responseString;
            }
            catch (Exception e)
            {

                throw new Exception($"Erro na requisição - {e.Message}");
            }
        }




        private HttpRequestMessage GetHttpRequestMessage(
            HttpClient httpClient,
            Dictionary<string, string> headers,
            HttpContent httpContent,
            HttpMethod httpMethod,
            string path)
        {
            var httpRequest = new HttpRequestMessage
            {
                Method = httpMethod,
                Content = httpContent,
                RequestUri = new Uri(httpClient.BaseAddress + path)
            };

            foreach (var item in headers)
                if (!string.IsNullOrEmpty(item.Value))
                    httpRequest.Headers.Add(item.Key, item.Value);

            return httpRequest;
        }
    }
}
