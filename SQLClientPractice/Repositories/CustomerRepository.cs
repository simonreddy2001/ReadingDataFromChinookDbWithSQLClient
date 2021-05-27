using Microsoft.Data.SqlClient;
using SQLClientPractice.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClientPractice.Repositories
{
    public class CustomerRepository : ICustomerRepository
    { 
        /// <summary>
        /// Getting every customer record from the customer table
        /// </summary>
        /// <returns>customer records with their fields</returns>
        public List<Customer> GetAllCustomers()
        {
            List<Customer> custList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, ISNULL(PostalCode,'No-Postal-code'), ISNULL(Phone,'No-Phone'), Email from Customer";

            try
            {
                using(SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using(SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer temp = new Customer();
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Country = reader.GetString(3);
                                temp.PostalCode = reader.GetString(4);
                                temp.Phone = reader.GetString(5);
                                temp.Email = reader.GetString(6);
                                custList.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                
            }
            return custList;
        }

        /// <summary>
        /// Getting customers with the starting point according to offset and numbers of customers according to the limit
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns>list of customer w.r.t limit and offset</returns>
        public List<Customer> GetAllCustomersTakingLimitAndOffset(int limit, int offset)
        {
            List<Customer> custList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, ISNULL(PostalCode,'No-Postal-code'), ISNULL(Phone,'No-Phone'), Email from Customer ORDER BY CustomerId OFFSET @offset ROWS FETCH NEXT @limit ROWS ONLY";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@limit", limit);
                        cmd.Parameters.AddWithValue("@offset", offset);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer temp = new Customer();
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Country = reader.GetString(3);
                                temp.PostalCode = reader.GetString(4);
                                temp.Phone = reader.GetString(5);
                                temp.Email = reader.GetString(6);
                                custList.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

            }
            return custList;
        }

        /// <summary>
        /// Getting specific customer w.r.t his/her id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>specific id's customer object</returns>
        public Customer GetCustomer(int id)
        {
            Customer customer = new Customer();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, ISNULL(PostalCode,'No-Postal-code'), ISNULL(Phone,'No-Phone'), Email from Customer" +
                          " WHERE CustomerId = @CustomerId";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.GetString(3);
                                customer.PostalCode = reader.GetString(4);
                                customer.Phone = reader.GetString(5);
                                customer.Email = reader.GetString(6);
                                
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

                
            }
            return customer;
        }
        
        /// <summary>
        /// Adding a new customer to the customer table
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>true for successful addition and false for failure in addition</returns>
        public bool AddNewCustomer(Customer customer)
        {
            bool success = false;
            string sql = "INSERT INTO Customer(FirstName,LastName,Country,PostalCode,Phone,Email) " +
                            "VALUES(@FirstName,@LastName,@Country,@PostalCode,@Phone,@Email)";
            try
            {
                using(SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using(SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return success;
        }
        /// <summary>
        /// Getting the customer by matching the input name
        /// </summary>
        /// <param name="FirstName"></param>
        /// <returns>customer name with the predefined name</returns>
        public List<Customer> GetCustomerByName(string FirstName)
        {
            string sql = "SELECT CustomerId, FirstName, LastName, Country, ISNULL(PostalCode,'No-Postal-code'), ISNULL(Phone,'No-Phone'), Email from Customer" +
                          " WHERE FirstName LIKE @FirstName";
            List<Customer> customers = new List<Customer>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", '%'+FirstName+'%');
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer temp = new Customer();
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Country = reader.GetString(3);
                                temp.PostalCode = reader.GetString(4);
                                temp.Phone = reader.GetString(5);
                                temp.Email = reader.GetString(6);
                                customers.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {


            }
            return customers;
        }
        public bool DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updating specific customer w.r.t customer id
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>true for successful update and false for failure in update</returns>
        public bool UpdateCustomer(Customer customer)
        {
            bool success = false;
            string sql = "UPDATE Customer SET FirstName=@FirstName,LastName=@LastName,Country=@Country,PostalCode=@PostalCode," +
                            "Phone=@Phone,Email=@Email WHERE CustomerId=@CustomerId";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return success;
        }

        /// <summary>
        /// Getting number of customers w.r.t country in descending order
        /// </summary>
        /// <returns>customers obj w.r.t country</returns>
        public IEnumerable<CustomerCountry> GetNoOfCustomersByCountry()
        {
            List<CustomerCountry> custList = new List<CustomerCountry>();
            string sql = "SELECT COUNT(CustomerId), Country FROM Customer GROUP BY Country ORDER BY Country DESC";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerCountry temp = new CustomerCountry();
                                temp.NoOfCustomersByCountry = reader.GetInt32(0);
                                temp.Country = reader.GetString(1);
                                custList.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

            }
            return custList;
        }

        /// <summary>
        /// Getting name and total invoice of the spenders
        /// </summary>
        /// <returns>customer w.r.t higher spend</returns>
        public IEnumerable<CustomerSpender> GetCustomersWithHighestSpenders()
        {
            List<CustomerSpender> custList = new List<CustomerSpender>();
            string sql = "SELECT Customer.FirstName, Customer.LastName, SUM(Invoice.Total) as Total FROM Customer INNER JOIN Invoice ON Customer.CustomerId = Invoice.CustomerId GROUP BY Customer.FirstName, Customer.LastName ORDER BY Total DESC";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerSpender temp = new CustomerSpender();
                                
                                //temp.CustomerId = reader.GetInt32(0);
                                temp.CustomerFirstName = reader.GetString(0);
                                temp.CustomerLastName = reader.GetString(1);
                                temp.TotalInvoice = (double)reader.GetDecimal(2);
                                custList.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

            }
            return custList;
        }

        /// <summary>
        /// Getting most tracks (popular genre) from invoices w.r.t spcific customer id 
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns>most popular genre for a specific customer</returns>
        public IEnumerable<CustomerGenre> GetMostPopularCustomerGenre(int CustomerId)
        {
            List<CustomerGenre> custList = new List<CustomerGenre>();
            string sql = @"SELECT TOP 1 WITH TIES Customer.FirstName, Customer.LastName, Genre.Name as GenreName, COUNT(Genre.Name) as CountOnGenre
            FROM Customer
            INNER JOIN Invoice ON Customer.CustomerID = Invoice.CustomerID
            INNER JOIN InvoiceLine ON Invoice.InvoiceId = InvoiceLine.InvoiceId
            INNER JOIN Track ON InvoiceLine.TrackId = Track.TrackId
            INNER JOIN Genre ON Track.GenreId = Genre.GenreId
            WHERE Customer.CustomerId = @CustomerId
            GROUP BY Genre.Name, Customer.FirstName, Customer.LastName
                ORDER BY CountOnGenre DESC";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        command.Parameters.AddWithValue("@CustomerId", CustomerId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerGenre temp = new CustomerGenre();
                                temp.FirstName = reader.GetString(0);
                                temp.LastName = reader.GetString(1);
                                temp.GenreName = reader.GetString(2);
                                temp.CountOnGenre = reader.GetInt32(3);
                                custList.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                
            }

            return custList;
        }
    }
}

