using Market.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Service.DTOs.OrderDtos
{
    public class OrderForCreationDto
    {
        public long Id { get; set; }
        public Customer Customer { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
