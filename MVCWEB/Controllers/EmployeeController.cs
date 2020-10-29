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

        //add function
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(mvcEmployeeModel emp)
        {
            HttpResponseMessage response = GlobalVariables.webclientApi.PostAsJsonAsync("Employees", emp).Result;
            TempData["Message"] = "Save Successfully ";

            return RedirectToAction("Index");
        }
        //edite function

        public ActionResult Edite(int id)
        {
            HttpResponseMessage response = GlobalVariables.webclientApi.GetAsync("Employees/" + id.ToString()).Result;
            var responsed = response.Content.ReadAsAsync<mvcEmployeeModel>().Result;
            return View(responsed);
        }

        [HttpPost]
        public ActionResult Edite(mvcEmployeeModel emp)
        {

            HttpResponseMessage response = GlobalVariables.webclientApi.PutAsJsonAsync("Employees/" + emp.EmployeeID, emp).Result;
            TempData["Message"] = "Update Successfully ";

            return RedirectToAction("Index");
        }
        //delete function
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webclientApi.DeleteAsync("Employees/" + id.ToString()).Result;
            TempData["Message"] = "Delete Successfully ";
            return RedirectToAction("Index");
        }
    }
}