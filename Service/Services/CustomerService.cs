using AutoMapper;
using Market.Data.IRepository;
using Market.Data.Repositories;
using Market.Domain.Entites;
using Market.Service.DTOs.CustomerDto;
using Market.Service.DTOs.Mappings;
using Market.Service.Exceptions;
using Market.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Market.Service.Services;

public class CustomerService : ICustomerService
{
    private readonly IMapper mapper = MappingProfile.Initalize();
    private readonly IRepository<Customer> customerRepository = new Repository<Customer>();

    public async Task<CustomerForResultDto> CreateAsync(CustomerForCreationDto dto)
    {
        var customer = await customerRepository.SelectAll()
            .FirstOrDefaultAsync(c => c.Email.ToLower() == dto.Email.ToLower());

        if (customer != null)
        {
            throw new MarketException(400, "Customer already exists");
        }

        var mappedCustomer = mapper.Map<Customer>(dto);
        mappedCustomer.Created_At = DateTime.UtcNow;

        var insertedCustomer = await customerRepository.InsertAsync(mappedCustomer);

        var result = mapper.Map<CustomerForResultDto>(insertedCustomer);

        return result;
    }

    public async Task<IEnumerable<CustomerForResultDto>> RetrieveAllAsync()
    {
        var customers = await customerRepository.SelectAll().ToListAsync();

        return mapper.Map<IEnumerable<CustomerForResultDto>>(customers);
    }

    public async Task<CustomerForResultDto> RetrieveIdAsync(long id)
    {
        var customer = await customerRepository.SelectByIdAsync(id);

        if (customer is null)
        {
            throw new MarketException(404, "Customer is not found");
        }

        return mapper.Map<CustomerForResultDto>(customer);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var customer = await customerRepository.SelectByIdAsync(id);

        if (customer is null)
        {
            throw new MarketException(404, "Customer is not found");
        }

        await customerRepository.DeleteAsync(id);
        return true;
    }

    public async Task<CustomerForResultDto> UpdateAsync(CustomerForUpdateDto dto)
    {
        var customer = await customerRepository.SelectByIdAsync(dto.Id);

        if (customer is null)
        {
            throw new MarketException(404, "Customer is not found");
        }

        Customer mappedCustomer = mapper.Map<Customer>(customer);
        mappedCustomer.Updated_At = DateTime.UtcNow;

        await customerRepository.UpdateAsync(mappedCustomer);

        return mapper.Map<CustomerForResultDto>(mappedCustomer);
    }
}
