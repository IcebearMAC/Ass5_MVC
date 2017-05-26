using Ass5_MVC.DataAccess;
using Ass5_MVC.Models;
using System;
using System.Collections;
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
        private int iResult;

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

        /// <summary>
        /// Function for search of item
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IEnumerable<StockItem> /*List<StockItem>*/ NameSearcha(string query)
        {
            //return db.Item.Where(i => i.Name.Contains(query)).ToList();

            //return db.Item.Where(i => i.ArticleNumber == int.Parse(query) ||
            //                          i.Price == double.Parse(query) ||
            //                          i.Name.Contains(query)
            //).ToList();

            // Loop that check if the string hold a value and is not Null
            if (!String.IsNullOrEmpty(query))
            {
                var dibs = db.Item.Where(s => s.Name.Contains(query));
            }

           bool test= query.All(char.IsDigit);


            //if to check if the string contatins a digit
            if /*(test == true)*/(query.Any(char.IsDigit))
            {
                //try to parse the string to int
                if (int.TryParse(query, out iResult))
                {
                    //search for articlenumber in database with it and then sed back in string list
                    return db.Item.Where(a => a.ArticleNumber == iResult).ToList();
                }
                else // If not Try parse didn´t work it is double
                {
                    // Converting string to double
                    double dResult = Convert.ToDouble(query);
                    // ask database for item with price choosen and then send back in string list
                    return db.Item.Where(p => p.Price == dResult).ToList();
                }
            }
            else // if not any digit
            {
                // ordinary search with name and return to list
                return db.Item.Where(n => n.Name.Contains(query)).ToList();
            }
        }

        public IEnumerable<StockItem> SortItem(string sortOrder)
        {
            var sortItem = from i in db.Item
                           select i;

            switch (sortOrder)
            {
                case "AticleNumber":
                    sortItem = sortItem.OrderBy(i => i.ArticleNumber);
                    break;
                case "Name":
                    sortItem = sortItem.OrderBy(i => i.Name);
                    break;
                case "Price":
                    sortItem = sortItem.OrderBy(i => i.Price);
                    break;
                case "ShelfPosition":
                    sortItem = sortItem.OrderBy(i => i.ShelfPosition);
                    break;
                case "Quantity":
                    sortItem = sortItem.OrderBy(i => i.Quantity);
                    break;
                default:
                    sortItem = sortItem.OrderBy(i  => i.Name);
                    break;
            }

            return sortItem.ToList();
        }
    }
}   