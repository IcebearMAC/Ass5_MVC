using Ass5_MVC.DataAccess;
using Ass5_MVC.Models;
using System;
using System.Collections.Generic;
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

        public StockItem GetItemByArticleNumber(int articleNumber)
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

        public void DeleteStorageItemByID(int id)
        {
            StockItem stockItem = db.Item.Find(id);
            db.Item.Remove(stockItem);
            db.SaveChanges();
        }
 

        // GET: StockItems/Details/5
        public void DetailsStorageItemByID(int? id)
        {
            StockItem stockItem = db.Item.Find(id);
        }

    }
}