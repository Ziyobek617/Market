using Market.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Service.DTOs.OrderDtos
{
    public class OrderForResultDto
    {
        public long Id { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
