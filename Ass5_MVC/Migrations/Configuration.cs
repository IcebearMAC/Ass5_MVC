namespace Ass5_MVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Ass5_MVC.DataAccess.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Ass5_MVC.DataAccess.StoreContext context)
        {
            context.Item.AddOrUpdate(
            p => p.ArticleNumber,
                    new Models.StockItem { ArticleNumber = 111, Name = "Cigarett lighters", Price = 123.12, ShelfPosition = "A1", Quantity = 10, Description = "Good to have if you want to light your candels" },
                    new Models.StockItem { ArticleNumber = 222, Name = "Candels Large", Price = 234.23, ShelfPosition = "B2", Quantity = 11, Description = "Candels for candelabra" },
                    new Models.StockItem { ArticleNumber = 333, Name = "Candels Medium", Price = 345.34, ShelfPosition = "C3", Quantity = 12, Description = "Candels for a ordinary candel holder" },
                    new Models.StockItem { ArticleNumber = 444, Name = "Candels Small", Price = 456.45, ShelfPosition = "D4", Quantity = 13, Description = "A small candel to put in a " },
                    new Models.StockItem { ArticleNumber = 555, Name = "Candel Oil", Price = 567.56, ShelfPosition = "E5", Quantity = 14, Description = "Candel to put on a grave" }
            );
        }
    }
}
