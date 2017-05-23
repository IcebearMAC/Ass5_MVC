using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ass5_MVC.Models
{
    public class StockItem
    {
        [Key]
        public int ArticleNumber { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ShelfPosition { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}

