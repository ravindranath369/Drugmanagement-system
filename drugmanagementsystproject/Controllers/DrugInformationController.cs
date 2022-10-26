using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using drugmanagementsystproject.dal;
using drugmanagementsystproject.Models;

namespace drugmanagementsystproject.Controllers
{
    public class DrugInformationController : Controller
    {
        DrugInfoDataAxcessLayer db = new DrugInfoDataAxcessLayer();
        // GET: DrugInformation
        public ActionResult Index()
        {
            List<DrugInformationModel> l1 = db.getAllDrugs();
            return View(l1);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.getDrugById(id);
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DrugInformationModel drg)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (db.Insertdrug(drg))
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
                return View(drg);
            }
        }
        public ActionResult Edit(int id)
        {
            DrugInformationModel em = db.getDrugById(id);
            return View(em);
        }

        // POST
        [HttpPost]
        public ActionResult Edit(DrugInformationModel drg)
        {
            try
            {
                // TODO:  logic here
                if (ModelState.IsValid)
                {
                    if (db.updateDetails(drg))
                    {
                        ModelState.Clear();
                        TempData["message"] = "changes done";
                        return RedirectToAction("Details", new { id = drg.id });
                    }
                }

                return View(drg);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message + "" + e.StackTrace);
                return View(drg);
            }
        }
        public ActionResult delete(int id)
        {
            DrugInformationModel d = db.getDrugById(id);
            return View(d);
        }
        [HttpPost]
        public ActionResult delete(DrugInformationModel dm)
        {
            try
            {
                if (db.deleteDrug(dm.id))
                {
                    TempData["message"] = "sucessfully deleted";
                    // tempdata["message"] = "<script>alert('deleted successfully')</script>";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(dm);
            }
        }
    }
}