using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rent_for_students.Infrastructure.Data;

#nullable disable

namespace rent_for_students.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "10.0.3");

            modelBuilder.Entity("rent_for_students.Domain.Entities.HousingListing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AreaSqm")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<string>("District")
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("PricePerMonth")
                        .HasPrecision(12, 2)
                        .HasColumnType("TEXT");

                    b.Property<int>("RoomType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("City");

                    b.HasIndex("IsActive");

                    b.HasIndex("PricePerMonth");

                    b.ToTable("HousingListings");
                });

            modelBuilder.Entity("rent_for_students.Domain.Entities.RentalApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ApplicantName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ListingId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Message")
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CreatedAtUtc");

                    b.HasIndex("ListingId");

                    b.ToTable("RentalApplications");
                });

            modelBuilder.Entity("rent_for_students.Domain.Entities.RentalApplication", b =>
                {
                    b.HasOne("rent_for_students.Domain.Entities.HousingListing", null)
                        .WithMany()
                        .HasForeignKey("ListingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
