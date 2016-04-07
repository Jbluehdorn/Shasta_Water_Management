using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using Shasta_Water_Management.Models;
using SQLite;

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
            IEnumerable<Customer> Customers = new List<Customer>();
            //var db = new SQLiteConnection("C:\\Users\\blueh\\Source\\Repos\\Shasta_Water_Management\\Shasta Water Management\\Shasta Water Management\\Data Access\\Shasta.db");
            ////var db = new SQLiteConnection(Path.GetFullPath("\\Shasta Water Management\\Data Access\\Shasta.db"));

            //IEnumerable<Customer> Customers = db.Table<Customer>();

            using (var sr = new StreamReader("C:\\Users\\blueh\\Source\\Repos\\Shasta_Water_Management\\Shasta Water Management\\Shasta Water Management\\Scripts\\customers.json"))
            {
                Customers = JsonConvert.DeserializeObject<List<Customer>>(sr.ReadToEnd());
            }

            return Customers;
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
            //may need to change this
            customer = customers.FirstOrDefault(x => x.CustomerID == Convert.ToInt32(id));


            //didn't work unless ID was string
            //customer = customers.FirstOrDefault(x => x.CustomerID == id);

            return customer;
        }
    }
}