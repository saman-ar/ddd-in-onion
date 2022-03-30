using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Polo.Framework.Domain;
using System.Data;

namespace Polo.Framework.Persistence
{
   public abstract class EntityMappingBase<TEntity> : IEntityTypeConfiguration<TEntity>
      where TEntity : EntityBase
   {
      public void Configure(EntityTypeBuilder<TEntity> builder)
      {
         builder.HasKey(e => e.Id);

         builder.Property(e => e.Id)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString())
                .ValueGeneratedNever()
                .IsRequired();

         var schemaName = typeof(TEntity).Namespace.Split('.')[2];
         builder.ToTable(typeof(TEntity).Name, schemaName);
      }
   }
}
