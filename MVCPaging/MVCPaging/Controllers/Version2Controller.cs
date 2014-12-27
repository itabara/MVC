using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace MVCGridPaging.Controllers
{
    public class Version2Controller : Controller
    {
        public ActionResult Index(int page = 1)
        {
            int pageSize = 10;
            int noPages = 0;
            int noRecords = 0;
            
            var customerList = new List<Customer>();
            
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerDatabase"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("GetCustomers", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PageNo", page);
                cmd.Parameters.AddWithValue("@NoOfRecord", pageSize);

                SqlParameter TotalRecordSP = new SqlParameter("@TotalRecord", System.Data.SqlDbType.Int);
                TotalRecordSP.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(TotalRecordSP);

                var dt = new DataTable();
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                dt.Load(cmd.ExecuteReader());
                
                if (TotalRecordSP.Value != null)
                {
                    int.TryParse(TotalRecordSP.Value.ToString(), out noRecords);
                }
                var dataTable = dt.AsEnumerable();
                customerList = (from DataRow row in dt.Rows
                                select new Customer()
                                {
                                    CustomerID = (int) row["CustomerID"],
                                    CustomerName = row["CustomerName"] as string,
                                    Address = row["Address"] as string,
                                    EmailAddress = row["EmailAddress"] as string,
                                    PostCode = row["PostCode"] as string,
                                    City = row["City"] as string,
                                }
                                    ).ToList();
            }

            noPages = (noRecords / pageSize) + ((noRecords % pageSize) > 0 ? 1 : 0);
            
            ViewBag.TotalRows = noRecords;
            ViewBag.PageSize = pageSize;
            return View(customerList);
        }        
    }
}