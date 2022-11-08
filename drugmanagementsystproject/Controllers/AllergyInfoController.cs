using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using drugmanagementsystproject.dal;
using drugmanagementsystproject.Models;

namespace drugmanagementsystproject.Controllers
{
    public class AllergyInfoController : Controller
    {
        AllergicInfoDal db = new AllergicInfoDal();
        // GET: AllergyInfo
        [Authorize(Roles = "Admin,User")]
        public ActionResult Index()
        {
            List<AllergicInformationModel> al = db.getAllAlergies();
            return View(al);
        }
        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public ActionResult Details(int Aid)
        {
            var model = db.getAlergyById(Aid);
            return View(model);
        }
        [Authorize(Roles = "Admin,User")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public ActionResult Create(AllergicInformationModel Alg)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (db.Insertdrug(Alg))
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
                return View(Alg);
            }
        }
        [Authorize(Roles = "Admin,User")]
        public ActionResult Edit(int Aid)
        {
            AllergicInformationModel em = db.getAlergyById(Aid);
            return View(em);
        }

        // POST
        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public ActionResult Edit(AllergicInformationModel alm)
        {
            try
            {
                // TODO:  logic here
                if (ModelState.IsValid)
                {
                    if (db.updateDetails(alm))
                    {
                        ModelState.Clear();
                        TempData["message"] = "changes done";
                        return RedirectToAction("Details", new { Aid = alm.Aid });
                    }
                }
                
                return View(alm);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message + "" + e.StackTrace);
                return View(alm);
            }
        }
        [Authorize(Roles = "Admin,User")]
        public ActionResult delete(int Aid)
        {
            AllergicInformationModel al = db.getAlergyById(Aid);
            return View(al);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public ActionResult delete(AllergicInformationModel al)
        {
            try
            {
                if (db.deleteAllergy(al.Aid))
                {
                    TempData["message"] = "sucessfully deleted";
                    // tempdata["message"] = "<script>alert('deleted successfully')</script>";
                }
                return RedirectToAction("Edit");
            }
            catch
            {
                return View(al);
            }
        }
    }
}