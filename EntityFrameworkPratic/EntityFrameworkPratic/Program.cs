// See https://aka.ms/new-console-template for more information
using EntityFrameworkPratic.DAL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

Console.WriteLine("Hello, World!");

using (var _context = new AppDbContext())
{
    // veri ekle 
    // ilk önce dbcontext'ten bir nesne  oluştur.  ardından entity nesnesinin örneğini  oluştur ve context üzerinden gerekli methodu cğır. add veya addasync 

    //Entity oluşturuken primary key tanımlanmalıdır. 

    //savechanges : insert, update ve delete sorgularını oluştuurp bir transaction eşliğinde veritabanına gönderip execute eden bir fonskiyon.
    /// Yapılan tüm işlemleri tek bir savechanges ile bitir.

    /// await context.Prducts.AddRangeAsync(urun1,urun2,urun3);
    /// await.saveschagersasync();
    /// firstOrDefault = verilen şarta uygun ilk veriyi getirir.
    /// changertracker : contex üzerinden gelen verileirn takibinden sorumlu  bir mekanizmadır. Context üzerinden gelen verilerle ilgili işlemler neticesinde update,delete oluşturulacağı anlaşılır.



    // Defered execution ertelenmiş çalışma

    //IQUERYABLE ÇALIŞMALARINDA İLGİLİ KOD YAZILDIĞI NOKTADA TETİKLENMEZ YANİ İLGİLİ KOD YAZILDIĞI NOKTADA SORGUYU GENERATE ETMEZ.
    //ÇALIŞTIRILDIĞI EXECUTE EDİLDİĞİ NOKTADA TETİKLENİR. Bu duruma defered execution denir.

    //   IQueryable

    //Sorguya karşılık gelir. Ef core üzerinden yapılmış olan sorgunun execute edilmemiş halini ifade eder.


    //IEnumerable
    //Sorgunun çalıştırlıp verilerin memory yüklenmiş halini ifade eder.



    //Sorgu oluşturma noktası queryable, sonuna tolist eklediğin zaman execute etmiş olurusn o zama n enurable olur

    //IQueryable

    //Var urunler = from urun in context.urunler select urun;

    //    Foreach(Urun urun in urunler)
    //     {
    //        Console.writeline(urun.urunadı);
    //    }


    //IEnumerable

 //var  RESULT1=  _context.Products.ToList();


    //IQueryable
    var result2 = from product in _context.Products select product;



    foreach(Product product in  result2)
    {
        Console.WriteLine(product.Name);
    }






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

    //var id = 1;

    //var result2 = _context.Products.FromSqlRaw("Select * from Products  where Id = {0}", id).ToList();

    //var price = 1;

    // var result3 = _context.ProductsEssentials.FromSqlInterpolated($"select Id,Name,Price from products where price > {price}  ").ToList();

    //  var result3 = _context.ProductsEssentials.FromSqlInterpolated($"select Id,Name,Price from products where Name = 'Bilgisayar'  ").ToList();

    //var result3 = _context.productWithFeatures.FromSqlRaw("select P.Id,  P.Name, p.Price,pf.Color ,PF.Height from Products p inner join ProductFeatures pf on p.Id = pf.Id").ToList();

    //Category category = new Category();
    //category.Name = "Ev Eşyası";
    //category.Description= "Evinizi şimartın";

    //_context.Categories.Add(category);

    //Sorgu pratik
    //var category = _context.Categories.First(x=> x.Name == "Ev Eşyası");
    //_context.Products.Add(new Product() { Name = "Dolap", Price = 1000, stock = 123, CategoryId = 2 } );
    //_context.SaveChanges();


    //var products = _context.Products.FromSqlRaw("exec sp_Get_Products").ToList();

    // var xy = products.Where(x=> x.Price > 200 );
    //var product = new Product()
    //{
    //    Name = "Camaşır Makinesi",
    //    Price =25166,
    //    stock= 154,
    //    CategoryId= 2,
    //};

    //var newProductId = new SqlParameter("@newId",SqlDbType.Int);
    //newProductId.Direction = ParameterDirection.Output;

    //_context.Database.ExecuteSqlInterpolated($"exec sp_insert_products  {product.Name}, {product.Price},{product.stock},{product.CategoryId},{newProductId} out");
    //var newProductIdS = newProductId.Value;

    //  _context.Database.ExecuteSqlInterpolated($"sp_insert_products2 {product.Name}, {product.Price},{product.stock},{product.CategoryId} ");

    //  Console.WriteLine("");
}