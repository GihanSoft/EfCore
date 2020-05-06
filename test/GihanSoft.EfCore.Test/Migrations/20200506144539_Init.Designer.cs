﻿// <auto-generated />
using GihanSoft.EfCore.Test;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GihanSoft.EfCore.Test.Migrations
{
    [DbContext(typeof(TestDbContext))]
    [Migration("20200506144539_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GihanSoft.EfCore.Test.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnName("lpzL089jAOzVyIBFnYGukCffdRdWMYShuLFSgtsjBiE=")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .HasColumnName("y6rTz0plB+XW+YFX+iVcqWRYjIww7PGY+5yY7ZdBP1k=")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .HasColumnName("1yD2HIxeKB4mchfy6OCQ6DIIdypR2GNDwrvxvQQPef4=")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnName("/x60CtDoxdsIVW2h5hgD6WyIoSDE6I3EMCMsWj1F21c=")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("e4ux+rg+mjrBH5lpmAjO3kbC7ZQoZy+2nGQctmRFPfA=");
                });
#pragma warning restore 612, 618
        }
    }
}
