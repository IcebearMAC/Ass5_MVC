using Ass5_MVC.DataAccess;
using Ass5_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Ass5_MVC.Repositories
{
    public class Repository
    {
        StoreContext db = new StoreContext();

        public object StockItem { get; internal set; }
        public int ArticleNUmber { get; private set; }
        public object[] ArticleNumber { get; private set; }
        public object Item { get; internal set; }

        // GET: StockItems
        public IEnumerable<StockItem> GetAllItems()
        {
            return db.Item;
        }

        public StockItem GetItemByArticleNumber(int? articleNumber)
        {
            return db.Item.SingleOrDefault(item => item.ArticleNumber == articleNumber);
        }

        internal object GetItemByArticleNumber()
        {
            throw new NotImplementedException();
        }

        public void Create(StockItem Item)
        {
            db.Item.Add(Item);
            db.SaveChanges();
        }

        public void DeleteStorageItemByID(int? id)
        {
            StockItem stockItem = db.Item.Find(id);
            db.Item.Remove(stockItem);
            db.SaveChanges();
        }

        public void DetailsStorageItemByID(int? articleNumber)
        {
            StockItem stockItem = db.Item.Find(articleNumber);
        }

        public DbEntityEntry<StockItem> Entry(StockItem stockItem)
        {
            return (DbEntityEntry<StockItem>)db.Entry(stockItem);
        }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public List<StockItem> nameSearch(string query)
        {


            //var db = from m in db.Sto
            //             select m;

            //return db.Item.Where(i => i.Name.Contains(query)).ToList();
            return db.Item.Where(i => i.ArticleNumber == int.Parse(query)||
                                      i.Price == double.Parse(query)||
                                      i.Name.Contains(query)
            ).ToList();



            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    var dibs = db.Item.Where(s => s.Name.Contains(searchString));
            //}

        }
    }
}