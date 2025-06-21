using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class CustomerDAO
    {
        static List<Customer> customers = new List<Customer>();
        
        public void GenerateSampleDataset()
        {
            customers.Add(new Customer() { Id = 1, Name = "Tèo", Phone = "0983242351", Email = "teo@gmail.com" });
            customers.Add(new Customer() { Id = 2, Name = "Tí", Phone = "0983242351", Email = "ti@gmail.com" });
            customers.Add(new Customer() { Id = 3, Name = "Tửng", Phone = "0983242351", Email = "tung@gmail.com" });
            customers.Add(new Customer() { Id = 4, Name = "Tùng", Phone = "0983242351", Email = "tung@gmail.com" });
            customers.Add(new Customer() { Id = 5, Name = "Tồ", Phone = "0983242351", Email = "to@gmail.com" });

        }
        public List<Customer> GetAllCustomer()
        {
            return customers;
        }
    }
}
