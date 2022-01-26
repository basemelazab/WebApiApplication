using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class mvcEmployeeController : Controller
    {
        // GET: mvcEmployee
        public ActionResult Index()
        {
            IEnumerable<mvcEmployeeModel> emplist;
            HttpResponseMessage response = ClientVariables.WebApiClient.GetAsync("Employees").Result;
            emplist = response.Content.ReadAsAsync<IEnumerable<mvcEmployeeModel>>().Result;
            return View(emplist);
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            { 
              return View(new mvcEmployeeModel());
            }
            else
            {
                HttpResponseMessage response = ClientVariables.WebApiClient.GetAsync("Employees/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcEmployeeModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcEmployeeModel emp)
        {
            if (emp.EmployeeId == 0)
            { 
            HttpResponseMessage response = ClientVariables.WebApiClient.PostAsJsonAsync("Employees", emp).Result;
            TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = ClientVariables.WebApiClient.PutAsJsonAsync("Employees/" + emp.EmployeeId, emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = ClientVariables.WebApiClient.DeleteAsync("Employees/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Delete Successfully";
            return RedirectToAction("Index");
        }
    }
}