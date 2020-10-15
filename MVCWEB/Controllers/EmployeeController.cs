using MVCWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVCWEB.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<mvcEmployeeModel> mylist;
            HttpResponseMessage response = GlobalVariables.webclientApi.GetAsync("Employees").Result;
            mylist = response.Content.ReadAsAsync<IEnumerable<mvcEmployeeModel>>().Result;
            return View(mylist);
        }
        public ActionResult AddOrEdite(int id=0)
        {
            if (id==0)
            {
                return View();
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webclientApi.GetAsync("Employees/" + id.ToString()).Result;
                var responsed = response.Content.ReadAsAsync<mvcEmployeeModel>().Result;
                return View(responsed);
            }
            
        }
        [HttpPost]
        public ActionResult AddOrEdite(mvcEmployeeModel emp)
        {
            if (emp.EmployeeID==0)
            {
                HttpResponseMessage response = GlobalVariables.webclientApi.PostAsJsonAsync("Employees", emp).Result;
                TempData["Message"] = "Save Successfully ";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webclientApi.PutAsJsonAsync("Employees/" + emp.EmployeeID, emp).Result;
                TempData["Message"] = "Update Successfully ";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webclientApi.DeleteAsync("Employees/" + id.ToString()).Result;
            TempData["Message"] = "Delete Successfully ";
            return RedirectToAction("Index");
        }
    }
}