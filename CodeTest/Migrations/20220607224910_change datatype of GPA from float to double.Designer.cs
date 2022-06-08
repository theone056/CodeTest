﻿// <auto-generated />
using CodeTest.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodeTest.Migrations
{
    [DbContext(typeof(CodeTestDbContext))]
    [Migration("20220607224910_change datatype of GPA from float to double")]
    partial class changedatatypeofGPAfromfloattodouble
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CodeTest.Models.Classes", b =>
                {
                    b.Property<string>("ClassName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Location")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("TeacherName")
                        .HasColumnType("varchar(50)");

                    b.HasKey("ClassName");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("CodeTest.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("ClassName")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(50)");

                    b.Property<double>("GPA")
                        .HasColumnType("float");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(50)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
