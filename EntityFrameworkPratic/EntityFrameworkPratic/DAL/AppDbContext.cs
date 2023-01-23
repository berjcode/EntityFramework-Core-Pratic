
using EntityFrameworkPratic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPratic.DAL
{
    public class AppDbContext:DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Category>  Categories { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        //Tablo değil
        public DbSet<ProductsEssential> ProductsEssentials { get; set; }
        public DbSet<ProductWithFeature> productWithFeatures { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }    
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=berjcode;Initial Catalog=EntityFrameworkPratic3;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //1 - n ilişki 
            modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);

            // 1-1 ilişki 
            //ForeignKey  Ayrı
            // modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x=> x.ProductId);


            // Id İle Foreign key beraber

            //   modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.Id);

            // N-N İlişkilerde Fluent API

            modelBuilder.Entity<Student>()
                .HasMany(x => x.Teachers)
                .WithMany(x => x.Students)
                .UsingEntity<Dictionary<string, object>>(
                "StudentTeacherManyMany",
                x=> x.HasOne<Teacher>().WithMany().HasForeignKey("Teacher_Id").HasConstraintName("FK__TeacherId"),
                x=> x.HasOne<Student>().WithMany().HasForeignKey("Student_Id").HasConstraintName("FK__StudentId")

                );


            modelBuilder.Entity<ProductsEssential>().HasNoKey();
            modelBuilder.Entity<ProductWithFeature>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }
    }
}
