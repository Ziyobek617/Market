using Market.Domain.Commons;

namespace Market.Domain.Entites
{
    public class Product : Auditable
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
    }

}
