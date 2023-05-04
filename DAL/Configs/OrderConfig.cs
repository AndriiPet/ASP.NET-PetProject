
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configs
{
    internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.Property(x => x.OrderID).HasColumnType("int");
            builder.Property(x => x.UserID).HasColumnType("int");
            builder.Property(x => x.OrderDate).HasColumnType("datetime");
            builder.Property(x => x.OrderCost).HasColumnType("money");
            builder.Property(x => x.ItemsDescription).HasColumnType("varchar(1000)");
            builder.Property(x => x.ShippingAddress).HasColumnType("varchar(1000)");


        }
    }
}
