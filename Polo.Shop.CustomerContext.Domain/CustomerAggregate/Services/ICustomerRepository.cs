using System;
using System.Collections.Generic;
using System.Text;

namespace Polo.Shop.CustomerContext.Domain.CustomerAggregate.Services
{
    public interface ICustomerRepository
    {
        void CreateCustomer(Customer customer);
        Customer GetById(Guid customerId);
        void Update(Customer customer);
    }
}
