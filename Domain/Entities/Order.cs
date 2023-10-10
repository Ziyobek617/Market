using Market.Domain.Commons;

namespace Market.Domain.Entites
{
    public class Order : Auditable
    {
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
