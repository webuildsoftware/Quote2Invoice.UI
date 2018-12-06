namespace Quote2Invoice.UI.Models.Orders.ResponseModels
{
  public class OrderQuotationViewModel
  {
    public OrderCustomerDetailModel CustomerDetail { get; set; }
    public AddressDetailsModel DeliveryAddress { get; set; }
    public CompanyProfileModel CompanyProfile { get; set; }
    public OrderDetailModel OrderTotals { get; set; }
  }
}
