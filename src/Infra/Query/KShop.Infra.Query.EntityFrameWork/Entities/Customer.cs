namespace KShop.Infra.Query.EntityFrameWork.Entities;
public class Customer
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public bool IsDeleted { get; set; }
}
