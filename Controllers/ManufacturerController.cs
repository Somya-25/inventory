using AccessLayer;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace inventory.Controllers
{
    public class ManufacturerController : Controller
    {
        // GET: Manufacturer
        public ActionResult Index()
        
        {
            BAL bAL = new BAL();
            List<Manufacturers> manufacturerList= bAL.ManufacturerList.ToList();
            return View(manufacturerList);
        }
        public ActionResult mypage()

        {
            
            return View();
        }


        [HttpGet]
       public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude ="ManufacturerId")]Manufacturers manufacturers)
        {
            if(ModelState.IsValid)
            {
                BAL bAL = new BAL();
                bAL.AddManufacturer(manufacturers);
                return RedirectToAction("Index");
            }
            return View(manufacturers);
        }
        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            BAL bAL = new BAL();
            Manufacturers manufacturer= bAL.ManufacturerList.Single(m => m.ManufacturerID==id);
            return View(manufacturer);
        }


        [HttpPost]
        public ActionResult Edit(Manufacturers manufacturers)
        {
            BAL bAL = new BAL();
           if(ModelState.IsValid)
            {
                bAL.EditManufacturer(manufacturers);
                return RedirectToAction("Index");
            }
            return View(manufacturers);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            BAL bAL = new BAL();
            bAL.DeleteManufacturer(id);
            return RedirectToAction("Index");
        }

    }
}