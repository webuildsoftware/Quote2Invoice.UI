namespace Quote2Invoice.UI.Models.Orders.RequestModels
{
  public class AddOrderRequestModel
  {
    public string OrderNo { get; set; }
    public string Username { get; set; }
    public int CompanyProfileId { get; set; }
  }
}
