using SQLClientPractice.Models;
using SQLClientPractice.Repositories;
using System;
using System.Collections.Generic;

namespace SQLClientPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            ICustomerRepository repository = new CustomerRepository();
            //No.1: Get all customers from the table
            //TestSelectAll(repository);

            //No.2: Get specific customer by using customerid from the customer table
            //TestSelect(repository);

            //No.3: Access customer by using FirstName from the customer table Like "m%l" for "Md Ansarul"
            //TestGetCustomerByName(repository);

            //No.4: Get no of customers by using limit and offset
            //TestSelectAllTakingLimitAndOffset(repository);

            //No.5: Insert one customer in the customer table
            //TestInsert(repository);

            //No.6: Update an existing Customer
            //TestUpdate(repository);

            //No.7: Get no of customers in each country in descending order
            //TestGetNoOfCustomersByCountry(repository);

            //No.8: Get the customers who has highest spenders in descending order
            //TestGetCustomersByHighestSpenders(repository);

            //No.9: Get the most popular genre w.r.t specific customer
            //TestGetMostPopularGenreOfSpecificCustomer(repository);

            Console.ReadKey();
        }

        static void TestGetMostPopularGenreOfSpecificCustomer(ICustomerRepository repository)
        {
            PrintCustomerWithMostPopularGenres(repository.GetMostPopularCustomerGenre(5));     
        }

        static void PrintCustomerWithMostPopularGenres(IEnumerable<CustomerGenre> customers)
        {
            foreach (CustomerGenre customer in customers)
            {
                PrintCustomerGenre(customer);
            }
        }
        static void PrintCustomerGenre(CustomerGenre customerGenre)
        {
            Console.WriteLine($"--- {customerGenre.FirstName}---{customerGenre.LastName}---{customerGenre.GenreName}---{customerGenre.CountOnGenre} ---");
        }

        static void TestSelectAll(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetAllCustomers());
        }

        static void TestSelectAllTakingLimitAndOffset(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetAllCustomersTakingLimitAndOffset(10,55));
        }
       

        static void TestSelect(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomer(58));
        }

        static void TestGetCustomersByHighestSpenders(ICustomerRepository repository)
        {
            PrintCustomersHighestSpenders(repository.GetCustomersWithHighestSpenders());
        }

       
        static void PrintCustomersHighestSpenders(IEnumerable<CustomerSpender> customers)
        {
            foreach (CustomerSpender customer in customers)
            {
                PrintCustomersHighestSpender(customer);
            }
        }

        static void PrintCustomersHighestSpender(CustomerSpender customer)
        {
            Console.WriteLine($"---{customer.CustomerFirstName}---{customer.CustomerLastName}---{customer.TotalInvoice}");
        }

        static void TestInsert(ICustomerRepository repository)
        {
            Customer test = new Customer()
            {
                CustomerId = 61,
                FirstName = "Md Ansarul",
                LastName = "Haque",
                Country = "Bangladesh",
                PostalCode = "3500",
                Phone = "310892677",
                Email = "mdanhaq@gmail.com"
            };
            if (repository.AddNewCustomer(test))
            {
                Console.WriteLine("Hurrah, I am in the list");
                PrintCustomer(repository.GetCustomer(61));
            }
            else
            {
                Console.WriteLine("Why I am not inserted in the list?");
            }
        }
        static void TestGetCustomerByName(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetCustomerByName("Ansarul"));
        }
        static void TestUpdate(ICustomerRepository repository)
        {
            Customer test = new Customer()
            {
                CustomerId = 61,
                FirstName = "Md Ansarul",
                LastName = "Haque",
                Country = "Bangladesh",
                PostalCode = "3500",
                Phone = "008801712533935",
                Email = "mdanhaq@gmail.com"
            };
            if (repository.UpdateCustomer(test))
            {
                Console.WriteLine("Hurrah, I am updated in the list");
                PrintCustomer(repository.GetCustomer(61));
            }
            else
            {
                Console.WriteLine("Why I am not updated in the list?");
            }
        }

        static void TestGetNoOfCustomersByCountry(ICustomerRepository repository)
        {
            PrintCustomersByCountry(repository.GetNoOfCustomersByCountry());
        }
        static void TestDelete(ICustomerRepository repository)
        {

        }

        static void PrintCustomers(IEnumerable<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                PrintCustomer(customer);
            }
        }

        static void PrintCustomer(Customer customer)
        {
            Console.WriteLine($"---{customer.CustomerId}---{customer.FirstName}--{customer.LastName}---{customer.Country}---{customer.PostalCode}---{customer.Phone}---{customer.Email}");
        }


        static void PrintCustomersByCountry(IEnumerable<CustomerCountry> customers)
        {
            foreach (CustomerCountry customer in customers)
            {
                PrintCustomerByCountry(customer);
            }
        }

        static void PrintCustomerByCountry(CustomerCountry CustomerByCountry)
        {
            Console.WriteLine($"---{CustomerByCountry.NoOfCustomersByCountry}---{CustomerByCountry.Country}");
        }
    }
}
