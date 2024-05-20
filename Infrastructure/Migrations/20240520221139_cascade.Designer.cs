﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240520221139_cascade")]
    partial class cascade
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ForumProject.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TopicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3de83fe1-7390-4cdf-84ef-c403ac9cce6c"),
                            Body = "lorem donec massa sapien faucibus et molestie ac feugiat sed lectus vestibulum mattis ullamcorper velit sed ullamcorper morbi tincidunt ornare massa eget egestas purus viverra",
                            PostDate = new DateTime(2024, 5, 21, 2, 11, 38, 674, DateTimeKind.Local).AddTicks(9357),
                            TopicId = new Guid("33b7ed72-9434-434a-82d4-3018b018cb87"),
                            UserId = "CD04B747-A694-4431-8C8A-7CBF278A3832"
                        },
                        new
                        {
                            Id = new Guid("b53a2b67-c7c7-4937-b2ee-275d66dd803e"),
                            Body = "imperdiet sed euismod nisi porta lorem mollis aliquam ut porttitor leo a diam sollicitudin tempor id eu nisl nunc mi ipsum faucibus vitae aliquet nec",
                            PostDate = new DateTime(2024, 5, 21, 2, 11, 38, 674, DateTimeKind.Local).AddTicks(9364),
                            TopicId = new Guid("33b7ed72-9434-434a-82d4-3018b018cb87"),
                            UserId = "230669E4-C593-4084-BACC-E5A1AD1AD494"
                        },
                        new
                        {
                            Id = new Guid("b7d286fe-6ac7-48ed-a29c-dfc475cea0bb"),
                            Body = "egestas erat imperdiet sed euismod nisi porta lorem mollis aliquam ut porttitor leo a diam sollicitudin tempor id eu nisl nunc mi ipsum faucibus vitae",
                            PostDate = new DateTime(2024, 5, 21, 2, 11, 38, 674, DateTimeKind.Local).AddTicks(9368),
                            TopicId = new Guid("0257e1e3-2135-444e-8854-dbc588a7b29b"),
                            UserId = "CD04B747-A694-4431-8C8A-7CBF278A3832"
                        },
                        new
                        {
                            Id = new Guid("fa088c36-d4f7-4dca-82d1-51c18c830c31"),
                            Body = "ac tincidunt vitae semper quis lectus nulla at volutpat diam ut venenatis tellus in metus vulputate",
                            PostDate = new DateTime(2024, 5, 21, 2, 11, 38, 674, DateTimeKind.Local).AddTicks(9374),
                            TopicId = new Guid("e18a5600-0d2a-4d43-b045-f7773c5c2d8d"),
                            UserId = "230669E4-C593-4084-BACC-E5A1AD1AD494"
                        },
                        new
                        {
                            Id = new Guid("5ce3ed72-1029-41a2-a957-e9d61928105f"),
                            Body = "imperdiet sed euismod nisi porta lorem mollis aliquam ut porttitor leo a diam sollicitudin tempor id eu nisl nunc mi ipsum faucibus vitae aliquet nec",
                            PostDate = new DateTime(2024, 5, 21, 2, 11, 38, 674, DateTimeKind.Local).AddTicks(9377),
                            TopicId = new Guid("5b365ad2-0264-46b2-86a8-c9c426ee88dd"),
                            UserId = "230669E4-C593-4084-BACC-E5A1AD1AD494"
                        },
                        new
                        {
                            Id = new Guid("76d4cf19-b62d-4a1d-a9fe-dd1f34009c41"),
                            Body = "imperdiet sed euismod nisi porta lorem mollis aliquam ut porttitor leo a diam sollicitudin tempor id eu nisl nunc mi ipsum faucibus vitae aliquet nec",
                            PostDate = new DateTime(2024, 5, 21, 2, 11, 38, 674, DateTimeKind.Local).AddTicks(9387),
                            TopicId = new Guid("5b365ad2-0264-46b2-86a8-c9c426ee88dd"),
                            UserId = "5CB83547-A7E4-4064-81AF-640D2B9ED831"
                        });
                });

            modelBuilder.Entity("ForumProject.Entities.Topic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Topics");

                    b.HasData(
                        new
                        {
                            Id = new Guid("33b7ed72-9434-434a-82d4-3018b018cb87"),
                            Body = "vestibulum sed arcu non odio euismod lacinia at quis risus sed vulputate odio ut enim blandit volutpat maecenas volutpat blandit aliquam etiam erat velit scelerisque in dictum non consectetur a erat nam at lectus urna duis convallis convallis tellus id interdum velit laoreet id donec ultrices tincidunt arcu non sodales neque sodales ut etiam sit amet nisl purus in mollis nunc sed id semper risus in hendrerit gravida rutrum quisque non tellus orci ac auctor augue mauris augue neque gravida in fermentum et sollicitudin ac orci phasellus egestas tellus rutrum tellus pellentesque eu tincidunt tortor aliquam nulla facilisi cras fermentum odio eu feugiat pretium nibh ipsum consequat nisl vel pretium lectus quam id leo in vitae turpis massa sed elementum tempus egestas sed sed risus pretium quam vulputate dignissim suspendisse in est ante in nibh mauris cursus mattis molestie a iaculis at erat pellentesque adipiscing commodo elit at imperdiet dui accumsan sit amet nulla facilisi morbi tempus iaculis urna id volutpat lacus laoreet non curabitur gravida arcu ac tortor dignissim convallis aenean et tortor at risus viverra adipiscing at in tellus integer feugiat scelerisque varius morbi enim nunc faucibus a pellentesque sit amet porttitor eget dolor morbi non arcu risus",
                            PostDate = new DateTime(2024, 5, 21, 2, 11, 38, 674, DateTimeKind.Local).AddTicks(9224),
                            State = 1,
                            Status = true,
                            Title = "Cats",
                            UserId = "CD04B747-A694-4431-8C8A-7CBF278A3832"
                        },
                        new
                        {
                            Id = new Guid("0257e1e3-2135-444e-8854-dbc588a7b29b"),
                            Body = "ullamcorper eget nulla facilisi etiam dignissim diam quis enim lobortis scelerisque fermentum dui faucibus in ornare quam viverra orci sagittis eu volutpat odio facilisis mauris sit amet massa vitae tortor condimentum lacinia quis vel eros donec ac odio tempor orci dapibus ultrices in iaculis nunc sed augue lacus viverra vitae",
                            PostDate = new DateTime(2024, 5, 21, 2, 11, 38, 674, DateTimeKind.Local).AddTicks(9229),
                            State = 1,
                            Status = true,
                            Title = "Dogs",
                            UserId = "CD04B747-A694-4431-8C8A-7CBF278A3832"
                        },
                        new
                        {
                            Id = new Guid("e18a5600-0d2a-4d43-b045-f7773c5c2d8d"),
                            Body = "dictum varius duis at consectetur lorem donec massa sapien faucibus et molestie ac feugiat sed lectus vestibulum mattis ullamcorper velit sed ullamcorper morbi tincidunt ornare massa eget egestas purus viverra accumsan in nisl nisi scelerisque eu ultrices vitae auctor eu augue ut lectus arcu bibendum at varius vel pharetra vel turpis nunc eget lorem dolor sed viverra ipsum nunc aliquet bibendum enim facilisis gravida neque convallis a cras semper auctor neque vitae tempus quam pellentesque nec nam aliquam sem et tortor consequat id porta nibh venenatis cras sed felis eget velit aliquet sagittis id consectetur purus ut faucibus pulvinar elementum integer enim neque volutpat ac tincidunt vitae semper quis lectus nulla at volutpat diam ut venenatis tellus in metus vulputate eu scelerisque felis imperdiet proin fermentum leo vel orci porta non pulvinar neque laoreet suspendisse interdum consectetur libero id faucibus nisl tincidunt eget nullam non nisi est sit amet facilisis magna etiam tempor orci eu lobortis elementum nibh tellus molestie nunc non blandit massa enim nec dui nunc mattis enim ut tellus elementum sagittis vitae et leo duis ut diam quam nulla porttitor massa id neque aliquam vestibulum morbi blandit cursus risus at ultrices mi tempus imperdiet nulla malesuada pellentesque elit eget gravida cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus mauris vitae ultricies leo integer malesuada nunc vel risus commodo viverra maecenas accumsan lacus vel facilisis volutpat est velit egestas dui id ornare arcu odio ut sem nulla pharetra diam sit amet nisl suscipit adipiscing bibendum est ultricies integer quis auctor elit sed vulputate mi sit amet mauris commodo quis imperdiet massa tincidunt nunc pulvinar sapien et ligula ullamcorper malesuada proin libero nunc consequat interdum varius sit amet mattis vulputate enim nulla aliquet porttitor lacus luctus accumsan tortor posuere ac ut consequat semper viverra nam libero justo laoreet sit amet cursus sit amet dictum sit amet justo donec enim diam vulputate ut pharetra sit amet aliquam id diam maecenas ultricies mi eget mauris pharetra et ultrices neque ornare aenean euismod elementum nisi quis eleifend quam adipiscing vitae proin sagittis nisl rhoncus mattis rhoncus urna neque viverra justo nec ultrices dui sapien eget mi proin sed libero enim sed faucibus turpis in eu mi bibendum neque egestas congue quisque egestas diam in arcu cursus euismod quis viverra nibh cras pulvinar mattis nunc sed blandit libero volutpat sed cras ornare arcu dui vivamus arcu felis bibendum ut tristique et egestas quis ipsum suspendisse ultrices gravida dictum fusce ut placerat orci nulla pellentesque dignissim enim sit amet venenatis urna cursus eget nunc scelerisque viverra mauris in aliquam sem fringilla ut morbi tincidunt augue interdum velit euismod in pellentesque massa placerat duis ultricies lacus sed turpis tincidunt id aliquet risus feugiat in ante metus dictum at tempor commodo ullamcorper a lacus vestibulum sed arcu non odio euismod lacinia at quis risus sed vulputate odio ut enim blandit volutpat maecenas volutpat blandit aliquam etiam erat velit scelerisque in dictum non consectetur a erat nam at lectus urna duis convallis convallis",
                            PostDate = new DateTime(2024, 5, 21, 2, 11, 38, 674, DateTimeKind.Local).AddTicks(9234),
                            State = 1,
                            Status = true,
                            Title = "Snakes",
                            UserId = "230669E4-C593-4084-BACC-E5A1AD1AD494"
                        },
                        new
                        {
                            Id = new Guid("5b365ad2-0264-46b2-86a8-c9c426ee88dd"),
                            Body = "elementum tempus egestas sed sed risus pretium quam vulputate dignissim suspendisse in est ante in nibh mauris cursus mattis molestie a iaculis at erat pellentesque adipiscing commodo elit at imperdiet dui accumsan sit amet nulla facilisi morbi tempus iaculis urna id volutpat lacus laoreet non curabitur gravida arcu ac tortor dignissim convallis aenean et tortor at risus viverra adipiscing at in tellus integer feugiat scelerisque varius morbi enim nunc faucibus a pellentesque sit amet porttitor eget dolor morbi non arcu risus quis varius quam quisque id diam vel quam elementum pulvinar etiam non quam lacus suspendisse faucibus interdum posuere lorem ipsum dolor sit amet consectetur adipiscing elit duis tristique sollicitudin nibh sit amet commodo nulla facilisi nullam vehicula ipsum a arcu cursus vitae congue mauris",
                            PostDate = new DateTime(2024, 5, 21, 2, 11, 38, 674, DateTimeKind.Local).AddTicks(9253),
                            State = 1,
                            Status = true,
                            Title = "Hamsters",
                            UserId = "1DF10D85-D5F8-4E4E-8892-92B740BF2F4F"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = "2BC27413-6F9C-49F0-BC95-4D040FDEDBB4",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "ED5264A9-7A3F-42E1-A653-6AEAC2CA2783",
                            Name = "User",
                            NormalizedName = "USER"
                        });
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
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

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

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

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "24614412-A49F-4DC8-BCE1-EE5AFF9B11BC",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "52723dfe-d4f0-4c71-8a7e-9b8c02cfa974",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEDlVC/skF+DKj3eJRJt/5a4DOedQmhyE8S5mXLnrXsD4HWt1phfBDKadkcG27ucAMQ==",
                            PhoneNumber = "555337681",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e1b3da04-4de6-4b93-bb9d-9c12555f8318",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        },
                        new
                        {
                            Id = "CD04B747-A694-4431-8C8A-7CBF278A3832",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "65fd5a51-5de7-40c5-ada2-07651e26b15b",
                            Email = "gio@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            NormalizedEmail = "GIO@GMAIL.COM",
                            NormalizedUserName = "GIO@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAECDsfcV6Gp4xNPfwMSvbjRW88yVvZiv9ZHePVboAf/5TFToS0/PWwEV22BDK18+pWQ==",
                            PhoneNumber = "589745665",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "45b4a03e-0da4-488b-95b9-d14de202fdc8",
                            TwoFactorEnabled = false,
                            UserName = "gio@gmail.com"
                        },
                        new
                        {
                            Id = "230669E4-C593-4084-BACC-E5A1AD1AD494",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "2545f9d6-a318-4a15-a01a-6ff309b2df1f",
                            Email = "nika@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            NormalizedEmail = "NIKA@GMAIL.COM",
                            NormalizedUserName = "NIKA@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEGHixEg8uaxmlmA2ONVtuHf6MiQsXSQAJjch6cIr+taefCz0dopQe/S8UWEa8VpEMA==",
                            PhoneNumber = "558490645",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "33a0850b-3389-4405-b3ae-1764d9a787b6",
                            TwoFactorEnabled = false,
                            UserName = "nika@gmail.com"
                        },
                        new
                        {
                            Id = "1DF10D85-D5F8-4E4E-8892-92B740BF2F4F",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7a5c5f4d-5e84-4d76-8436-149d53727afb",
                            Email = "saba@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            NormalizedEmail = "SABA@GMAIL.COM",
                            NormalizedUserName = "SABA@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEOhMIBeNoBAlkOoH/TPJNQ4kGZB5qB2m3eZn0dSa8DvuseNwdlBQGNLt3Bk+/sTNeA==",
                            PhoneNumber = "5523901029",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9d8e09a2-9368-488c-b7e0-8d02b5b28132",
                            TwoFactorEnabled = false,
                            UserName = "saba@gmail.com"
                        },
                        new
                        {
                            Id = "5CB83547-A7E4-4064-81AF-640D2B9ED831",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "649741e1-6de3-4c78-9148-42c5c86f1cc0",
                            Email = "beqa@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            NormalizedEmail = "BEQA@GMAIL.COM",
                            NormalizedUserName = "BEQA@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEATuu7t1+JTO0xXjNtZTQgFAjkiKh13tB2VnqrbvqtHMV+RnsBoSQgJvuCjgw6YHJQ==",
                            PhoneNumber = "5233841070",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "44603981-994d-46fc-96d0-a376bdeddb0d",
                            TwoFactorEnabled = false,
                            UserName = "beqa@gmail.com"
                        });
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

                    b.HasData(
                        new
                        {
                            UserId = "24614412-A49F-4DC8-BCE1-EE5AFF9B11BC",
                            RoleId = "2BC27413-6F9C-49F0-BC95-4D040FDEDBB4"
                        },
                        new
                        {
                            UserId = "CD04B747-A694-4431-8C8A-7CBF278A3832",
                            RoleId = "ED5264A9-7A3F-42E1-A653-6AEAC2CA2783"
                        },
                        new
                        {
                            UserId = "230669E4-C593-4084-BACC-E5A1AD1AD494",
                            RoleId = "ED5264A9-7A3F-42E1-A653-6AEAC2CA2783"
                        },
                        new
                        {
                            UserId = "1DF10D85-D5F8-4E4E-8892-92B740BF2F4F",
                            RoleId = "ED5264A9-7A3F-42E1-A653-6AEAC2CA2783"
                        },
                        new
                        {
                            UserId = "5CB83547-A7E4-4064-81AF-640D2B9ED831",
                            RoleId = "ED5264A9-7A3F-42E1-A653-6AEAC2CA2783"
                        });
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

            modelBuilder.Entity("ForumProject.Entities.Comment", b =>
                {
                    b.HasOne("ForumProject.Entities.Topic", "Topic")
                        .WithMany("Comments")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentityUser");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("ForumProject.Entities.Topic", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentityUser");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ForumProject.Entities.Topic", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
