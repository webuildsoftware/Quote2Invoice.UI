﻿using Microsoft.AspNetCore.Mvc;
using Quote2Invoice.UI.Shared.WebApiCaller;
using Quote2Invoice.UI.Models.Security.Authenticate.ResponseModels;
using Quote2Invoice.UI.Models.Security.Authenticate.RequestModels;
using Quote2Invoice.UI.Models.Security.Authenticate.InputModels;
using Quote2Invoice.UI.Shared;
using System;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace Quote2Invoice.UI.Controllers
{
  public class AuthenticateController : Controller
  {
    protected IWebApiCaller WebApiCaller;
    protected ICookieHelper CookieHelper;
    protected IUserAgentHelper UserAgentHelper;
    protected ISecurityHelper SecurityHelper;
    protected IConfiguration Configuration;

    public AuthenticateController(IWebApiCaller webApiCaller, ICookieHelper cookieHelper, IUserAgentHelper userAgentHelper, ISecurityHelper securityHelper, IConfiguration configuration)
    {
      WebApiCaller = webApiCaller;
      CookieHelper = cookieHelper;
      SecurityHelper = securityHelper;
      UserAgentHelper = userAgentHelper;
      Configuration = configuration;
    }

    public ViewResult Index(AuthenticateViewModel model)
    {
      return View(model);
    }

    public ViewResult RegisterIndex(AuthenticateViewModel model)
    {
      return View("Register", model);
    }

    public ViewResult UpdateProfile(UpdateProfileModel viewModel)
    {
      var currentUser = CookieHelper.GetCookie<string>("CurrentUser");

      var updateProfileModel = WebApiCaller.PostAsync<UpdateProfileModel>("WebApi:Authenticate:FindUserProfile", new FindUserRequestModel { Username = currentUser });

      return View("ChangePassword", updateProfileModel);
    }

    public ViewResult ForgottenPasswordIndex(AuthenticateViewModel model)
    {
      return View("ForgottenPassword", model);
    }

    public JsonResult ValidateUser(string username)
    {
      return Json(WebApiCaller.PostAsync<ValidationResult>("WebApi:Authenticate:ValidateUsername", new ValidateUserRequestModel { Username = username }));
    }

    public JsonResult ValidateEmail(string emailAddress)
    {
      return Json(WebApiCaller.PostAsync<ValidationResult>("WebApi:Authenticate:ValidateUserEmail", new ValidateEmailRequestModel { EmailAddress = emailAddress }));
    }

    public ViewResult NoAccess()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public RedirectToActionResult Login(string username, string password)
    {
      try
      {
        string browserInfo = "Unable to determine"; // defaults
        string deviceInfo = "Unable to determine";  // defaults

        if (!Convert.ToBoolean(Configuration["MockData.Enabled"]))
        {
          try
          {
            UserAgentHelper.SetUserAgent(Request.Headers["User-Agent"]);
            browserInfo = UserAgentHelper.Browser.Name + " " + UserAgentHelper.Browser.Version + " " + UserAgentHelper.Browser.Major;
            deviceInfo = UserAgentHelper.OS.Name + " " + UserAgentHelper.OS.Version;
          }
          catch { }
        }
        
        var userModel = WebApiCaller.PostAsync<UserModel>("WebApi:Authenticate:Login", new LoginRequestModel
        {
          Username = username,
          Password = password,
          Browser = browserInfo,
          Device = deviceInfo
        });

        if (userModel.Username != null)
        {
          if(userModel.IsAuthenticated)
          {
            CookieHelper.SignIn(userModel);
            SecurityHelper.AddSessionUser(userModel);
            return RedirectToAction("Index", "Orders");
          }
          else
            return RedirectToAction("Index", "Authenticate", new AuthenticateViewModel { Username = username, ErrorMessage = "Invalid password. Please try again." });
        }
        else
          return RedirectToAction("Index", "Authenticate", new AuthenticateViewModel { ErrorMessage = "Username does not exist." });
      }
      catch (Exception ex)
      {
        return RedirectToAction("Error", "Home", new {  IsError = "True", ex.Message, BaseMessage = ex.GetBaseException().Message });
      }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public RedirectToActionResult Register(RegistrationInputModel inputModel)
    {
      try
      {
        if (ModelState.IsValid)
        {
          string browserInfo = "Unable to determine"; // defaults
          string deviceInfo = "Unable to determine";  // defaults

          if (!Convert.ToBoolean(Configuration["MockData.Enabled"]))
          {
            try
            {
              UserAgentHelper.SetUserAgent(Request.Headers["User-Agent"]);
              browserInfo = UserAgentHelper.Browser.Name + " " + UserAgentHelper.Browser.Version + " " + UserAgentHelper.Browser.Major;
              deviceInfo = UserAgentHelper.OS.Name + " " + UserAgentHelper.OS.Version;
            }
            catch { }
          }

          var userModel = WebApiCaller.PostAsync<UserModel>("WebApi:Authenticate:Register", new RegisterUserRequestModel
          {
            Username = inputModel.Username,
            Password = inputModel.Password,
            ConfirmPassword = inputModel.ConfirmPassword,
            FirstName = inputModel.FirstName,
            LastName = inputModel.LastName,
            EmailAddress = inputModel.EmailAddress,
            Browser = browserInfo,
            Device = deviceInfo
          });

          if (userModel != null)
          {
            CookieHelper.SignIn(userModel);
            SecurityHelper.AddSessionUser(userModel);
            return RedirectToAction("Index", "Orders");
          }
          else
            return RedirectToAction("Register", new { ErrorMessage = "Unable to perform registration. Please contact IT support." });
        }
        else
          return RedirectToAction("Register", new { ErrorMessage = "There are validation errors with the information supplied." });
      }
      catch (Exception ex)
      {
        return RedirectToAction("Error", "Home", new {  IsError = "True", ex.Message, BaseMessage = ex.GetBaseException().Message });
      }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public JsonResult RequestCredentials(string emailAddress)
    {
      return Json(WebApiCaller.PostAsync<ValidationResult>("WebApi:Authenticate:ForgotPassword", new CredentialsRequestModel { EmailAddress = emailAddress }));
    }

    [HttpPost]
    public JsonResult SaveProfile(UpdateProfileRequestModel inputModel)
    {
      return Json(WebApiCaller.PostAsync<ValidationResult>("WebApi:Authenticate:SaveProfile", inputModel));
    }

    public RedirectToActionResult Logout()
    {
      CookieHelper.SignOut();
      return RedirectToAction("Index", "Authenticate");
    }


  }
}