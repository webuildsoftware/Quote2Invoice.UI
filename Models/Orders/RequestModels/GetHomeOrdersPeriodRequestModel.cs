using System;

namespace Quote2Invoice.UI.Models.Orders.RequestModels
{
  public class GetHomeOrdersPeriodRequestModel
  {
    public string Username { get; set; }
    public int CompanyProfileId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
  }
}
