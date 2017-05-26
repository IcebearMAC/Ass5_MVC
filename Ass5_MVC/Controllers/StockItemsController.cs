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
        //private readonly object stockItem;

        public object ArticleNumber { get; private set; }
        public string Include { get; private set; }

        /// <summary>
        /// Gets all items in the database 
        /// </summary>
        /// <returns></returns>
        // GET: StockItem
        public ActionResult Index()
        {
            return View(db.GetAllItems());
        }

        /// <summary>
        /// Gets every item in the database that have the articlenumber that is searched for.
        /// </summary>
        /// <param name="articleNumber"></param>
        /// <returns></returns>
        // GET: ItemByArticleNumber
        public ActionResult Details(int articleNumber)
        {
            // calling Function in Repoistory for all items with articlenumber.
            return View(db.GetItemByArticleNumber(articleNumber));
        }

        /// <summary>
        /// Shows the view of creta
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(StockItem p)
        {
            //calling Function in Repoistory to creata new procuct in database.
            db.Create(p);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// deletes choosen product in database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteStorageItemByID(int? id)
        {
            //calling Function in Repoistory to get product with articlenumber.
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
            return View(db.GetItemByArticleNumber(id));
        }

        // GET: StockItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockItem stockItem = db.Item.Find(id);
            if (stockItem == null)
            {
                return HttpNotFound();
            }
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

        public ActionResult NameSearch(string query)
        {


            var SearchItem = db.NameSearcha(query);

            return View(SearchItem);

        }

    }
}
