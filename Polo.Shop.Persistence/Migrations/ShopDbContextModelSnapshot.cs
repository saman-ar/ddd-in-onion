// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Polo.Shop.Persistence;

namespace Polo.Shop.Persistence.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    partial class ShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Polo.Shop.CustomerContext.Domain.CustomerAggregate.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("UniqueIdentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVarChar")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("NVarChar")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("NVarChar")
                        .HasMaxLength(50);

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasColumnType("Char")
                        .HasMaxLength(10);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("NVarChar")
                        .HasMaxLength(50);

                    b.Property<int>("Score")
                        .HasColumnType("Int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer","CustomerContext");
                });

            modelBuilder.Entity("Polo.Shop.CustomerContext.Domain.CustomerAggregate.Customer", b =>
                {
                    b.OwnsMany("Polo.Shop.CustomerContext.Domain.CustomerAggregate.Address", "Addresses", b1 =>
                        {
                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("AddressLine")
                                .IsRequired()
                                .HasColumnType("VarChar")
                                .HasMaxLength(500);

                            b1.Property<int>("CityId")
                                .HasColumnType("Int");

                            b1.Property<string>("Coordinate")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("UniqueIdentifier");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("VarChar")
                                .HasMaxLength(10);

                            b1.Property<string>("Telephone")
                                .HasColumnType("VarChar")
                                .HasMaxLength(10);

                            b1.HasKey("Id");

                            b1.HasIndex("CustomerId");

                            b1.ToTable("Address");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
