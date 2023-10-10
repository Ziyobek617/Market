using Market.Data.IRepository;
using Market.Data.Repositories;
using Market.Domain.Entites;
using Market.Service.DTOs.ProductDtos;
using Market.Service.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Market.Service.Interfaces;

public class ProductService : IProductService
{
    private readonly IRepository<Product> productRepository = new Repository<Product>();

    public async Task<ProductForResultDto> CreateAsync(ProductForCreationDto dto)
    {
        var product = new Product()
        {
            Name = dto.Name,
            Price = dto.Price,
            QuantityInStock = dto.QuantityInStock
        };

        await productRepository.InsertAsync(product);

        return new ProductForResultDto()
        {
            Name = product.Name,
            Price = product.Price
        };
    }

    public async Task<ProductForResultDto> UpdateAsync(ProductForUpdateDto dto)
    {
        var product = await productRepository.SelectByIdAsync(dto.Id);
        if (product == null)
        {
            throw new MarketException(404, "Product is not found");
        }

        product.Name = dto.Name;
        product.Price = dto.Price;
        product.QuantityInStock = dto.QuantityInStock;

        await productRepository.UpdateAsync(product);

        return new ProductForResultDto()
        {
            Name = product.Name,
            Price = product.Price
        };
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var product = await productRepository.SelectByIdAsync(id);
        if (product == null)
        {
            throw new MarketException(404, "Product is not found");
        }

        await productRepository.DeleteAsync(id);

        return true;
    }

    public async Task<ProductForResultDto> RetrieveIdAsync(long id)
    {
        var product = await productRepository.SelectByIdAsync(id);
        if (product == null)
        {
            throw new MarketException(404, "Product is not found");
        }

        return new ProductForResultDto()
        {
            Name = product.Name,
            Price = product.Price
        };
    }

    public async Task<IEnumerable<ProductForResultDto>> RetrieveAllAsync()
    {
        var products = await productRepository.SelectAll().ToListAsync();
        return products.Select(product => new ProductForResultDto()
        {
            Name = product.Name,
            Price = product.Price
        });
    }
}
