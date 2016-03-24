using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using Shasta_Water_Management.Models;

namespace Shasta_Water_Management.Repositories
{
    public class CustomerRepository
    {
        /// <summary>
        /// Gets all customers from the data location
        /// </summary>
        /// <returns>List of <see cref="Customer"/></returns>
        public static IEnumerable<Customer> GetCustomers()
        {
            var customers = new List<Customer>();

            var path = "C:\\Users\\blueh\\Source\\Repos\\Shasta_Water_Management\\Shasta Water Management\\Shasta Water Management\\Scripts\\customers.json";
            //var path = "C:\\Users\\Hunter\\Source\\Repos\\Shasta\\Shasta Water Management\\Shasta Water Management\\Scripts\\customers.json";

            using (StreamReader sr = new StreamReader(path))
            {
                string json = sr.ReadToEnd();
                customers = JsonConvert.DeserializeObject<List<Customer>>(json);
            }

            //using (var dbcontext = new Model1())
            //{
            //    var query = from c in dbcontext.Customers
            //                select c;
            //    customers = query.ToList();
            //}

            return customers;
        }

        /// <summary>
        /// Gets a single customer from the data location
        /// </summary>
        /// <param name="id">customer id</param>
        /// <returns><see cref="Customer"/></returns>
        public static Customer GetCustomer(string id)
        {
            var customer = new Customer();

            var customers = GetCustomers();
            customer = customers.FirstOrDefault(x => x.CustomerID == id);

            return customer;
        }
    }
}