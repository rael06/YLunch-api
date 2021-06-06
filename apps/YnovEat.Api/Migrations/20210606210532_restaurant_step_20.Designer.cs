﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YnovEat.Infrastructure.Database;

namespace YnovEat.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210606210532_restaurant_step_20")]
    partial class restaurant_step_20
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.CustomerAggregate.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDatetime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.CustomerAggregate.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("CustomerCategoryId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.CustomerAggregate.CustomerCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("CustomerCategories");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.CustomerAggregate.CustomerProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<int>("RestaurantProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("OrderId");

                    b.ToTable("CustomerProduct");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.ClosingDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("ClosingDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("ClosingDates");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.DayOpeningHours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DayIndex")
                        .HasColumnType("int");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("DayOpeningHours");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.OpeningHour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("DayOpeningHoursId")
                        .HasColumnType("int");

                    b.Property<int>("HourInMinutes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DayOpeningHoursId");

                    b.ToTable("OpeningHours");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerId1")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("IsPassed")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId1");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderStatus");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("EmailConfirmationDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ExtraInformation")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsEmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastUpdateDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MainAdminId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("OrderLimitTimeInMinutes")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<string>("StreetName")
                        .HasColumnType("longtext");

                    b.Property<string>("StreetNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("ZipCode")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MainAdminId")
                        .IsUnique();

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.RestaurantCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("RestaurantCategories");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.RestaurantProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ExpirationDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("RestaurantProducts");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.RestaurantProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int?>("RestaurantProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("RestaurantProductId");

                    b.ToTable("RestaurantProductCategories");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.RestaurantProduct_RestaurantProductCategory", b =>
                {
                    b.Property<int>("RestaurantProductId")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantProductCategoryId")
                        .HasColumnType("int");

                    b.HasKey("RestaurantProductId", "RestaurantProductCategoryId");

                    b.HasIndex("RestaurantProductCategoryId");

                    b.ToTable("RestaurantProduct_RestaurantProductCategory_Links");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.Restaurant_RestaurantCategory", b =>
                {
                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantCategoryId")
                        .HasColumnType("int");

                    b.HasKey("RestaurantId", "RestaurantCategoryId");

                    b.HasIndex("RestaurantCategoryId");

                    b.ToTable("Restaurant_RestaurantCategory_Links");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.UserAggregate.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ConfirmationDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<DateTime>("EmailConfirmationDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Firstname")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastUpdateDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Lastname")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("PhoneNumberConfirmationDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("RestaurantId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("YnovEat.Domain.ModelsAggregate.UserAggregate.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("YnovEat.Domain.ModelsAggregate.UserAggregate.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YnovEat.Domain.ModelsAggregate.UserAggregate.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("YnovEat.Domain.ModelsAggregate.UserAggregate.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.CustomerAggregate.Cart", b =>
                {
                    b.HasOne("YnovEat.Domain.ModelsAggregate.UserAggregate.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.CustomerAggregate.Customer", b =>
                {
                    b.HasOne("YnovEat.Domain.ModelsAggregate.CustomerAggregate.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId");

                    b.HasOne("YnovEat.Domain.ModelsAggregate.CustomerAggregate.CustomerCategory", "CustomerCategory")
                        .WithMany("Customer")
                        .HasForeignKey("CustomerCategoryId");

                    b.Navigation("Cart");

                    b.Navigation("CustomerCategory");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.CustomerAggregate.CustomerProduct", b =>
                {
                    b.HasOne("YnovEat.Domain.ModelsAggregate.CustomerAggregate.Cart", "Cart")
                        .WithMany("Products")
                        .HasForeignKey("CartId");

                    b.HasOne("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.Order", "Order")
                        .WithMany("CustomerProducts")
                        .HasForeignKey("OrderId");

                    b.Navigation("Cart");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.ClosingDate", b =>
                {
                    b.HasOne("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.Restaurant", "Restaurant")
                        .WithMany("ClosingDates")
                        .HasForeignKey("RestaurantId");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.DayOpeningHours", b =>
                {
                    b.HasOne("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.Restaurant", "Restaurant")
                        .WithMany("DaysOpeningHours")
                        .HasForeignKey("RestaurantId");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.OpeningHour", b =>
                {
                    b.HasOne("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.DayOpeningHours", "DayOpeningHours")
                        .WithMany("OpeningHours")
                        .HasForeignKey("DayOpeningHoursId");

                    b.Navigation("DayOpeningHours");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.Order", b =>
                {
                    b.HasOne("YnovEat.Domain.ModelsAggregate.CustomerAggregate.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId1");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.OrderStatus", b =>
                {
                    b.HasOne("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.Order", "Order")
                        .WithMany("OrderStatuses")
                        .HasForeignKey("OrderId");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.Restaurant", b =>
                {
                    b.HasOne("YnovEat.Domain.ModelsAggregate.UserAggregate.User", "MainAdmin")
                        .WithOne("Restaurant")
                        .HasForeignKey("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.Restaurant", "MainAdminId");

                    b.Navigation("MainAdmin");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.RestaurantProduct", b =>
                {
                    b.HasOne("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.Restaurant", "Restaurant")
                        .WithMany("Products")
                        .HasForeignKey("RestaurantId");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.RestaurantProductCategory", b =>
                {
                    b.HasOne("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.Restaurant", "Restaurant")
                        .WithMany("ProductCategories")
                        .HasForeignKey("RestaurantId");

                    b.HasOne("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.RestaurantProduct", null)
                        .WithMany("RestaurantProductCategories")
                        .HasForeignKey("RestaurantProductId");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.RestaurantProduct_RestaurantProductCategory", b =>
                {
                    b.HasOne("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.RestaurantProductCategory", "RestaurantProductCategory")
                        .WithMany()
                        .HasForeignKey("RestaurantProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.RestaurantProduct", "RestaurantProduct")
                        .WithMany("Restaurant_RestaurantProductCategory_Links")
                        .HasForeignKey("RestaurantProductId")
                        .HasConstraintName("FK_RestaurantProduct_RestaurantProductCategory_Links_Restauran~1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RestaurantProduct");

                    b.Navigation("RestaurantProductCategory");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.Restaurant_RestaurantCategory", b =>
                {
                    b.HasOne("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.RestaurantCategory", "RestaurantCategory")
                        .WithMany("Restaurant_RestaurantCategory_Links")
                        .HasForeignKey("RestaurantCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.Restaurant", "Restaurant")
                        .WithMany("Restaurant_RestaurantCategory_Links")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("RestaurantCategory");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.UserAggregate.User", b =>
                {
                    b.HasOne("YnovEat.Domain.ModelsAggregate.CustomerAggregate.Customer", "Customer")
                        .WithOne("User")
                        .HasForeignKey("YnovEat.Domain.ModelsAggregate.UserAggregate.User", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.Restaurant", null)
                        .WithMany("Users")
                        .HasForeignKey("RestaurantId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.CustomerAggregate.Cart", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.CustomerAggregate.Customer", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("User");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.CustomerAggregate.CustomerCategory", b =>
                {
                    b.Navigation("Customer");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.DayOpeningHours", b =>
                {
                    b.Navigation("OpeningHours");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.Order", b =>
                {
                    b.Navigation("CustomerProducts");

                    b.Navigation("OrderStatuses");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.Restaurant", b =>
                {
                    b.Navigation("ClosingDates");

                    b.Navigation("DaysOpeningHours");

                    b.Navigation("ProductCategories");

                    b.Navigation("Products");

                    b.Navigation("Restaurant_RestaurantCategory_Links");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.RestaurantCategory", b =>
                {
                    b.Navigation("Restaurant_RestaurantCategory_Links");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.RestaurantAggregate.RestaurantProduct", b =>
                {
                    b.Navigation("Restaurant_RestaurantProductCategory_Links");

                    b.Navigation("RestaurantProductCategories");
                });

            modelBuilder.Entity("YnovEat.Domain.ModelsAggregate.UserAggregate.User", b =>
                {
                    b.Navigation("Restaurant");
                });
#pragma warning restore 612, 618
        }
    }
}