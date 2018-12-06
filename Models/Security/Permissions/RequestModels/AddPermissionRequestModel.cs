namespace Quote2Invoice.UI.Models.Security.Permissions.RequestModels
{
  public class AddPermissionRequestModel
  {
    public int ArtifactId { get; set; }
    public int RoleId { get; set; }
    public string CreateUser { get; set; }
  }
}
