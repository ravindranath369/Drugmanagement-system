using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using drugmanagementsystproject.dal;
using drugmanagementsystproject.Models;

namespace drugmanagementsystproject.Controllers
{
    public class DrugTrailHistController : Controller
    {
        DrugTrailHistoryDal db = new DrugTrailHistoryDal();
        // GET: DrugTrailHist
        public ActionResult Index()
        {
            List<DrugTrailHistoryModel> l1 = db.getAllDrugs();
            return View(l1);
        }

        public ActionResult Details(int id)
        {
            var model = db.getDrughistbyid(id);
            return View(model);
        }

        // GET: EmployeeRegistration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeRegistration/Create
        [HttpPost]
        public ActionResult Create(DrugTrailHistoryModel dth)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    if (db.Insertdrug(dth))
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
                return View(dth);
            }
        }
        //edit
        public ActionResult Edit(int id)
        {
            DrugTrailHistoryModel em = db.getDrughistbyid(id);
            return View(em);
        }

        // POST: 
        [HttpPost]
        public ActionResult Edit(DrugTrailHistoryModel dth)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    if (db.updateDetails(dth))
                    {
                        ModelState.Clear();
                        TempData["message"] = "changes done";
                        return RedirectToAction("Details", new { id = dth.id });
                    }
                }

                return View(dth);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message + "" + e.StackTrace);
                return View(dth);
            }
        }
        public ActionResult Delete(int id)
        {
            DrugTrailHistoryModel d = db.getDrughistbyid(id);
            return View(d);
        }
        // POST: 
        [HttpPost]
        public ActionResult Delete(DrugTrailHistoryModel dh)
        {
            try
            {
                // TODO: Add delete logic here
                if (db.deleteDrugHist(dh.id))
                {
                    TempData["message"] = "Sucessfully deleted";
                    // TempData["message"] = "<script>alert('Deleted SUCCESSFULLY')</script>";
                }
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                 ModelState.AddModelError("", e.Message + " " + e.StackTrace);
                return View();
            }
        }
    }
}