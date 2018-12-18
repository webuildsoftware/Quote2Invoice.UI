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
    string GetCookie<T>(string key);
    void SetCookie(string key, string value);
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
          new AuthenticationProperties { ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(Convert.ToInt32(Configuration["CookieExpireTimeSpan"])) });

      SetCookie("CurrentUser", usermodel.Username);

      return true;
    }

    public async Task<bool> SignOut()
    {
      bool result = false;

      await HttpContext.HttpContext.SignOutAsync(Configuration["CookieSecurityScheme"]);

      result = true; return result;
    }

    public string GetCookie<T>(string key)
    {
      if (HttpContext.HttpContext.Request.Cookies[key] != null)
      {
        //get username with key
        return HttpContext.HttpContext.Request.Cookies[key];
      }
      return string.Empty;
    }

    public void SetCookie(string key, string value)
    {
      if (HttpContext.HttpContext.Request.Cookies[key] != null)
        RemoveCookie(key);

      var option = new CookieOptions
      {
        Expires = DateTime.Now.AddMinutes(Convert.ToInt32(Configuration["CookieExpireTimeSpan"]))
      };

      //send key and username to cookie
      HttpContext.HttpContext.Response.Cookies.Append(key, value, option);
    }

    public void RemoveCookie(string key)
    {
      HttpContext.HttpContext.Response.Cookies.Delete(key);
    }

  }
}
