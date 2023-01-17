// See https://aka.ms/new-console-template for more information
using EntityFrameworkPratic.DAL;

Console.WriteLine("Hello, World!");

using (var _context = new AppDbContext())
{

    //Listeleme 
    //var products = _context.Products.ToList();

    //foreach(var item in products)
    //{
    //    Console.Write($"Ürün Adı: {item.Name}, Ürün Tutaru: {item.Price} \n"  );
    //}

    //Id'sini bul getir.
    //var products = _context.Products.Find(1);

    //Console.WriteLine(products.Name);



}