using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var path = HttpContext.Current.Server.MapPath("~/Data Access/Shasta.db");
            var db = new SQLiteConnection(path);

            Customers = db.Table<Customer>().Where(x => x.Deleted == "N").ToList();
            


            foreach (var customer in Customers)
            {
                string id = customer.CustomerID.ToString();
                var eq = db.Query<CustEquip>("SELECT CustomerID, SerialNum, ModelNum, Type, Name, RentOwn, Diagnostics FROM CustEquip JOIN Equipment ON Equipment.EquipID = CustEquip.EquipID WHERE CustEquip.CustomerID = ?", id);
                customer.CustEquip = eq;
                
                
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

        //needs work
        public static void DeleteCustomer(Customer cust)
        {
            var path = HttpContext.Current.Server.MapPath("~/Data Access/Shasta.db");
            var db = new SQLiteConnection(path);
           
             db.Execute("UPDATE Customer SET Deleted = 'Y' WHERE CustomerID = '?'", cust.CustomerID);
             db.Execute("UPDATE CustEquip SET Deleted = 'Y' WHERE CustomerID = '?'", cust.CustomerID);
            
           
        }

        //looks like form makes customer object just get properties and add to db
        public static void AddCustomer(Customer cust)
        {
            var path = HttpContext.Current.Server.MapPath("~/Data Access/Shasta.db");
            var db = new SQLiteConnection(path);
            db.Insert(cust);

        }

        public static void ModifyCustomer(Customer cust)
        {
            var path = HttpContext.Current.Server.MapPath("~/Data Access/Shasta.db");
            var db = new SQLiteConnection(path);
            var id = cust.CustomerID;
            var name = cust.Name;

            if (name != db.Query<Customer>("SELECT Name FROM Customer WHERE CustomerId = '?'", id).ToString())
            {
                db.Execute("UPDATE Customer SET Name = '?' WHERE CustomerID = '?'", name, id );
            }
            //do one for each property or find more efficient way like with foreach

            
            

        }
    }
}