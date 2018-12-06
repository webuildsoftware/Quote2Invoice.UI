namespace Quote2Invoice.UI.Models.Security.Role.RequestModels
{
  public class RemoveRoleMemberRequestModel
  {
    public int RoleId { get; set; }

    public int RoleMemberId { get; set; }
  }
}
