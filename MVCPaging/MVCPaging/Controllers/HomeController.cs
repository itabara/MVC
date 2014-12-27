using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCGridPaging.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int page = 1)
        {            
            int pageSize = 10;
            int noPages = 0;
            int noRecords = 0;

            List<Customer> customerList = new List<Customer>();
            using (MyDatabaseEntities db = new MyDatabaseEntities())
            {
                noRecords = db.Customers.Count();
                noPages = (noRecords / pageSize) + ((noRecords % pageSize) > 0 ? 1:0);
                int offset = (page - 1) * pageSize;
                customerList = db.Customers.OrderBy(cust => cust.CustomerID).Skip(offset).Take(pageSize).ToList();
            }

            ViewBag.TotalRows = noRecords;
            ViewBag.PageSize = pageSize;

            return View(customerList);
        }

        
    }
}