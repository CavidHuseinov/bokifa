﻿// <auto-generated />
using System;
using Bookifa.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bokifa.Persistance.Migrations
{
    [DbContext(typeof(BookifaDbContext))]
    [Migration("20250409132558_asdad")]
    partial class asdad
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bokifa.Domain.Entities.Banner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BtnName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrimaryLanguageType")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Banners");
                });

            modelBuilder.Entity("Bokifa.Domain.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PrimaryLanguageType")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Bokifa.Domain.Entities.BookAndCategory", b =>
                {
                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BookId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("BookAndCategories");
                });

            modelBuilder.Entity("Bokifa.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrimaryLanguageType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Bokifa.Domain.Entities.HeadBanner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LanguageType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("HeadBanners");
                });

            modelBuilder.Entity("Bokifa.Domain.Entities.TBanner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BannerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BtnName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LanguageType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BannerId");

                    b.ToTable("TBanners");
                });

            modelBuilder.Entity("Bokifa.Domain.Entities.TBook", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LanguageType")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("TBooks");
                });

            modelBuilder.Entity("Bokifa.Domain.Entities.TCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LanguageType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("TCategory");
                });

            modelBuilder.Entity("Bokifa.Domain.Entities.THeadBanner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("HeadBannerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LanguageType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HeadBannerId");

                    b.ToTable("THeadBanners");
                });

            modelBuilder.Entity("Bookifa.Domain.Entities.Identity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ExpirationRefreshTokenDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Bokifa.Domain.Entities.Banner", b =>
                {
                    b.OwnsOne("Bookifa.Domain.ValueObjects.CreatedAtVO", "CreatedAt", b1 =>
                        {
                            b1.Property<Guid>("BannerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("datetime2")
                                .HasColumnName("CreatedAt");

                            b1.HasKey("BannerId");

                            b1.ToTable("Banners");

                            b1.WithOwner()
                                .HasForeignKey("BannerId");
                        });

                    b.Navigation("CreatedAt")
                        .IsRequired();
                });

            modelBuilder.Entity("Bokifa.Domain.Entities.Book", b =>
                {
                    b.OwnsOne("Bookifa.Domain.ValueObjects.CreatedAtVO", "CreatedAt", b1 =>
                        {
                            b1.Property<Guid>("BookId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("datetime2")
                                .HasColumnName("CreatedAt");

                            b1.HasKey("BookId");

                            b1.ToTable("Books");

                            b1.WithOwner()
                                .HasForeignKey("BookId");
                        });

                    b.Navigation("CreatedAt")
                        .IsRequired();
                });

            modelBuilder.Entity("Bokifa.Domain.Entities.BookAndCategory", b =>
                {
                    b.HasOne("Bokifa.Domain.Entities.Book", "Book")
                        .WithMany("BookAndCategories")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bokifa.Domain.Entities.Category", "Category")
                        .WithMany("BookAndCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Bokifa.Domain.Entities.Category", b =>
                {
                    b.OwnsOne("Bookifa.Domain.ValueObjects.CreatedAtVO", "CreatedAt", b1 =>
                        {
                            b1.Property<Guid>("CategoryId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("datetime2")
                                .HasColumnName("CreatedAt");

                            b1.HasKey("CategoryId");

                            b1.ToTable("Categories");

                            b1.WithOwner()
                                .HasForeignKey("CategoryId");
                        });

                    b.Navigation("CreatedAt")
                        .IsRequired();
                });

            modelBuilder.Entity("Bokifa.Domain.Entities.HeadBanner", b =>
                {
                    b.OwnsOne("Bookifa.Domain.ValueObjects.CreatedAtVO", "CreatedAt", b1 =>
                        {
                            b1.Property<Guid>("HeadBannerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("datetime2")
                                .HasColumnName("CreatedAt");

                            b1.HasKey("HeadBannerId");

                            b1.ToTable("HeadBanners");

                            b1.WithOwner()
                                .HasForeignKey("HeadBannerId");
                        });

                    b.Navigation("CreatedAt")
                        .IsRequired();
                });

            modelBuilder.Entity("Bokifa.Domain.Entities.TBanner", b =>
                {
                    b.HasOne("Bokifa.Domain.Entities.Banner", "Banner")
                        .WithMany("TBanners")
                        .HasForeignKey("BannerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Bookifa.Domain.ValueObjects.CreatedAtVO", "CreatedAt", b1 =>
                        {
                            b1.Property<Guid>("TBannerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("datetime2")
                                .HasColumnName("CreatedAt");

                            b1.HasKey("TBannerId");

                            b1.ToTable("TBanners");

                            b1.WithOwner()
                                .HasForeignKey("TBannerId");
                        });

                    b.Navigation("Banner");

                    b.Navigation("CreatedAt")
                        .IsRequired();
                });

            modelBuilder.Entity("Bokifa.Domain.Entities.TBook", b =>
                {
                    b.HasOne("Bokifa.Domain.Entities.Book", "Book")
                        .WithMany("TBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Bookifa.Domain.ValueObjects.CreatedAtVO", "CreatedAt", b1 =>
                        {
                            b1.Property<Guid>("TBookId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("datetime2")
                                .HasColumnName("CreatedAt");

                            b1.HasKey("TBookId");

                            b1.ToTable("TBooks");

                            b1.WithOwner()
                                .HasForeignKey("TBookId");
                        });

                    b.Navigation("Book");

                    b.Navigation("CreatedAt")
                        .IsRequired();
                });

            modelBuilder.Entity("Bokifa.Domain.Entities.TCategory", b =>
                {
                    b.HasOne("Bokifa.Domain.Entities.Category", "Category")
                        .WithMany("TCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Bookifa.Domain.ValueObjects.CreatedAtVO", "CreatedAt", b1 =>
                        {
                            b1.Property<Guid>("TCategoryId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("datetime2")
                                .HasColumnName("CreatedAt");

                            b1.HasKey("TCategoryId");

                            b1.ToTable("TCategory");

                            b1.WithOwner()
                                .HasForeignKey("TCategoryId");
                        });

                    b.Navigation("Category");

                    b.Navigation("CreatedAt")
                        .IsRequired();
                });

            modelBuilder.Entity("Bokifa.Domain.Entities.THeadBanner", b =>
                {
                    b.HasOne("Bokifa.Domain.Entities.HeadBanner", "HeadBanner")
                        .WithMany("THeadBanners")
                        .HasForeignKey("HeadBannerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("Bookifa.Domain.ValueObjects.CreatedAtVO", "CreatedAt", b1 =>
                        {
                            b1.Property<Guid>("THeadBannerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("datetime2")
                                .HasColumnName("CreatedAt");

                            b1.HasKey("THeadBannerId");

                            b1.ToTable("THeadBanners");

                            b1.WithOwner()
                                .HasForeignKey("THeadBannerId");
                        });

                    b.Navigation("CreatedAt")
                        .IsRequired();

                    b.Navigation("HeadBanner");
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
                    b.HasOne("Bookifa.Domain.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Bookifa.Domain.Entities.Identity.AppUser", null)
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

                    b.HasOne("Bookifa.Domain.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Bookifa.Domain.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bokifa.Domain.Entities.Banner", b =>
                {
                    b.Navigation("TBanners");
                });

            modelBuilder.Entity("Bokifa.Domain.Entities.Book", b =>
                {
                    b.Navigation("BookAndCategories");

                    b.Navigation("TBooks");
                });

            modelBuilder.Entity("Bokifa.Domain.Entities.Category", b =>
                {
                    b.Navigation("BookAndCategories");

                    b.Navigation("TCategories");
                });

            modelBuilder.Entity("Bokifa.Domain.Entities.HeadBanner", b =>
                {
                    b.Navigation("THeadBanners");
                });
#pragma warning restore 612, 618
        }
    }
}
