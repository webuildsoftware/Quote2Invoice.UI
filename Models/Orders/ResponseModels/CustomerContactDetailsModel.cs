using System.Collections.Generic;

namespace Quote2Invoice.UI.Models.Orders.ResponseModels
{
  public class CustomerContactDetailsModel
  {
    public CustomerModel Customer { get; set; }
    public List<ContactModel> Contacts { get; set; }
  }
}
