using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Polo.Framework.Persistence;
using Polo.Shop.CustomerContext.Domain.CustomerAggregate;
using System.Collections.Generic;
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

         //builder.HasIndex(c => c.NationalCode).IsUnique();

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

         ///map Address as Value object in customer entity
         builder.OwnsMany(a => a.Addresses, map =>
         {
            map.ToTable("Address").HasKey("Id");
            map.Property<long>("Id").ValueGeneratedOnAdd();
            map.WithOwner().HasForeignKey(c=>c.CustomerId);

            //map.Property(a => a.PostalCode);
            //map.Property(a => a.AddressLine);
            //map.Property(a => a.CityId);
            //map.Property(a => a.Coordinate);
            //map.Property(a => a.Telephone);

            map.Property(a => a.CityId);

            map.Property(a => a.Telephone)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(10)
                .IsRequired(false);

            map.Property(a => a.AddressLine)
                   .HasColumnType(SqlDbType.VarChar.ToString())
                   .HasMaxLength(500)
                   .IsRequired();

            map.Property(a => a.CityId)
                   .HasColumnType(SqlDbType.Int.ToString())
                   .IsRequired();

            map.Property(a => a.PostalCode)
                   .HasColumnType(SqlDbType.VarChar.ToString())
                   .HasMaxLength(10)
                   .IsRequired();

            map.UsePropertyAccessMode(PropertyAccessMode.Field);
         });


         ///این ارتباط باید در طرف customer اضافه شود زیرا در طرف Address 
         ///navigation وجود ندارد
         //builder.HasMany(c=>c.Addresses)
         //      .WithOne()
         //      .HasForeignKey(a => a.CustomerId)
         //      .OnDelete(DeleteBehavior.Cascade);

         /////set address property getter to its field
         //builder.Metadata
         //      .FindNavigation("Addresses")
         //      .SetPropertyAccessMode(PropertyAccessMode.Field);



         builder.Property(c => c.Score)
               .HasColumnType(SqlDbType.Int.ToString())
               .IsRequired();

         //builder.ToTable(nameof(Customer), nameof(CustomerContext));

         ///adding this line of code is so important , dont forget this
         base.Configure(builder);
      }
   }
}
