using System.Collections.Generic;
using Quote2Invoice.UI.Models.Security.Authenticate.ResponseModels;
using Quote2Invoice.UI.Models.Security.Permissions.RequestModels;
using Quote2Invoice.UI.Shared;
using Quote2Invoice.UI.Shared.WebApiCaller;
using Microsoft.AspNetCore.Mvc;

namespace Quote2Invoice.UI.Controllers
{
  //[Authorize]
  public class PermissionsController : Controller
  {
    protected IWebApiCaller WebApiCaller;
    protected ICookieHelper CookieHelper;
    protected UserModel CurrentUser;

    public PermissionsController(IWebApiCaller webApiCaller, ICookieHelper cookieHelper)
    {
      WebApiCaller = webApiCaller;
      CookieHelper = cookieHelper;
      CurrentUser = CookieHelper.GetCookie<UserModel>("LoggedInUser");
    }

    public ViewResult Index()
    {
      return View();
    }

    public JsonResult GetArtifacts()
    {
      return Json(WebApiCaller.PostAsync<List<ArtifactModel>>("WebApi:Permissions:GetAllArtifacts", null));
    }

    [HttpPost]
    public JsonResult AddArtifact(AddArtifactRequestModel requestModel)
    {
      requestModel.CreateUser = CurrentUser.Username;

      return Json(WebApiCaller.PostAsync<ValidationResult>("WebApi:Permissions:AddArtifact", requestModel));
    }

    [HttpPost]
    public JsonResult EditArtifact(EditArtifactRequestModel requestModel)
    {
      requestModel.CreateUser = CurrentUser.Username;

      return Json(WebApiCaller.PostAsync<ValidationResult>("WebApi:Permissions:EditArtifact", requestModel));
    }

    [HttpPost]
    public JsonResult RemoveArtifact(RemoveArtifactRequestModel requestModel)
    {
      WebApiCaller.PostAsync<string>("WebApi:Permissions:RemoveArtifact", requestModel);

      return Json("Success");
    }

    [HttpPost]
    public JsonResult GetPermissions(FindPermissionsRequestModel requestModel)
    {
      return Json(WebApiCaller.PostAsync<List<PermissionModel>>("WebApi:Permissions:Find", requestModel));
    }

    [HttpPost]
    public JsonResult AddPermission(AddPermissionRequestModel requestModel)
    {
      requestModel.CreateUser = CurrentUser.Username;

      return Json(WebApiCaller.PostAsync<ValidationResult>("WebApi:Permissions:Add", requestModel));
    }

    [HttpPost]
    public JsonResult RemovePermission(RemovePermissionRequestModel requestModel)
    {
      WebApiCaller.PostAsync<string>("WebApi:Permissions:Remove", requestModel);

      return Json("Success");
    }

  }
}