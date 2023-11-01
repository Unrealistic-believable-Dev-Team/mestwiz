using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace mestwiz.config.data.access.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_Api_EndPoint",
                columns: table => new
                {
                    api_id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    api_type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    api_url = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    api_port = table.Column<int>(type: "int", nullable: false),
                    api_status = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Api_EndPoint", x => x.api_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_Cat_Permission_Type",
                columns: table => new
                {
                    permt_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    permt_method = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    permt_status = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    permt_created_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    permt_modified_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    permt_created_user_id = table.Column<string>(type: "longtext", nullable: false),
                    permt_modified_user_id = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Cat_Permission_Type", x => x.permt_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_Cat_Role",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    role_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    role_status = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    role_created_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    role_modified_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    role_created_user_id = table.Column<string>(type: "longtext", nullable: false),
                    role_modified_user_id = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Cat_Role", x => x.role_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_Menu",
                columns: table => new
                {
                    menu_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    menu_parent_id = table.Column<int>(type: "int", nullable: false),
                    menu_description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    menu_route = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    menu_status = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    menu_created_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    menu_modified_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    menu_created_user_id = table.Column<string>(type: "longtext", nullable: false),
                    menu_modified_user_id = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Menu", x => x.menu_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_User",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    user_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    user_full_name = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    user_password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    user_cipher_type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    user_cipher_secret = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    user_status = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    user_created_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    user_updated_date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_User", x => x.user_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_Permission",
                columns: table => new
                {
                    perm_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    perm_route = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    perm_description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    perm_status = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    perm_created_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    perm_modified_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    perm_created_user_id = table.Column<string>(type: "longtext", nullable: false),
                    perm_modified_user_id = table.Column<string>(type: "longtext", nullable: true),
                    Roleid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Permission", x => x.perm_id);
                    table.ForeignKey(
                        name: "FK_TB_Permission_TB_Cat_Role_Roleid",
                        column: x => x.Roleid,
                        principalTable: "TB_Cat_Role",
                        principalColumn: "role_id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_Menu_Role",
                columns: table => new
                {
                    mero_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    mero_role_id = table.Column<int>(type: "int", nullable: false),
                    mero_menu_id = table.Column<int>(type: "int", nullable: false),
                    mero_status = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    mero_created_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    mero_modified_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    mero_created_user_id = table.Column<string>(type: "longtext", nullable: false),
                    mero_modified_user_id = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Menu_Role", x => x.mero_id);
                    table.ForeignKey(
                        name: "FK_TB_Menu_Role_TB_Cat_Role_mero_role_id",
                        column: x => x.mero_role_id,
                        principalTable: "TB_Cat_Role",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_Menu_Role_TB_Menu_mero_menu_id",
                        column: x => x.mero_menu_id,
                        principalTable: "TB_Menu",
                        principalColumn: "menu_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_Email_User",
                columns: table => new
                {
                    email_id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    email_user_id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    email_default = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    email_status = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    email_created_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    email_updated_date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Email_User", x => x.email_id);
                    table.ForeignKey(
                        name: "FK_TB_Email_User_TB_User_email_user_id",
                        column: x => x.email_user_id,
                        principalTable: "TB_User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_Phone_User",
                columns: table => new
                {
                    phone_id = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    phone_user_id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    phone_default = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    phone_status = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    phone_created_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    phone_updated_date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Phone_User", x => x.phone_id);
                    table.ForeignKey(
                        name: "FK_TB_Phone_User_TB_User_phone_user_id",
                        column: x => x.phone_user_id,
                        principalTable: "TB_User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_Role_User",
                columns: table => new
                {
                    rous_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    rous_status = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    rous_user_id = table.Column<string>(type: "varchar(255)", nullable: false),
                    rous_role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Role_User", x => x.rous_id);
                    table.ForeignKey(
                        name: "FK_TB_Role_User_TB_Cat_Role_rous_role_id",
                        column: x => x.rous_role_id,
                        principalTable: "TB_Cat_Role",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_Role_User_TB_User_rous_user_id",
                        column: x => x.rous_user_id,
                        principalTable: "TB_User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_Session_User",
                columns: table => new
                {
                    session_id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    session_user_id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    session_data = table.Column<string>(type: "varchar(8000)", maxLength: 8000, nullable: false),
                    session_host = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    session_status = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    session_access_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    session_close_date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Session_User", x => x.session_id);
                    table.ForeignKey(
                        name: "FK_TB_Session_User_TB_User_session_user_id",
                        column: x => x.session_user_id,
                        principalTable: "TB_User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_Token_User",
                columns: table => new
                {
                    token_id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    token_created_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    token_expiry_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    token_status = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    token_user_id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Token_User", x => x.token_id);
                    table.ForeignKey(
                        name: "FK_TB_Token_User_TB_User_token_user_id",
                        column: x => x.token_user_id,
                        principalTable: "TB_User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_Permission_Role",
                columns: table => new
                {
                    pero_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    pero_status = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    pero_perm_id = table.Column<int>(type: "int", nullable: false),
                    pero_role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Permission_Role", x => x.pero_id);
                    table.ForeignKey(
                        name: "FK_TB_Permission_Role_TB_Cat_Role_pero_role_id",
                        column: x => x.pero_role_id,
                        principalTable: "TB_Cat_Role",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_Permission_Role_TB_Permission_pero_perm_id",
                        column: x => x.pero_perm_id,
                        principalTable: "TB_Permission",
                        principalColumn: "perm_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_Permission_Type",
                columns: table => new
                {
                    perxt_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    perxt_status = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    perxt_perm_id = table.Column<int>(type: "int", nullable: false),
                    perxt_permt_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Permission_Type", x => x.perxt_id);
                    table.ForeignKey(
                        name: "FK_TB_Permission_Type_TB_Cat_Permission_Type_perxt_permt_id",
                        column: x => x.perxt_permt_id,
                        principalTable: "TB_Cat_Permission_Type",
                        principalColumn: "permt_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_Permission_Type_TB_Permission_perxt_perm_id",
                        column: x => x.perxt_perm_id,
                        principalTable: "TB_Permission",
                        principalColumn: "perm_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "TB_Cat_Permission_Type",
                columns: new[] { "permt_id", "permt_created_date", "permt_created_user_id", "permt_method", "permt_modified_date", "permt_modified_user_id", "permt_status" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(1444), "init", "GET", null, null, "AC" },
                    { 2, new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(1450), "init", "POST", null, null, "AC" },
                    { 3, new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(1451), "init", "PUT", null, null, "AC" },
                    { 4, new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(1452), "init", "DELETE", null, null, "AC" }
                });

            migrationBuilder.InsertData(
                table: "TB_Cat_Role",
                columns: new[] { "role_id", "role_created_date", "role_created_user_id", "role_modified_date", "role_modified_user_id", "role_name", "role_status" },
                values: new object[] { 1, new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(1469), "init", null, null, "Default", "AC" });

            migrationBuilder.InsertData(
                table: "TB_Menu",
                columns: new[] { "menu_id", "menu_created_date", "menu_created_user_id", "menu_description", "menu_modified_date", "menu_modified_user_id", "menu_parent_id", "menu_route", "menu_status" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(2552), "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM=", "Prueba Parent 1", null, null, 0, "", "AC" },
                    { 2, new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(2554), "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM=", "Prueba Parent 2", null, null, 0, "", "AC" },
                    { 3, new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(2555), "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM=", "Administration", null, null, 1, "", "AC" },
                    { 4, new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(2556), "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM=", "Child 2 Parent 1", null, null, 1, "", "AC" },
                    { 5, new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(2557), "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM=", "API EndPoints", null, null, 3, "/administration/ApiEndPoint", "AC" }
                });

            migrationBuilder.InsertData(
                table: "TB_Permission",
                columns: new[] { "perm_id", "Roleid", "perm_created_date", "perm_created_user_id", "perm_description", "perm_modified_date", "perm_modified_user_id", "perm_route", "perm_status" },
                values: new object[] { 1, null, new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(1292), "init", "Prueba 1", null, null, "api/Config/Auth/Prueba", "AC" });

            migrationBuilder.InsertData(
                table: "TB_User",
                columns: new[] { "user_id", "user_cipher_secret", "user_cipher_type", "user_created_date", "user_full_name", "user_name", "user_password", "user_status", "user_updated_date" },
                values: new object[] { "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM=", "", "mb5", new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(2480), "User Default", "user", "ee2ec3cc66427bb422894495068222a8", "AC", null });

            migrationBuilder.InsertData(
                table: "TB_Email_User",
                columns: new[] { "email_id", "email_default", "email_created_date", "email_status", "email_updated_date", "email_user_id" },
                values: new object[] { "emanuelpezlara@gmail.com", true, new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(2522), "AC", null, "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM=" });

            migrationBuilder.InsertData(
                table: "TB_Menu_Role",
                columns: new[] { "mero_id", "mero_created_date", "mero_created_user_id", "mero_menu_id", "mero_modified_date", "mero_modified_user_id", "mero_role_id", "mero_status" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(2573), "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM=", 1, null, null, 1, "AC" },
                    { 2, new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(2574), "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM=", 2, null, null, 1, "AC" },
                    { 3, new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(2575), "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM=", 3, null, null, 1, "AC" },
                    { 4, new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(2576), "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM=", 4, null, null, 1, "AC" },
                    { 5, new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(2577), "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM=", 5, null, null, 1, "AC" }
                });

            migrationBuilder.InsertData(
                table: "TB_Permission_Role",
                columns: new[] { "pero_id", "pero_perm_id", "pero_role_id", "pero_status" },
                values: new object[] { 1, 1, 1, "AC" });

            migrationBuilder.InsertData(
                table: "TB_Permission_Type",
                columns: new[] { "perxt_id", "perxt_perm_id", "perxt_permt_id", "perxt_status" },
                values: new object[,]
                {
                    { 1, 1, 1, "AC" },
                    { 2, 1, 2, "AC" },
                    { 3, 1, 3, "AC" },
                    { 4, 1, 4, "AC" }
                });

            migrationBuilder.InsertData(
                table: "TB_Phone_User",
                columns: new[] { "phone_id", "phone_default", "phone_created_date", "phone_status", "phone_updated_date", "phone_user_id" },
                values: new object[] { "+524778571644", true, new DateTime(2023, 3, 23, 11, 43, 49, 646, DateTimeKind.Local).AddTicks(2539), "AC", null, "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM=" });

            migrationBuilder.InsertData(
                table: "TB_Role_User",
                columns: new[] { "rous_id", "rous_role_id", "rous_status", "rous_user_id" },
                values: new object[] { 1, 1, "AC", "MjI5NzM5NDkzMTU2NDczYmE3YmNkZGUwZWYzZmZlZGVqdWV2ZXMsIDIzIGRlIG1hcnpvIGRlIDIwMjM=" });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Email_User_email_user_id",
                table: "TB_Email_User",
                column: "email_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Menu_Role_mero_menu_id",
                table: "TB_Menu_Role",
                column: "mero_menu_id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Menu_Role_mero_role_id",
                table: "TB_Menu_Role",
                column: "mero_role_id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Permission_Roleid",
                table: "TB_Permission",
                column: "Roleid");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Permission_Role_pero_perm_id",
                table: "TB_Permission_Role",
                column: "pero_perm_id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Permission_Role_pero_role_id",
                table: "TB_Permission_Role",
                column: "pero_role_id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Permission_Type_perxt_perm_id",
                table: "TB_Permission_Type",
                column: "perxt_perm_id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Permission_Type_perxt_permt_id",
                table: "TB_Permission_Type",
                column: "perxt_permt_id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Phone_User_phone_user_id",
                table: "TB_Phone_User",
                column: "phone_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Role_User_rous_role_id",
                table: "TB_Role_User",
                column: "rous_role_id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Role_User_rous_user_id",
                table: "TB_Role_User",
                column: "rous_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Session_User_session_user_id",
                table: "TB_Session_User",
                column: "session_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Token_User_token_user_id",
                table: "TB_Token_User",
                column: "token_user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Api_EndPoint");

            migrationBuilder.DropTable(
                name: "TB_Email_User");

            migrationBuilder.DropTable(
                name: "TB_Menu_Role");

            migrationBuilder.DropTable(
                name: "TB_Permission_Role");

            migrationBuilder.DropTable(
                name: "TB_Permission_Type");

            migrationBuilder.DropTable(
                name: "TB_Phone_User");

            migrationBuilder.DropTable(
                name: "TB_Role_User");

            migrationBuilder.DropTable(
                name: "TB_Session_User");

            migrationBuilder.DropTable(
                name: "TB_Token_User");

            migrationBuilder.DropTable(
                name: "TB_Menu");

            migrationBuilder.DropTable(
                name: "TB_Cat_Permission_Type");

            migrationBuilder.DropTable(
                name: "TB_Permission");

            migrationBuilder.DropTable(
                name: "TB_User");

            migrationBuilder.DropTable(
                name: "TB_Cat_Role");
        }
    }
}
