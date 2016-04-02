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
            var db = new SQLiteConnection("C:\\Users\\Hunter\\Source\\Repos\\Shasta\\Shasta Water Management\\Shasta Water Management\\Data Access\\Shasta.db");
            //var db = new SQLiteConnection(Path.GetFullPath("\\Shasta Water Management\\Data Access\\Shasta.db"));

            IEnumerable<Customer> Customers = db.Table<Customer>();

            

            //using (var dbcontext = new Model1())
            //{
            //    var query = from c in dbcontext.Customers
            //                select c;
            //    customers = query.ToList();
            //}




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
            customer = customers.FirstOrDefault(x => x.CustomerID == id);

            return customer;
        }
    }
}