using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using SQLite;

namespace Shasta_Water_Management.Test
{
    public class Test
    {
        private IEnumerable<Customer> Customers;
 
        public Test()
        {
            var path = Path.GetFullPath("../Repositories/Shasta.db");
            var db = new SQLiteConnection("C:\\Users\\blueh\\Source\\Repos\\Shasta_Water_Management\\Shasta Water Management\\Shasta Water Management\\Repositories\\Shasta.db");
            //db.CreateTable<CustEquip>();
            //db.CreateTable<Equipment>();
            //db.CreateTable<Customer>();

            var customers = db.Table<Customer>();
            Customers = customers.ToList();

            foreach (var customer in Customers)
            {

            }

            Debug.WriteLine(customers.FirstOrDefault().Name);
        }

        public IEnumerable<Customer> Get()
        {
            return Customers;
        } 
    }
}