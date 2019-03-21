using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using HRManager.Models;

namespace HRManager.Controllers
{
    public class EmployeesClientController : Controller
    {
        private HRManagerContext db = new HRManagerContext();

        // GET: Employees1
        public ActionResult Index()
        {
            IEnumerable<Employee> employees = null;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:6874/api/Employees/");

                    //HTTP GET
                    var responseTask = client.GetAsync("");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<Employee>>();
                        readTask.Wait();

                        employees = readTask.Result;
                        return View(employees);
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        employees = Enumerable.Empty<Employee>();

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
            }
            catch (Exception ex)
            {
                employees = Enumerable.Empty<Employee>();

                ModelState.AddModelError(string.Empty, ex.Message);
            }

            if (TempData["shortMessage"] != null)
            {
                ViewBag.Message = TempData["shortMessage"].ToString();
            }
            return View(employees);
        }

        //// GET: Employees1/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Employee employee = db.Employees.Find(id);
        //    if (employee == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(employee);
        //}

        // GET: Employees1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:6874/api/Employees/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<Employee>("", employee);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData["shortMessage"] = "Add Succesfull";
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(employee);
        }

        // GET: Employees1/Edit/5
        public ActionResult Edit(int? id)
        {
            Employee employee = null;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:6874/api/Employees/");

                    //HTTP GET
                    var responseTask = client.GetAsync(id.ToString());
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<Employee>();
                        readTask.Wait();

                        employee = readTask.Result;
                    }
                    else //web api sent error response 
                    {
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(employee);
        }

        // POST: Employees1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Employee employee)
        {
            //[Bind(Include = "EmployeeId,EmployeeName,Address,Email")]
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:6874/api/Employees/");

                    //HTTP POST
                    var putTask = client.PutAsJsonAsync<Employee>(employee.EmployeeId.ToString(),
                                                                        employee);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData["shortMessage"] = "Update Sucessfull";
                        return RedirectToAction("Index");
                    }

                }
            }
            catch
            {
                TempData["shortMessage"] = " Oh snap! Change a few things up and try submitting again.";
                return RedirectToAction("Index");
            }


            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
