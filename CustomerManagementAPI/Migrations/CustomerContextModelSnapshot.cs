﻿// <auto-generated />
using CustomerManagementAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CustomerManagementAPI.Migrations
{
    [DbContext(typeof(CustomerContext))]
    partial class CustomerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.4.21253.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CustomerManagementAPI.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Document")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Document = "0381298134",
                            Email = "amanda@gmail.com",
                            Name = "Amanda Gay",
                            Phone = "+1 888-452-1232"
                        },
                        new
                        {
                            Id = 2,
                            Document = "-1082451256",
                            Email = "amanda@yahoo.com",
                            Name = "Amanda MacDonald",
                            Phone = "+1 888-452-1232"
                        },
                        new
                        {
                            Id = 3,
                            Document = "-809430696",
                            Email = "carl@icloud.com",
                            Name = "Carl Strip",
                            Phone = "+1 888-452-1232"
                        },
                        new
                        {
                            Id = 4,
                            Document = "0580722840",
                            Email = "carl@icloud.com",
                            Name = "Carl Bailee",
                            Phone = "+1 888-452-1232"
                        },
                        new
                        {
                            Id = 5,
                            Document = "-114129484",
                            Email = "neil@outlook.com",
                            Name = "Neil Bailee",
                            Phone = "+1 888-452-1232"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
