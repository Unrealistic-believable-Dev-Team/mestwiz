﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mestwiz.config.data.access.Services;

#nullable disable

namespace mestwiz.config.data.access.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230323174349_InitialDB")]
    partial class InitialDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("mestwiz.config.data.entities.ApiEndPoint", b =>
                {
                    b.Property<string>("id")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("api_id");

                    b.Property<int>("port")
                        .HasColumnType("int")
                        .HasColumnName("api_port");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("api_status");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("api_type");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("api_url");

                    b.HasKey("id");

                    b.ToTable("TB_Api_EndPoint");
                });

            modelBuilder.Entity("mestwiz.config.data.entities.EmailXUser", b =>
                {
                    b.Property<string>("id")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email_id");

                    b.Property<bool>("_default")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("email_default");

                    b.Property<DateTime>("created_date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("email_created_date");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("email_status");

                    b.Property<DateTime?>("updated_date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("email_updated_date");

                    b.Property<string>("user_id")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email_user_id");

                    b.HasKey("id");

                    b.HasIndex("user_id");

                    b.ToTable("TB_Email_User");

                    b.HasData(
                        new
                        {
                            id = "emanuelpezlara@gmail.com",
                            _default = true,
                            created_date = new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(2522),
                            status = "AC",
                            user_id = "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM="
                        });
                });

            modelBuilder.Entity("mestwiz.config.data.entities.Menu", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("menu_id");

                    b.Property<DateTime>("created_date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("menu_created_date");

                    b.Property<string>("created_user_id")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("menu_created_user_id");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("menu_description");

                    b.Property<DateTime?>("modified_date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("menu_modified_date");

                    b.Property<string>("modified_user_id")
                        .HasColumnType("longtext")
                        .HasColumnName("menu_modified_user_id");

                    b.Property<int>("parent_id")
                        .HasColumnType("int")
                        .HasColumnName("menu_parent_id");

                    b.Property<string>("route")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("menu_route");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("menu_status");

                    b.HasKey("id");

                    b.ToTable("TB_Menu");

                    b.HasData(
                        new
                        {
                            id = 1,
                            created_date = new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(2552),
                            created_user_id = "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM=",
                            description = "Prueba Parent 1",
                            parent_id = 0,
                            route = "",
                            status = "AC"
                        },
                        new
                        {
                            id = 2,
                            created_date = new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(2554),
                            created_user_id = "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM=",
                            description = "Prueba Parent 2",
                            parent_id = 0,
                            route = "",
                            status = "AC"
                        },
                        new
                        {
                            id = 3,
                            created_date = new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(2555),
                            created_user_id = "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM=",
                            description = "Administration",
                            parent_id = 1,
                            route = "",
                            status = "AC"
                        },
                        new
                        {
                            id = 4,
                            created_date = new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(2556),
                            created_user_id = "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM=",
                            description = "Child 2 Parent 1",
                            parent_id = 1,
                            route = "",
                            status = "AC"
                        },
                        new
                        {
                            id = 5,
                            created_date = new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(2557),
                            created_user_id = "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM=",
                            description = "EndPoints",
                            parent_id = 3,
                            route = "/Administration/EndPoints",
                            status = "AC"
                        });
                });

            modelBuilder.Entity("mestwiz.config.data.entities.MenuXRole", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("mero_id");

                    b.Property<DateTime>("created_date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("mero_created_date");

                    b.Property<string>("created_user_id")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("mero_created_user_id");

                    b.Property<int>("menu_id")
                        .HasColumnType("int")
                        .HasColumnName("mero_menu_id");

                    b.Property<DateTime?>("modified_date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("mero_modified_date");

                    b.Property<string>("modified_user_id")
                        .HasColumnType("longtext")
                        .HasColumnName("mero_modified_user_id");

                    b.Property<int>("role_id")
                        .HasColumnType("int")
                        .HasColumnName("mero_role_id");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("mero_status");

                    b.HasKey("id");

                    b.HasIndex("menu_id");

                    b.HasIndex("role_id");

                    b.ToTable("TB_Menu_Role");

                    b.HasData(
                        new
                        {
                            id = 1,
                            created_date = new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(2573),
                            created_user_id = "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM=",
                            menu_id = 1,
                            role_id = 1,
                            status = "AC"
                        },
                        new
                        {
                            id = 2,
                            created_date = new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(2574),
                            created_user_id = "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM=",
                            menu_id = 2,
                            role_id = 1,
                            status = "AC"
                        },
                        new
                        {
                            id = 3,
                            created_date = new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(2575),
                            created_user_id = "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM=",
                            menu_id = 3,
                            role_id = 1,
                            status = "AC"
                        },
                        new
                        {
                            id = 4,
                            created_date = new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(2576),
                            created_user_id = "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM=",
                            menu_id = 4,
                            role_id = 1,
                            status = "AC"
                        },
                        new
                        {
                            id = 5,
                            created_date = new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(2577),
                            created_user_id = "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM=",
                            menu_id = 5,
                            role_id = 1,
                            status = "AC"
                        });
                });

            modelBuilder.Entity("mestwiz.config.data.entities.Permission", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("perm_id");

                    b.Property<int?>("Roleid")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("perm_created_date");

                    b.Property<string>("created_user_id")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("perm_created_user_id");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("perm_description");

                    b.Property<DateTime?>("modified_date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("perm_modified_date");

                    b.Property<string>("modified_user_id")
                        .HasColumnType("longtext")
                        .HasColumnName("perm_modified_user_id");

                    b.Property<string>("route")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("perm_route");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("perm_status");

                    b.HasKey("id");

                    b.HasIndex("Roleid");

                    b.ToTable("TB_Permission");

                    b.HasData(
                        new
                        {
                            id = 1,
                            created_date = new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(1292),
                            created_user_id = "init",
                            description = "Prueba 1",
                            route = "api/Config/Auth/Prueba",
                            status = "AC"
                        });
                });

            modelBuilder.Entity("mestwiz.config.data.entities.PermissionType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("permt_id");

                    b.Property<DateTime?>("created_date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("permt_created_date");

                    b.Property<string>("created_user_id")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("permt_created_user_id");

                    b.Property<string>("method")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("permt_method");

                    b.Property<DateTime?>("modified_date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("permt_modified_date");

                    b.Property<string>("modified_user_id")
                        .HasColumnType("longtext")
                        .HasColumnName("permt_modified_user_id");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("permt_status");

                    b.HasKey("id");

                    b.ToTable("TB_Cat_Permission_Type");

                    b.HasData(
                        new
                        {
                            id = 1,
                            created_date = new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(1444),
                            created_user_id = "init",
                            method = "GET",
                            status = "AC"
                        },
                        new
                        {
                            id = 2,
                            created_date = new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(1450),
                            created_user_id = "init",
                            method = "POST",
                            status = "AC"
                        },
                        new
                        {
                            id = 3,
                            created_date = new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(1451),
                            created_user_id = "init",
                            method = "PUT",
                            status = "AC"
                        },
                        new
                        {
                            id = 4,
                            created_date = new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(1452),
                            created_user_id = "init",
                            method = "DELETE",
                            status = "AC"
                        });
                });

            modelBuilder.Entity("mestwiz.config.data.entities.PermissionXRole", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("pero_id");

                    b.Property<int>("perm_id")
                        .HasColumnType("int")
                        .HasColumnName("pero_perm_id");

                    b.Property<int>("role_id")
                        .HasColumnType("int")
                        .HasColumnName("pero_role_id");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("pero_status");

                    b.HasKey("id");

                    b.HasIndex("perm_id");

                    b.HasIndex("role_id");

                    b.ToTable("TB_Permission_Role");

                    b.HasData(
                        new
                        {
                            id = 1,
                            perm_id = 1,
                            role_id = 1,
                            status = "AC"
                        });
                });

            modelBuilder.Entity("mestwiz.config.data.entities.PermissionXType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("perxt_id");

                    b.Property<int>("perm_id")
                        .HasColumnType("int")
                        .HasColumnName("perxt_perm_id");

                    b.Property<int>("permt_id")
                        .HasColumnType("int")
                        .HasColumnName("perxt_permt_id");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("perxt_status");

                    b.HasKey("id");

                    b.HasIndex("perm_id");

                    b.HasIndex("permt_id");

                    b.ToTable("TB_Permission_Type");

                    b.HasData(
                        new
                        {
                            id = 1,
                            perm_id = 1,
                            permt_id = 1,
                            status = "AC"
                        },
                        new
                        {
                            id = 2,
                            perm_id = 1,
                            permt_id = 2,
                            status = "AC"
                        },
                        new
                        {
                            id = 3,
                            perm_id = 1,
                            permt_id = 3,
                            status = "AC"
                        },
                        new
                        {
                            id = 4,
                            perm_id = 1,
                            permt_id = 4,
                            status = "AC"
                        });
                });

            modelBuilder.Entity("mestwiz.config.data.entities.PhoneXUser", b =>
                {
                    b.Property<string>("id")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phone_id");

                    b.Property<bool>("_default")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("phone_default");

                    b.Property<DateTime>("created_date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("phone_created_date");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("phone_status");

                    b.Property<DateTime?>("updated_date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("phone_updated_date");

                    b.Property<string>("user_id")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("phone_user_id");

                    b.HasKey("id");

                    b.HasIndex("user_id");

                    b.ToTable("TB_Phone_User");

                    b.HasData(
                        new
                        {
                            id = "+524778571644",
                            _default = true,
                            created_date = new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(2539),
                            status = "AC",
                            user_id = "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM="
                        });
                });

            modelBuilder.Entity("mestwiz.config.data.entities.Role", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.Property<DateTime>("created_date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("role_created_date");

                    b.Property<string>("created_user_id")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("role_created_user_id");

                    b.Property<DateTime?>("modified_date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("role_modified_date");

                    b.Property<string>("modified_user_id")
                        .HasColumnType("longtext")
                        .HasColumnName("role_modified_user_id");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("role_name");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("role_status");

                    b.HasKey("id");

                    b.ToTable("TB_Cat_Role");

                    b.HasData(
                        new
                        {
                            id = 1,
                            created_date = new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(1469),
                            created_user_id = "init",
                            name = "Default",
                            status = "AC"
                        });
                });

            modelBuilder.Entity("mestwiz.config.data.entities.RoleXUser", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("rous_id");

                    b.Property<int>("role_id")
                        .HasColumnType("int")
                        .HasColumnName("rous_role_id");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("rous_status");

                    b.Property<string>("user_id")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("rous_user_id");

                    b.HasKey("id");

                    b.HasIndex("role_id");

                    b.HasIndex("user_id");

                    b.ToTable("TB_Role_User");

                    b.HasData(
                        new
                        {
                            id = 1,
                            role_id = 1,
                            status = "AC",
                            user_id = "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM="
                        });
                });

            modelBuilder.Entity("mestwiz.config.data.entities.SessionXUser", b =>
                {
                    b.Property<string>("id")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("session_id");

                    b.Property<DateTime>("access_date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("session_access_date");

                    b.Property<DateTime?>("close_date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("session_close_date");

                    b.Property<string>("data")
                        .IsRequired()
                        .HasMaxLength(8000)
                        .HasColumnType("varchar(8000)")
                        .HasColumnName("session_data");

                    b.Property<string>("host")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("session_host");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("session_status");

                    b.Property<string>("user_id")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("session_user_id");

                    b.HasKey("id");

                    b.HasIndex("user_id");

                    b.ToTable("TB_Session_User");
                });

            modelBuilder.Entity("mestwiz.config.data.entities.TokenXUser", b =>
                {
                    b.Property<string>("id")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("token_id");

                    b.Property<DateTime?>("created_date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("token_created_date");

                    b.Property<DateTime?>("expiry_date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("token_expiry_date");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("token_status");

                    b.Property<string>("user_id")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("token_user_id");

                    b.HasKey("id");

                    b.HasIndex("user_id");

                    b.ToTable("TB_Token_User");
                });

            modelBuilder.Entity("mestwiz.config.data.entities.User", b =>
                {
                    b.Property<string>("id")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_id");

                    b.Property<string>("cipher_secret")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("user_cipher_secret");

                    b.Property<string>("cipher_type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("user_cipher_type");

                    b.Property<DateTime?>("created_date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("user_created_date");

                    b.Property<string>("full_name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("user_full_name");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("user_name");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("user_password");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("user_status");

                    b.Property<DateTime?>("updated_date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("user_updated_date");

                    b.HasKey("id");

                    b.ToTable("TB_User");

                    b.HasData(
                        new
                        {
                            id = "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM=",
                            cipher_secret = "",
                            cipher_type = "mb5",
                            created_date = new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(2480),
                            full_name = "User Default",
                            name = "user",
                            password = "ee2ec3cc66427bb422894495068222a8",
                            status = "AC"
                        });
                });

            modelBuilder.Entity("mestwiz.config.data.entities.EmailXUser", b =>
                {
                    b.HasOne("mestwiz.config.data.entities.User", "User")
                        .WithMany("EmailsXUser")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("mestwiz.config.data.entities.MenuXRole", b =>
                {
                    b.HasOne("mestwiz.config.data.entities.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("menu_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mestwiz.config.data.entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("mestwiz.config.data.entities.Permission", b =>
                {
                    b.HasOne("mestwiz.config.data.entities.Role", null)
                        .WithMany("Permissions")
                        .HasForeignKey("Roleid");
                });

            modelBuilder.Entity("mestwiz.config.data.entities.PermissionXRole", b =>
                {
                    b.HasOne("mestwiz.config.data.entities.Permission", "Permission")
                        .WithMany("PermissionsXRole")
                        .HasForeignKey("perm_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mestwiz.config.data.entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("mestwiz.config.data.entities.PermissionXType", b =>
                {
                    b.HasOne("mestwiz.config.data.entities.Permission", "Permission")
                        .WithMany("PermissionsXType")
                        .HasForeignKey("perm_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mestwiz.config.data.entities.PermissionType", "PermissionType")
                        .WithMany("PermissionXTypes")
                        .HasForeignKey("permt_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("PermissionType");
                });

            modelBuilder.Entity("mestwiz.config.data.entities.PhoneXUser", b =>
                {
                    b.HasOne("mestwiz.config.data.entities.User", "User")
                        .WithMany("PhonesXUser")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("mestwiz.config.data.entities.RoleXUser", b =>
                {
                    b.HasOne("mestwiz.config.data.entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mestwiz.config.data.entities.User", "User")
                        .WithMany("RolesXUser")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("mestwiz.config.data.entities.SessionXUser", b =>
                {
                    b.HasOne("mestwiz.config.data.entities.User", "User")
                        .WithMany("SessionsXUser")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("mestwiz.config.data.entities.TokenXUser", b =>
                {
                    b.HasOne("mestwiz.config.data.entities.User", "User")
                        .WithMany("TokensXUser")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("mestwiz.config.data.entities.Permission", b =>
                {
                    b.Navigation("PermissionsXRole");

                    b.Navigation("PermissionsXType");
                });

            modelBuilder.Entity("mestwiz.config.data.entities.PermissionType", b =>
                {
                    b.Navigation("PermissionXTypes");
                });

            modelBuilder.Entity("mestwiz.config.data.entities.Role", b =>
                {
                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("mestwiz.config.data.entities.User", b =>
                {
                    b.Navigation("EmailsXUser");

                    b.Navigation("PhonesXUser");

                    b.Navigation("RolesXUser");

                    b.Navigation("SessionsXUser");

                    b.Navigation("TokensXUser");
                });
#pragma warning restore 612, 618
        }
    }
}
