
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configs
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(x => x.Login).HasColumnType("varchar(20)");
            builder.Property(x => x.Password).HasColumnType("varchar(50)");
            builder.Property(x => x.FirstName).HasColumnType("varchar(40)");
            builder.Property(x => x.LastName).HasColumnType("varchar(40)");
            builder.Property(x => x.DateOfBirth).HasColumnType("date");
            builder.Property(x => x.Gender).HasColumnType("varchar(1)");
            builder.HasKey(x => x.UserID);
            builder.HasIndex(x => x.Login).IsUnique();
            
        }
    }
}
