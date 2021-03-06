﻿using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using Serilog;
using Quote2Invoice.UI.Models.Security.Authenticate.ResponseModels;

namespace Quote2Invoice.UI.Shared.WebApiCaller
{
  public interface IWebApiCaller
  {
    T PostAsync<T>(string url, object content);
  }

  public class WebApiCaller : IWebApiCaller
  {
    protected IConfiguration Configuration;
    protected ICookieHelper CookieHelper;
    protected ISecurityHelper SecurityHelper;

    protected MockWebApi MockWebApi;

    public WebApiCaller(IConfiguration configuration, ICookieHelper cookieHelper, ISecurityHelper securityHelper)
    {
      Configuration = configuration;
      CookieHelper = cookieHelper;
      SecurityHelper = securityHelper;
    }

    public T PostAsync<T>(string urlConfig, object requestModel)
    {
      if (Convert.ToBoolean(Configuration["MockData.Enabled"]))
      {
        MockWebApi = new MockWebApi();

        var incoming = JsonConvert.SerializeObject(requestModel).ToUpper();
        var responses = JsonConvert.SerializeObject(MockWebApi.Responses.First(x=> x.WepApiUrl == urlConfig).RequestModel).ToUpper();

        if (MockWebApi.Responses.Any(x => x.WepApiUrl == urlConfig))
        {
          return (T)MockWebApi.Responses.FirstOrDefault(x => x.WepApiUrl == urlConfig && JsonConvert.SerializeObject(x.RequestModel).ToUpper() == JsonConvert.SerializeObject(requestModel).ToUpper()).ResponseContent;
        }
      }

      var webApiUrl = Configuration[urlConfig];

      var CurrentUser = SecurityHelper.GetSessionUser(CookieHelper.GetCookie<UserModel>("CurrentUser"));

      if(CurrentUser != null)
        webApiUrl +="?token=" + CurrentUser.ApiSessionToken;

      var webApiResponse = PostRequest(webApiUrl, requestModel);

      Exception innerException = null;

      try
      {
        innerException = JsonConvert.DeserializeObject<Exception>(webApiResponse.Result.ResponseContent);
      }
      catch { }

      if (webApiResponse.Result.ResponseCode != ((int)HttpStatusCode.OK).ToString())
        throw new Exception("Error occurred at " + urlConfig.ToLower() + " - " + innerException?.Message, innerException);

      return JsonConvert.DeserializeObject<T>(webApiResponse.Result.ResponseContent);
    }

    private async Task<WebApiResponseModel> PostRequest(string url, object requestModel)
    {
      using (var handler = new HttpClientHandler
            {
              ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            })
      {
        using (var client = new HttpClient(handler))
        {
          client.DefaultRequestHeaders.Accept.Clear();
          client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

          var requestContent = new StringContent(JsonConvert.SerializeObject(requestModel), Encoding.UTF8, "application/json");

          var httpResponseMessage = await client.PostAsync(url, requestContent);

          var responseModel = new WebApiResponseModel { ResponseContent = httpResponseMessage.Content.ReadAsStringAsync().Result, ResponseCode = ((int)httpResponseMessage.StatusCode).ToString() };

          return responseModel;
        }
      }

    }
  }
}
