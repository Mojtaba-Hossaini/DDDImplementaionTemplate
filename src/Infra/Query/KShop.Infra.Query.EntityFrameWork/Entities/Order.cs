namespace KShop.Infra.Query.EntityFrameWork.Entities;
public class Order
{
    public long Id { get; set; }
    public decimal Price { get; set; }
    public long CustomerId { get; set; }

    public Customer Customer { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}
