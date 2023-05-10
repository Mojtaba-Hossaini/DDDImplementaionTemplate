namespace KShop.Core.Domain.Shares;
public class Share
{
    private Share(long id, int productId, decimal shareValue)
    {
        Id = id;
        ProductId = productId;
        ShareValue = shareValue;
    }

    public long Id { get; set; }
    public int ProductId { get; set; }
    public decimal ShareValue { get; set; }

    public static Share Build(long id, int productId, decimal shareValue) =>
        new Share(id, productId, shareValue);
}
