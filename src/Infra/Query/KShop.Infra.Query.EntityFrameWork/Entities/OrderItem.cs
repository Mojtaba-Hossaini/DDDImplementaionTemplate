namespace KShop.Infra.Query.EntityFrameWork.Entities; 
public class OrderItem
{
    public long Id { get; set; }
    public long OrderId { get; set; }
    public string ItemTitle { get; set; }
    public long ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public OrderItemType OrderItemType { get; set; }
    public Order Order { get; set; }
}
