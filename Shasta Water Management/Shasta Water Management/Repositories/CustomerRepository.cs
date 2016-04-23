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
        public static bool DeleteCustomer(Customer cust)
        {
            bool success;
            var path = HttpContext.Current.Server.MapPath("~/Data Access/Shasta.db");
            var db = new SQLiteConnection(path);


            success = db.Execute("UPDATE Customer SET Deleted = 'Y' WHERE CustomerID = ?", cust.CustomerID) > 0;
            success = success && db.Execute("UPDATE CustEquip SET Deleted = 'Y' WHERE CustomerID = ?", cust.CustomerID) > 0;

            return success;
        }

        //looks like form makes customer object just get properties and add to db
        public static bool AddCustomer(Customer cust)
        {
            bool success;
            cust.LastService = cust.LastService ?? DateTime.Now;
            var path = HttpContext.Current.Server.MapPath("~/Data Access/Shasta.db");
            var db = new SQLiteConnection(path);
            success = db.Insert(cust) > 0;
            return success;
        }

        public static bool ModifyCustomer(Customer cust)
        {
            bool success = false;
            var path = HttpContext.Current.Server.MapPath("~/Data Access/Shasta.db");
            var db = new SQLiteConnection(path);
            var id = cust.CustomerID;
            
            

            if (cust.Name != db.Query<Customer>("SELECT Name FROM Customer WHERE CustomerId = ?", id).ToString())
            {
                success = db.Execute("UPDATE Customer SET Name = ? WHERE CustomerID = ?", cust.Name, id ) > 0;
            }

            if (cust.CellPhoneNum != db.Query<Customer>("SELECT CellPhoneNum FROM Customer WHERE CustomerId = ?", id).ToString())
            {
                success = db.Execute("UPDATE Customer SET CellPhoneNum = ? WHERE CustomerID = ?", cust.CellPhoneNum, id) > 0;
            }

            if (cust.HomePhoneNum != db.Query<Customer>("SELECT HomePhoneNum FROM Customer WHERE CustomerId = ?", id).ToString())
            {
                success = db.Execute("UPDATE Customer SET HomePhoneNum = ? WHERE CustomerID = ?", cust.HomePhoneNum, id) > 0;
            }

            if (cust.Address != db.Query<Customer>("SELECT Address FROM Customer WHERE CustomerId = ?", id).ToString())
            {
                success = db.Execute("UPDATE Customer SET Address = ? WHERE CustomerID = ?", cust.Address, id) > 0;
            }

            if (cust.City != db.Query<Customer>("SELECT City FROM Customer WHERE CustomerId = ?", id).ToString())
            {
                success = db.Execute("UPDATE Customer SET City = ? WHERE CustomerID = ?", cust.City, id) > 0;
            }

            if (cust.State != db.Query<Customer>("SELECT State FROM Customer WHERE CustomerId = ?", id).ToString())
            {
                success = db.Execute("UPDATE Customer SET State = ? WHERE CustomerID = ?", cust.State, id) > 0;
            }

            if (cust.Zip != db.Query<Customer>("SELECT Zip FROM Customer WHERE CustomerId = ?", id).ToString())
            {
                success = db.Execute("UPDATE Customer SET Zip = ? WHERE CustomerID = ?", cust.Zip, id) > 0;
            }

            if (cust.Notes != db.Query<Customer>("SELECT Notes FROM Customer WHERE CustomerId = ?", id).ToString())
            {
                success = db.Execute("UPDATE Customer SET Notes = ? WHERE CustomerID = ?", cust.Notes, id) > 0;
            }

            return success;
        }
    }
}