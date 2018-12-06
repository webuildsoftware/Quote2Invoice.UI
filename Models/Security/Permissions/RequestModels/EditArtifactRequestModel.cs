namespace Quote2Invoice.UI.Models.Security.Permissions.RequestModels
{
  public class EditArtifactRequestModel
  {
    public int ArtifactId { get; set; }
    public string ArtifactName { get; set; }
    public string CreateUser { get; set; }
  }
}
