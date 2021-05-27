using SQLClientPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClientPractice.Repositories
{
    public interface ICustomerRepository
    {
        public Customer GetCustomer(int id);
        public List<Customer> GetCustomerByName(string FirstName);
        public List<Customer> GetAllCustomers();
        public bool AddNewCustomer(Customer customer);
        public bool UpdateCustomer(Customer customer);
        IEnumerable<CustomerCountry> GetNoOfCustomersByCountry();
        public List<Customer> GetAllCustomersTakingLimitAndOffset(int limit, int offset);
        public bool DeleteCustomer(int id);
        IEnumerable<CustomerSpender> GetCustomersWithHighestSpenders();
        IEnumerable<CustomerGenre> GetMostPopularCustomerGenre(int CustomerId);

    }
}
