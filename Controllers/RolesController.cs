using Microsoft.AspNetCore.Mvc;
using Quote2Invoice.UI.Shared;
using Quote2Invoice.UI.Shared.WebApiCaller;
using Quote2Invoice.UI.Models.Security.Role.ResponseModels;
using Quote2Invoice.UI.Models.Security.Role.RequestModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Quote2Invoice.UI.Models.Security.Authenticate.ResponseModels;

namespace Quote2Invoice.UI.Controllers
{
  //[Authorize]
  public class RolesController : Controller
  {
    protected IWebApiCaller WebApiCaller;
    protected ICookieHelper CookieHelper;
    protected UserModel CurrentUser;

    public RolesController(IWebApiCaller webApiCaller, ICookieHelper cookieHelper)
    {
      WebApiCaller = webApiCaller;
      CookieHelper = cookieHelper;
      CurrentUser = CookieHelper.GetCookie<UserModel>("LoggedInUser");
    }

    public ViewResult Index()
    {
      return View();
    }

    public JsonResult GetAll()
    {
      return Json(WebApiCaller.PostAsync<List<RoleModel>>("WebApi:Role:GetAll", null));
    }

    public JsonResult FilterUsernames(string term)
    {
      return Json(WebApiCaller.PostAsync<List<string>>("WebApi:Role:SearchUsers", new SearchUsersRequestModel { SearchTerm = term }));
    }

    [HttpPost]
    public JsonResult AddRole(AddRoleRequestModel requestModel)
    {
      requestModel.CreateUser = CurrentUser.Username;

      return Json(WebApiCaller.PostAsync<ValidationResult>("WebApi:Role:AddRole", requestModel));
    }

    [HttpPost]
    public JsonResult EditRole(EditRoleRequestModel requestModel)
    {
      requestModel.CreateUser = CurrentUser.Username;

      return Json(WebApiCaller.PostAsync<ValidationResult>("WebApi:Role:EditRole", requestModel));
    }

    [HttpPost]
    public JsonResult RemoveRole(RemoveRoleRequestModel requestModel)
    {
      WebApiCaller.PostAsync<string>("WebApi:Role:RemoveRole", requestModel);

      return Json("Success");
    }

    [HttpPost]
    public JsonResult GetRoleMembers(FindRoleMembersRequestModel requestModel)
    {
      return Json(WebApiCaller.PostAsync<List<RoleMemberModel>>("WebApi:Role:GetRoleMembers", requestModel));
    }

    [HttpPost]
    public JsonResult AddRoleMember(AddRoleMemberRequestModel requestModel)
    {
      requestModel.CreateUser = CurrentUser.Username;

      return Json(WebApiCaller.PostAsync<ValidationResult>("WebApi:Role:AddRoleMember", requestModel));
    }

    [HttpPost]
    public JsonResult RemoveRoleMember(RemoveRoleMemberRequestModel requestModel)
    {
      WebApiCaller.PostAsync<string>("WebApi:Role:RemoveRoleMember", requestModel);

      return Json("Success");
    }
  }
}