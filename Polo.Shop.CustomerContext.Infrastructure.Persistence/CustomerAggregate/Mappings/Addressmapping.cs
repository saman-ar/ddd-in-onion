using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Polo.Framework.Persistence;
using Polo.Shop.CustomerContext.Domain.CustomerAggregate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Polo.Shop.CustomerContext.Infrastructure.Persistence.CustomerAggregate.Mappings
{
   public class AddressMapping : EntityMappingBase<Address>  , IEntityTypeConfiguration<Address>
   {
      public void Configure(EntityTypeBuilder<Address> builder)
      {
         //builder.HasKey(a => a.Id);

         //builder.Property(a => a.Id)
         //       .HasColumnType(SqlDbType.UniqueIdentifier.ToString())
         //       .ValueGeneratedNever()
         //       .IsRequired();

         builder.Property(a => a.Coordinate)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(30)
                .IsRequired(false);

         builder.Property(a => a.Telephone)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(10)
                .IsRequired(false);

         builder.Property(a => a.AddressLine)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(500)
                .IsRequired();

         builder.Property(a => a.CityId)
                .HasColumnType(SqlDbType.Int.ToString())
                .IsRequired();

         builder.Property(a => a.PostalCode)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(10)
                .IsRequired();

         ///adding this line of code is so important , dont forget this
         base.Configure(builder);
      }
   }
}
