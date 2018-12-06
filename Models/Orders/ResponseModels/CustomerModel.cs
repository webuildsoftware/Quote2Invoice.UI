using System;

namespace Quote2Invoice.UI.Models.Orders.ResponseModels
{
  public class CustomerModel
  {
    public int CompanyProfileId { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string CustomerDetails { get; set; }
    public string ContactNo { get; set; }
    public string AccountNo { get; set; }
    public string MobileNo { get; set; }
    public string EmailAddress { get; set; }
    public string CreateUser { get; set; }
    public DateTime CreateDate { get; set; }
  }
}
