using System.Collections.Generic;

namespace Quote2Invoice.UI.Models.Orders.ResponseModels
{
  public class OrderCustomerViewModel
  {
    public List<CustomerModel> Customers { get; set; }
    public OrderCustomerDetailModel CustomerDetails { get; set; }
    public List<ContactModel> Contacts { get; set; }
  }
}
