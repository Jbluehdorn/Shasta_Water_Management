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
        /// <returns>List of <see cref="Models.Customer"/></returns>
        public static IEnumerable<Customer> GetCustomers()
        {
            var customers = new List<Customer>();

            var path = "C:\\Users\\blueh\\Source\\Repos\\Shasta_Water_Management\\Shasta Water Management\\Shasta Water Management\\Scripts\\customers.json";

            using(StreamReader sr = new StreamReader(path))
            {
                string json = sr.ReadToEnd();
                customers = JsonConvert.DeserializeObject<List<Customer>>(json);
            }

            return customers;
        }

        /// <summary>
        /// Gets a single customer from the data location
        /// </summary>
        /// <param name="id">customer id</param>
        /// <returns><see cref="Models.Customer"/></returns>
        public static Customer GetCustomer(string id)
        {
            var customer = new Customer();

            var customers = GetCustomers();
            customer = customers.FirstOrDefault(x => x.ID == id);

            return customer;
        }
    }
}