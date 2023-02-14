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
    internal class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Member");
            builder.HasKey(x => x.MemberId);
            builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
            builder.Property(x => x.Country).HasMaxLength(15).IsRequired();
            builder.Property(x => x.City).HasMaxLength(15).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(30).IsRequired();
        }
    }
}
