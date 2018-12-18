namespace Quote2Invoice.UI.Models.Orders.ResponseModels
{
  public class OrderDetailViewModel
  {
    public int OrderId { get; set; }
    public string OrderNo { get; set; }
    public int OrderNoSeed { get; set; }
    public decimal VatRate { get; set; }
  }
}
