using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication;
using Quote2Invoice.UI.Models.Security.Authenticate.ResponseModels;
using System;
using Newtonsoft.Json;

namespace Quote2Invoice.UI.Shared
{
  public interface ICookieHelper
  {
    Task<bool> SignIn(UserModel usermodel);
    Task<bool> SignOut();
    T GetCookie<T>(string key);
    void SetCookie(string key, UserModel value);
    void RemoveCookie(string key);
  }

  public class CookieHelper : ICookieHelper
  {
    protected IConfiguration Configuration;
    protected IHttpContextAccessor HttpContext;

    public CookieHelper(IConfiguration configuration, IHttpContextAccessor httpContext)
    {
      HttpContext = httpContext;
      Configuration = configuration;
    }

    public async Task<bool> SignIn(UserModel usermodel)
    {
      bool result = false;

      var claims = new List<Claim>
        {
          new Claim(ClaimTypes.Name, usermodel.Username),
          new Claim("SessionToken", usermodel.ApiSessionToken),
        };

      var claimsIdentity = new ClaimsIdentity(claims, Configuration["CookieSecurityScheme"]);

      await HttpContext.HttpContext.SignInAsync(
          Configuration["CookieSecurityScheme"],
          new ClaimsPrincipal(claimsIdentity),
          new AuthenticationProperties { ExpiresUtc = DateTimeOffset.UtcNow.AddHours(24) });

      result = true; return result;
    }

    public async Task<bool> SignOut()
    {
      bool result = false;

      await HttpContext.HttpContext.SignOutAsync(Configuration["CookieSecurityScheme"]);

      result = true; return result;
    }

    public T GetCookie<T>(string key)
    {

      if (HttpContext.HttpContext.Request.Cookies[key] != null)
      {
        //get username with key
        var userModel = HttpContext.HttpContext.Request.Cookies[key];
        //get session token using cookie value
        //var userModel = HttpContext.HttpContext.Session.GetString(username);

        return JsonConvert.DeserializeObject<T>(userModel);
      }
      else
        return default(T);
    }

    public void SetCookie(string key, UserModel user)
    {
      if (HttpContext.HttpContext.Request.Cookies[key] != null)
        RemoveCookie(key);

      var option = new CookieOptions();
      option.Expires = DateTime.Now.AddMinutes(Convert.ToInt32(Configuration["CookieExpireTimeSpan"]));

      //send key and username to cookie
      HttpContext.HttpContext.Response.Cookies.Append(key, JsonConvert.SerializeObject(user), option);
      //send cookie keyvalue and sessiontoken to session
      //HttpContext.HttpContext.Session.SetString(user.Username, JsonConvert.SerializeObject(user));
    }

    public void RemoveCookie(string key)
    {
      HttpContext.HttpContext.Response.Cookies.Delete(key);
    }

  }
}
