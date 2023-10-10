using Market.Service.DTOs.CustomerDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Service.Interfaces
{
    public interface ICustomerService
    {
        public Task<CustomerForResultDto> CreateAsync(CustomerForCreationDto dto);
        public Task<CustomerForResultDto> UpdateAsync(CustomerForUpdateDto dto);
        public Task<bool> RemoveAsync(long id);
        public Task<CustomerForResultDto> RetrieveIdAsync(long id);
        public Task<IEnumerable<CustomerForResultDto>> RetrieveAllAsync();
    }
}
