using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleManager.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManager.Core.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.ProductId);
            builder.Property(x => x.ProductName).HasMaxLength(40).IsRequired();
            builder.Property(x => x.Weight).HasMaxLength(20).IsRequired();
            builder.Property(x => x.UnitPrice).IsRequired();
            builder.Property(x => x.UnitInStock).IsRequired();
        }
    }
}
