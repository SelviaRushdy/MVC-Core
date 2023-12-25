using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_Core.Entities;
using MVC_Core.Models;

namespace MVC_Core.DbContexts
{
    public class StoreContext : IdentityDbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
           : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasData(
                new Products()
                {
                    ID = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Name = "First Product",
                    Price = 1,
                    Quantity = 1,
                    ImgURL= "~/Images/Bitmap.png",
                    CateogryID = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b")

                },
                new Products()
                {
                    ID = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Name = "Second Product",
                    Price = 1,
                    Quantity = 1,
                    ImgURL = "~/Images/shutterstock_662279290.png",
                    CateogryID = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b")

                },
                new Products()
                {
                    ID = Guid.Parse("7b64ea50-2014-4431-9f50-7e6020e9a220"),
                    Name = "Third Product",
                    Price = 1,
                    Quantity = 1,
                    ImgURL = "~/Images/shutterstock_662279290.png",
                    CateogryID = Guid.Parse("f62ba323-2be2-4ab2-b9f8-cfe023c17a66")

                }
             );

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    ID = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                    Name = "First Category",

                },
                 new Category()
                 {
                     ID = Guid.Parse("f62ba323-2be2-4ab2-b9f8-cfe023c17a66"),
                     Name = "Second Category",

                 }
             );
            base.OnModelCreating(modelBuilder);
        }


    }

}