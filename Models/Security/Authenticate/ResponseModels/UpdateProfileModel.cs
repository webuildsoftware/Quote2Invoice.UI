namespace Quote2Invoice.UI.Models.Security.Authenticate.ResponseModels
{
  public class UpdateProfileModel
  {
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string ErrorMessage { get; set; }
  }
}
