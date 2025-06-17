using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DaoNguyenTrongLib.Models;
using DaoNguyenTrongLib.Services;

namespace DaoNguyenTrongWPF.ViewModels
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        private readonly CustomerService _customerService;

        public ObservableCollection<Customer> Customers { get; set; }
        public Customer SelectedCustomer { get; set; }

        public CustomerViewModel()
        {
            _customerService = new CustomerService(new DaoNguyenTrongLib.Repositories.CustomerRepository());
            Customers = new ObservableCollection<Customer>(_customerService.GetAllCustomers());
        }

        public void AddCustomer(Customer customer)
        {
            _customerService.AddCustomer(customer);
            Customers.Add(customer);
        }

        public void UpdateCustomer(Customer updatedCustomer)
        {
            _customerService.UpdateCustomer(updatedCustomer);
            var oldCustomer = Customers.FirstOrDefault(c => c.CustomerID == updatedCustomer.CustomerID);
            if (oldCustomer != null)
            {
                int index = Customers.IndexOf(oldCustomer);
                Customers[index] = updatedCustomer;
            }
        }

        public void DeleteCustomer(int customerId)
        {
            _customerService.DeleteCustomer(customerId);
            var cust = Customers.FirstOrDefault(c => c.CustomerID == customerId);
            if (cust != null)
                Customers.Remove(cust);
        }

        public void SearchCustomers(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                Customers.Clear();
                foreach (var cust in _customerService.GetAllCustomers())
                    Customers.Add(cust);
            }
            else
            {
                var filtered = _customerService.SearchCustomers(keyword);
                Customers.Clear();
                foreach (var cust in filtered)
                    Customers.Add(cust);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
