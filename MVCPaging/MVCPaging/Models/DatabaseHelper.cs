using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCGridPaging.Models
{
    public class DatabaseHelper
    {
        public int FillData()
        {
            using (MyDatabaseEntities db = new MyDatabaseEntities())
            {
                var maxRecords = 10000;
                for (var counter = 0; counter < maxRecords; counter++)
                    db.Customers.Add(new Customer()
                    {
                        CustomerName = string.Format("Name_{0}", counter),
                        Address = string.Format("Address_{0}", counter),
                        EmailAddress = string.Format("Email_{0}", counter),
                        PostCode = string.Format("PO_{0}", counter),
                        City = string.Format("City_{0}", counter),

                    });
                return db.SaveChanges();
            }
            return -1;
        }
    }
}