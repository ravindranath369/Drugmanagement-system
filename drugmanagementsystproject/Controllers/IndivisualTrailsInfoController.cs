using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using drugmanagementsystproject.dal;
using drugmanagementsystproject.Models;
namespace drugmanagementsystproject.Controllers
{
    public class IndivisualTrailsInfoController : Controller
    {
        IndivisualTrailsInfoDal db = new IndivisualTrailsInfoDal();
        // GET: IndivisualTrailsInfo
        public ActionResult Index()
        {
            List<IndivisualTrailsInfoModel> l1 = db.getInditrailsinfo();
            return View(l1);
        }

        public ActionResult Details(int id)
        {
            var model = db.getIndivTrailbyid(id);
            return View(model);
        }

        // GET: /Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeRegistration/Create
        [HttpPost]
        public ActionResult Create(IndivisualTrailsInfoModel dth)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    if (db.insertIndtrailInfo(dth))
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
        public ActionResult Edit(int id)
        {
            IndivisualTrailsInfoModel em = db.getIndivTrailbyid(id);
            return View(em);
        }

        // POST: 
        [HttpPost]
        public ActionResult Edit(IndivisualTrailsInfoModel dth)
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
            IndivisualTrailsInfoModel d = db.getIndivTrailbyid(id);
            return View(d);
        }
        // POST: 
        [HttpPost]
        public ActionResult Delete(IndivisualTrailsInfoModel itm)
        {
            try
            {
                // TODO: Add delete logic here
                if (db.deleteIndiTrailInfo(itm.id))
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