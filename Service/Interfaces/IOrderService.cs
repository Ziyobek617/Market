using Market.Service.DTOs.OrderDtos;
using Market.Service.DTOs.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Service.Interfaces
{
    public interface IOrderService
    {
        public Task<bool> RemoveAsync(long id);
        public Task<OrderForResultDto> RetrieveIdAsync(long id);
        public Task<IEnumerable<OrderForResultDto>> RetrieveAllAsync();
        public Task<OrderForResultDto> CreateAsync(OrderForCreationDto dto);
    }
}
