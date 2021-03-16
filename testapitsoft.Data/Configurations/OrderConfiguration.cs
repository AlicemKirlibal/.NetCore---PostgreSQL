using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using testapitsoft.Core.Data.Entity;

namespace testapitsoft.Data.Configurations
{
    class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.CustomerId);
            builder.Property(x => x.CustomerId).UseIdentityAlwaysColumn();
            builder.Property(x => x.CustomerUsername);
            builder.Property(x => x.OrderId);
            builder.Property(x => x.OrderCode);
            builder.Property(x => x.OrderTotalPrice).HasColumnType("decimal (18,2)");

            builder.ToTable("Orders");
        }
    }
}
