using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ass5_MVC.DataAccess;
using Ass5_MVC.Models;
using Ass5_MVC.Repositories;


namespace Ass5_MVC.Controllers
{
    public class StockItemsController : Controller
    {
        Repositories.Repository db = new Repositories.Repository();
        private readonly object stockItem;

        public object ArticleNumber { get; private set; }
        public string Include { get; private set; }

        // GET: StockItem
        public ActionResult Index()
        {
            return View(db.GetAllItems());
        }

        // GET: ItemByArticleNumber
        public ActionResult Details(int articleNumber)
        {
            return View(db.GetItemByArticleNumber(articleNumber));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StockItem p)
        {
            db.Create(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteStorageItemByID(int? id)
        { 
            return View(db.GetItemByArticleNumber(id));
        }

        // POST: StockItems/Delete/5
        [HttpPost, ActionName("DeleteStorageItemByID")]
       // [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.DeleteStorageItemByID(id);
            return RedirectToAction("Index");

        }


        // GET: StockItems/Details/5
        public ActionResult DetailsStorageItemByID(int? id)
        {
            //db.DetailsStorageItemByID(id);
            return View(db.GetItemByArticleNumber(id));

        }

        // GET: StockItems/Edit/5
        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //StockItem stockItem = db.Item.Find(id);
            //if (stockItem == null)
            //{
            //    return HttpNotFound();
            //}
            return View(db.GetItemByArticleNumber(id));
        }

        // POST: StockItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArticleNumber,Name,Price,ShelfPosition,Quantity,Description")] StockItem stockItem)
        {
            if (ModelState.IsValid)
            {

                db.Entry(stockItem);
                db.Entry(stockItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stockItem);
        }

        public ActionResult Index(string searchString)
        {

            db.IndexSearch(searchString);

            //var movies = from m in db.Movies
            //             select m;

            

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    movies = movies.Where(s => s.Title.Contains(searchString));
            //}

            return View(movies);
        }

    }



    //    // GET: StockItems
    //    public ActionResult Index()
    //    {
    //        return View(db.Item.ToList());
    //    }

    //    // GET: StockItems/Details/5
    //    public ActionResult Details(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        StockItem stockItem = db.Item.Find(id);
    //        if (stockItem == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(stockItem);
    //    }



    //    // POST: StockItems/Create
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Create([Bind(Include = "ArticleNumber,Name,Price,ShelfPosition,Quantity,Description")] StockItem stockItem)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            db.Item.Add(stockItem);
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }

    //        return View(stockItem);
    //    }

    //    // GET: StockItems/Edit/5
    //    public ActionResult Edit(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        StockItem stockItem = db.Item.Find(id);
    //        if (stockItem == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(stockItem);
    //    }

    //    // POST: StockItems/Edit/5
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Edit([Bind(Include = "ArticleNumber,Name,Price,ShelfPosition,Quantity,Description")] StockItem stockItem)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            db.Entry(stockItem).State = EntityState.Modified;
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }
    //        return View(stockItem);
    //    }

    //    // GET: StockItems/Delete/5
    //    public ActionResult Delete(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        StockItem stockItem = db.Item.Find(id);
    //        if (stockItem == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(stockItem);
    //    }

    //    // POST: StockItems/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult DeleteConfirmed(int id)
    //    {
    //        StockItem stockItem = db.Item.Find(id);
    //        db.Item.Remove(stockItem);
    //        db.SaveChanges();
    //        return RedirectToAction("Index");
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            db.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }

}
