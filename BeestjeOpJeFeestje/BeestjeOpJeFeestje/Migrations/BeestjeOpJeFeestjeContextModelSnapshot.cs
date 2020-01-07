﻿// <auto-generated />
using BeestjeOpJeFeestje.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeestjeOpJeFeestje.Migrations
{
    [DbContext(typeof(BeestjeOpJeFeestjeContext))]
    partial class BeestjeOpJeFeestjeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BeestjeOpJeFeestje.Models.Accessories", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PicturePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("Accessorieses");
                });

            modelBuilder.Entity("BeestjeOpJeFeestje.Models.Animal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("PicturePath")
                        .HasColumnName("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("ID");

                    b.ToTable("Animal");
                });

            modelBuilder.Entity("BeestjeOpJeFeestje.Models.AnimalAccessories", b =>
                {
                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<int>("AccessoriesId")
                        .HasColumnType("int");

                    b.HasKey("AnimalId", "AccessoriesId");

                    b.HasIndex("AccessoriesId");

                    b.ToTable("AnimalAccessories");
                });

            modelBuilder.Entity("BeestjeOpJeFeestje.Models.AnimalAccessories", b =>
                {
                    b.HasOne("BeestjeOpJeFeestje.Models.Accessories", "Accessories")
                        .WithMany("AnimalAccessories")
                        .HasForeignKey("AccessoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeestjeOpJeFeestje.Models.Animal", "Animal")
                        .WithMany("AnimalAccessories")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
