using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using Repositories;
using Services;

namespace DaoNguyenTrongWPF.ViewModels
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        private readonly ICustomerRepository _customerRepository;

        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set { _customers = value; OnPropertyChanged(); }
        }

        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set { _selectedCustomer = value; OnPropertyChanged(); }
        }

        public CustomerViewModel()
        {
            _customerRepository = new CustomerRepository();
            LoadCustomers();
        }

        public void LoadCustomers()
        {
            Customers = new ObservableCollection<Customer>(_customerRepository.GetAll());
        }

        public void AddCustomer(Customer customer)
        {
            _customerRepository.Add(customer);
            Customers.Add(customer);
        }

        public void UpdateCustomer(Customer updatedCustomer)
        {
            _customerRepository.Update(updatedCustomer);
            var oldCustomer = Customers.FirstOrDefault(c => c.CustomerId == updatedCustomer.CustomerId);
            if (oldCustomer != null)
            {
                int index = Customers.IndexOf(oldCustomer);
                Customers[index] = updatedCustomer;
            }
        }

        public void DeleteCustomer(int customerId)
        {
            _customerRepository.Delete(customerId);
            var cust = Customers.FirstOrDefault(c => c.CustomerId == customerId);
            if (cust != null)
                Customers.Remove(cust);
        }

        public void SearchCustomers(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadCustomers();
            }
            else
            {
                var filtered = _customerRepository.Search(keyword);
                Customers = new ObservableCollection<Customer>(filtered);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
