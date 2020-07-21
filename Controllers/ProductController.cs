using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace inventory.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            BAL bAL = new BAL();
            List<Products> products= bAL.ProductList.ToList();
            //ViewBag.category = new SelectList(bAL.CategoryList.ToList(), "categoryID", "CategoryName");
            return View(products);
        }

        [HttpGet]
        public ActionResult create()
        {
            BAL bAL = new BAL();
            ViewBag.CategoryID = new SelectList(bAL.CategoryList.ToList(), "categoryID", "CategoryName");
            ViewBag.ManufacturerID = new SelectList(bAL.ManufacturerList, "ManufacturerID", "CompanyName");
            return View();
        }

        [HttpPost]
        public ActionResult create([Bind(Exclude = "CategoryName,ManufacturerName")] Products products)
        {
            BAL bAL = new BAL();
            //products.ManufacturerName = bAL.ManufacturerList.Single(m => m.ManufacturerID == products.ManufacturerID).CompanyName;
            //products.CategoryName = bAL.CategoryList.Single(c => c.categoryID == products.CategoryID).CategoryName;
            
            if(ModelState.IsValid)
            {
                bAL.AddProducts(products);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(bAL.CategoryList.ToList(), "categoryID", "CategoryName");
            ViewBag.ManufacturerID = new SelectList(bAL.ManufacturerList, "ManufacturerID", "CompanyName");
            return View(products);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            BAL bAL = new BAL();
           Products product= bAL.ProductList.Single(p => p.ProductID == id);
            ViewBag.CategoryID = new SelectList(bAL.CategoryList.ToList(), "categoryID", "CategoryName",product.CategoryID);
            ViewBag.ManufacturerID = new SelectList(bAL.ManufacturerList, "ManufacturerID", "CompanyName",product.ManufacturerID);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Products products)
        {
            BAL bAL = new BAL();
            if (ModelState.IsValid)
            {

                bAL.EditProducts(products);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(bAL.CategoryList.ToList(), "categoryID", "CategoryName", products.CategoryID);
            ViewBag.ManufacturerID = new SelectList(bAL.ManufacturerList, "ManufacturerID", "CompanyName", products.ManufacturerID);
            return View(products);
        }

        [HttpPost]

        public ActionResult Delete(int id)
        {
            BAL bAL = new BAL();
            bAL.deleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}