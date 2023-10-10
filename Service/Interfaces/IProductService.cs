using Market.Service.DTOs.CustomerDto;
using Market.Service.DTOs.ProductDtos;

namespace Market.Service.Interfaces;

public interface IProductService
{
    public Task<ProductForResultDto> CreateAsync(ProductForCreationDto dto);
    public Task<ProductForResultDto> UpdateAsync(ProductForUpdateDto dto);
    public Task<bool> RemoveAsync(long id);
    public Task<ProductForResultDto> RetrieveIdAsync(long id);
    public Task<IEnumerable<ProductForResultDto>> RetrieveAllAsync();
}
