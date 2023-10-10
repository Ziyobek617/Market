using Market.Domain.Commons;

namespace Market.Domain.Entites
{
    public class Customer : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
