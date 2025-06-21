using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository iRepository;

        public CustomerService()
        {
            iRepository = new CustomerRepository();
        }
        public void GenerateSampleDataset()
        {
            iRepository.GenerateSampleDataset();
        }

        public List<Customer> GetAllCustomer()
        {
            return iRepository.GetAllCustomer();
        }
    }
}
