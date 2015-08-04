using bindingJSON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bindingJSON.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            // Initial View
            return View();
        }

        [HttpPost]
        public JsonResult PostCustomer(Customer customer)
        {
            string status = null;
            try
            {
                this.SaveCustomer(customer);                
            }
            catch (Exception e)
            {
                status = e.Message;
            }
            return Json(status);
        }

        #region privateHelpers
        private Boolean SaveCustomer(Customer customer) 
        {
            return false;
        }
        #endregion
    }
}
