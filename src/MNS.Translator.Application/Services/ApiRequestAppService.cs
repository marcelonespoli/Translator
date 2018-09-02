using MNS.Translator.Application.Interfaces;
using MNS.Translator.Application.ValueObjects;
using MNS.Translator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MNS.Translator.Application.Services
{
    public class ApiRequestAppService : IApiRequestAppService
    {
        private string _text { get; set; }
        private string _ip { get; set; }

        public TranslationRequest GetTranslation(string text)
        {
            var translationRequest = new TranslationRequest();
            _text = text;
            _ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            var url = "https://api.funtranslations.com/translate/";

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(url)
            };

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("text", _text)
            });
            
            try
            {
                HttpResponseMessage response = Task.Run(()=> httpClient.PostAsync("leetspeak.json", content)).Result;
                
                if (response.IsSuccessStatusCode)
                {
                    var readResult = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
                    var responseSuccess = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseSuccess>(readResult);
                    translationRequest = ConvertResponseSuccessToTranslationRequest(responseSuccess);
                }
                else
                {
                    var readResult = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
                    var responseError = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseError>(readResult);
                    translationRequest = ConvertResponseErrorToTranslationRequest(responseError);
                }
            }
            catch (Exception)
            {
                return null;
            }

            return translationRequest;
        }
                

        private TranslationRequest ConvertResponseSuccessToTranslationRequest(ResponseSuccess responseSuccess)
        {
            var translationRequest = new TranslationRequest
            {
                Success = true,
                Text = responseSuccess.Contents.Text,
                Translation = responseSuccess.Contents.Translated,
                Date = DateTime.Now,
                ErrorMessage = "",
                Ip = _ip
            };
            return translationRequest;
        }

        private TranslationRequest ConvertResponseErrorToTranslationRequest(ResponseError responseError)
        {
            var translationRequest = new TranslationRequest
            {
                Success = false,
                Text = _text,
                Translation = "",
                Date = DateTime.Now,
                ErrorMessage = $"[Code: {responseError.Error.Code}] - {responseError.Error.Message}",
                Ip = _ip
            };
            return translationRequest;
        }
    }
}
