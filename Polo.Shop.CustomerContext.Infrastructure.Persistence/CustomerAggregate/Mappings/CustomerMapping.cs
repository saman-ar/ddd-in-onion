using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Polo.Framework.Persistence;
using Polo.Shop.CustomerContext.Domain.CustomerAggregate;
using System.Data;

namespace Polo.Shop.CustomerContext.Infrastructure.Persistence.CustomerAggregate.Mappings
{
   public class CustomerMapping : EntityMappingBase<Customer> ,  IEntityTypeConfiguration<Customer>
   {
      public void Configure(EntityTypeBuilder<Customer> builder)
      {
         //builder.HasKey(c => c.Id);

         //builder.Property(c => c.Id)
         //       .HasColumnType(SqlDbType.UniqueIdentifier.ToString())
         //       .ValueGeneratedNever()
         //       .IsRequired();

         builder.Property(c => c.NationalCode)
               .HasMaxLength(10)
               .HasColumnType(SqlDbType.Char.ToString())
               .IsRequired();

         builder.Property(c => c.FirstName)
                .HasMaxLength(50)
                .HasColumnType(SqlDbType.NVarChar.ToString())
                .IsRequired();

         builder.Property(c => c.LastName)
               .HasMaxLength(50)
               .HasColumnType(SqlDbType.NVarChar.ToString())
               .IsRequired();

         builder.Property(c => c.Email)
               .HasMaxLength(50)
               .HasColumnType(SqlDbType.NVarChar.ToString())
               .IsRequired();

         builder.Property(c => c.Password)
               .HasMaxLength(50)
               .HasColumnType(SqlDbType.NVarChar.ToString())
               .IsRequired();

         ///این ارتباط باید در طرف customer اضافه شود زیرا در طرف Address 
         ///navigation وجود ندارد
         builder.HasMany(c => c.Addresses)
               .WithOne()
               .HasForeignKey(a => a.CustomerId)
               .OnDelete(DeleteBehavior.Cascade);

         //builder.ToTable(nameof(Customer), nameof(CustomerContext));

         base.Configure(builder);
      }
   }
}
