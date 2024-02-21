using Database.Data;
using Microsoft.EntityFrameworkCore;


DataContext db = new DataContext();
var list = db.Products
             .Include(i => i.Categories)
             .SelectMany(x => x.Categories.DefaultIfEmpty(), (x, c) => new { Product = x.Name, Category = c.Name })
             .ToList();
       
foreach(var item in list)
    Console.WriteLine($"{item.Product}   |   {item.Category}");
