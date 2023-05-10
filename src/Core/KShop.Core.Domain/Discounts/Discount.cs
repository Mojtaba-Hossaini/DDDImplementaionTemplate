using KShop.Core.Domain.Orders;

namespace KShop.Core.Domain.Discounts;

public class Discount
{
    private Discount(long id, string title, int value, DiscountValueType discountValueType)
    {
        Id = id;
        Title = title;
        Value = value;
        DiscountValueType = discountValueType;
    }

    protected Discount() { }
    public long Id { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
    public DiscountValueType DiscountValueType { get; set; }
    public List<Order> Orders { get; set; }

    public static Discount Build(long id, string title, int value, DiscountValueType discountValueType) =>
        new Discount(id, title, value, discountValueType);
}
