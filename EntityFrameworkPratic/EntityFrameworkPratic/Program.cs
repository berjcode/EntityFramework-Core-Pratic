﻿// See https://aka.ms/new-console-template for more information
using EntityFrameworkPratic.DAL;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

using (var _context = new AppDbContext())
{
    // ------------------------------------------------------------------------------------------\\
    //Listeleme 
    //var products = _context.Products.ToList();

    //foreach(var item in products)
    //{
    //    Console.Write($"Ürün Adı: {item.Name}, Ürün Tutaru: {item.Price} \n"  );
    //}
    // ------------------------------------------------------------------------------------------\\
    //Id'sini bul getir.
    //var products = _context.Products.Find(1);

    //Console.WriteLine(products.Name);

    // ------------------------------------------------------------------------------------------\\

    // Ürün Ekleme ve state'ler

    //var newProducts = new Product { Name = "Masa", Price = 12, };

    //Console.WriteLine($"İlkState : {_context.Entry(newProducts).State}");

    //await _context.AddAsync(newProducts);

    //Console.WriteLine($"Ekledikten Sonra State: {_context.Entry(newProducts).State}");

    //await _context.SaveChangesAsync();

    //Console.WriteLine($"Kaydettikten sonraki state: {_context.Entry(newProducts).State}");

    // ------------------------------------------------------------------------------------------\\
    //AsnoTracking() Kullan, İzlemeyi engeller. Bu Sayede performans sağlar. Verileri  hepsini getirmek yerine
    // Where veya sayfalama kullan bu sayede sisteme performans sağlarsın.

    //var products = _context.Products.AsNoTracking().ToList();

    //foreach (var item in products)
    //{
    //    Console.WriteLine($"ürün adı: {item.Name}, ürün tutaru: {item.Price} \n");
    //}


    //ChangeTracker  : Entity Framework'ün tüm entity ve propertyler üzerinde uygulanan tüm değişiklikleri izleyerek, bu değişimleri veri kaynağına doğru bir şekilde yansıtabilmek ve uygun DML (Data Manipulation Language) ifadeleri oluşturabilmektir.


    //EagerLoading
    //var products = _context.Products.Include(x => x.Category).Include(x=>x.ProductFeature).ToList();

    //foreach (var item in products)
    //{

    //    Console.Write($"Ürün Adı: {item.Name}, Ürün Tutaru: {item.Price} , Ürun Stoğu : {item.stock}, Kategori :{item.Category.Name}  , Boyutu : {item.ProductFeature.Width},Renk :{ item.ProductFeature.Color} \n");
    //}


    //Explicit Loading

    // Sadece gerekeen aşamadaki verileri ilişki ile çeker

    //var category = _context.Categories.First();

    //if(true)
    //{
    //    //1-n İlişkide collection kullanılır.  1-1 ilişkide reference kullanılır. ürünleri üzerinden yapsaydık. 
    //    _context.Entry(category).Collection(x=>x.Products).Load();
    //category.Products.ForEach(x =>
    //{
    //    Console.WriteLine(x.Name);
    //});

    //}



    //var result = _context.Categories
    //    .Join(_context.Products, x => x.Id, y => y.CategoryId, (c, p) => new
    //    { c, p })
    //.Join(_context.ProductFeatures, x => x.p.Id, y => y.Id, (c, pf) => new
    //{

    //    CategoryName = c.c.Name,
    //    CategoryDescription = c.c.Description,
    //    ProductName = c.p.Name,
    //    ProductPrice = c.p.Price,
    //    ProductFeature = pf.Product,
    //    ProductColor = pf.Color

    //}) ;

    //foreach(var item in result)
    //{
    //    Console.WriteLine($"Kategori Adı: {item.CategoryName}, Kategori Açıklaması : {item.CategoryDescription}, Ürün Adı : {item.ProductName} , Ürün Fiyatı : {item.ProductPrice}, Ürün Rengi : {item.ProductColor}");
    //}

    //Join 2

    //var result = (from c in _context.Categories
    //              join p in _context.Products on c.Id equals p.CategoryId
    //              join pf in _context.ProductFeatures on p.Id equals pf.Id
    //              select new { c, p, pf }).ToList();


    //foreach(var item in result)
    //{

    //    Console.WriteLine($"Kategori Adı: {item.c.Name}, Kategori Açıklaması : {item.c.Description}, Ürün Adı : {item.p.Name} , Ürün Fiyatı : {item.p.Price}, Ürün Rengi : {item.pf.Color}");
    //}


   // var result = _context.Products.FromSqlRaw("Select * from Products ").ToList();

    var id = 1;

    //var result2 = _context.Products.FromSqlRaw("Select * from Products  where Id = {0}", id).ToList();

    var price = 1;

    // var result3 = _context.ProductsEssentials.FromSqlInterpolated($"select Id,Name,Price from products where price > {price}  ").ToList();

    //  var result3 = _context.ProductsEssentials.FromSqlInterpolated($"select Id,Name,Price from products where Name = 'Bilgisayar'  ").ToList();

    //var result3 = _context.productWithFeatures.FromSqlRaw("select P.Id,  P.Name, p.Price,pf.Color ,PF.Height from Products p inner join ProductFeatures pf on p.Id = pf.Id").ToList();

    //Category category = new Category();
    //category.Name = "Ev Eşyası";
    //category.Description= "Evinizi şimartın";
    //_context.Categories.Add(category);
    _context.Products.Add(new Product() { Name = "Dolap", Price =1000,stock=123,CategoryId =2});
    _context.SaveChanges();
    
    Console.WriteLine("x");
}