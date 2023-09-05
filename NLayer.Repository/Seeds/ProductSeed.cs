using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NlayerCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id=1,CategoryId=1,Name="Kalem A",Price=100,Stock=20,CreateDate=DateTime.Now},
                new Product { Id=2,CategoryId=1,Name="Kalem B",Price=100,Stock=20,CreateDate=DateTime.Now},
                new Product { Id=3,CategoryId=1,Name="Kalem C",Price=100,Stock=20,CreateDate=DateTime.Now},
                new Product { Id=4,CategoryId=1,Name="Kalem C",Price=100,Stock=20,CreateDate=DateTime.Now},
                new Product { Id=5,CategoryId=2,Name="Silgi C",Price=100,Stock=20,CreateDate=DateTime.Now},
                new Product { Id=6,CategoryId=2,Name= "Silgi C", Price=100,Stock=20,CreateDate=DateTime.Now},
                new Product { Id=7,CategoryId=2,Name= "Silgi C", Price=100,Stock=20,CreateDate=DateTime.Now},
                new Product { Id=8,CategoryId=3,Name="Defter A",Price=100,Stock=20,CreateDate=DateTime.Now}
                );
        }
    }
}
