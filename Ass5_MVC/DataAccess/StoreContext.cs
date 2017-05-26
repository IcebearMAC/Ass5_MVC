using Ass5_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ass5_MVC.DataAccess
{
    public class StoreContext : DbContext
    {
        public DbSet<StockItem> Item { get; set; }
            
        public StoreContext() : base("DefaultConnection")
        {
        }
    }
}