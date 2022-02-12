﻿using ECommerce.Modules.Contacts.Core.DTO;
using ECommerce.Modules.Contacts.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Modules.Contacts.Core.Services
{
    internal class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task AddAsync(CustomerDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<CustomerDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDetailsDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CustomerDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
