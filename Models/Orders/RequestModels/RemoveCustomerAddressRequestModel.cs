namespace Quote2Invoice.UI.Models.Orders.RequestModels
{
  public class RemoveCustomerAddressRequestModel
  {
    public int CustomerId { get; set; }
    public int AddressDetailId { get; set; }
    public string Username { get; set; }
  }
}
