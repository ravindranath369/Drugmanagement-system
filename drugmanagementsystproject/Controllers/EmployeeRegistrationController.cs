using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using drugmanagementsystproject.dal;
using drugmanagementsystproject.Models;

namespace drugmanagementsystproject.Controllers
{
    public class EmployeeRegistrationController : Controller
    {
        DataAxcessingLayer db = new DataAxcessingLayer();

        [Authorize]
        public ActionResult Dashboard()
        {
            return View();
        }
        // GET: EmployeeRegistration
        public ActionResult Index()
        {
            List<EmployeeRegistrationModel> l1 = db.getAllEmployees();
            return View(l1);
        }

        // GET: EmployeeRegistration/Details/5
        public ActionResult Details(int employeeid)
        {
            var model = db.getEmployeeById(employeeid);
            return View(model);
        }

        // GET: EmployeeRegistration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeRegistration/Create
        [HttpPost]
        public ActionResult Create(EmployeeRegistrationModel employee)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    if(db.insertEmployee(employee))
                    {
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message + " " + ex.StackTrace);
                return View(employee);
            }
        }

        // GET: EmployeeRegistration/Edit/5
        public ActionResult Edit(int employeeid)
        {
            EmployeeRegistrationModel em = db.getEmployeeById(employeeid);
            return View(em);
        }

        // POST: EmployeeRegistration/Edit/5
        [HttpPost]
        public ActionResult Edit(EmployeeRegistrationModel emp)
        {
            try
            {
                // TODO: Add update logic here
                if(ModelState.IsValid)
                {
                    if(db.updateDetails(emp))
                    {
                        ModelState.Clear();
                        TempData["message"] = "changes done";
                        return RedirectToAction("Details", new { employeeid = emp.employeeid });
                    }
                }

                return View(emp);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message + "" + e.StackTrace);
                return View(emp);
            }
        }

        // GET: EmployeeRegistration/Delete/5
        public ActionResult Delete(int employeeid)
        {
            EmployeeRegistrationModel e = db.getEmployeeById(employeeid);
            return View(e);
        }

        // POST: EmployeeRegistration/Delete/5
        [HttpPost]
        public ActionResult Delete(EmployeeRegistrationModel emp)
        {
            try
            {
                // TODO: Add delete logic here
                if(db.deleteEmployee(emp.employeeid))
                {
                    TempData["message"] = "Sucessfully deleted";
                    // TempData["message"] = "<script>alert('Deleted SUCCESSFULLY')</script>";
                }
                return RedirectToAction("Edit");
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", e.Message + " " + e.StackTrace);
                return View(emp);
            }
        }
    }
}
