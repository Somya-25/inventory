using AccessLayer;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace inventory.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            BAL bAL = new BAL();
            List<categories> categories= bAL.CategoryList.ToList();
            return View(categories);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "categoryID")] categories categories)
        {
            if (ModelState.IsValid)
            {
                BAL bAL = new BAL();
                bAL.AddCategories(categories);
                return RedirectToAction("Index");
            }
            return View(categories);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            BAL bAL = new BAL();
            categories categories = bAL.CategoryList.Single(c => c.categoryID == id);
            return View(categories);
        }


        [HttpPost]
        public ActionResult Edit(categories categories)
        {
            BAL bAL = new BAL();
            if (ModelState.IsValid)
            {
                bAL.EditCategories(categories);
                return RedirectToAction("Index");
            }
            return View(categories);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            BAL bAL = new BAL();
            bAL.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}