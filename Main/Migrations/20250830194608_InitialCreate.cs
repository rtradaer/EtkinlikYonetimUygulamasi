using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Main.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Etkinlikler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etkinlikler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "User", "USER" },
                    { "2", null, "Editor", "EDITOR" },
                    { "3", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Etkinlikler",
                columns: new[] { "Id", "CreatedAt", "EndDate", "ImageUrl", "IsActive", "LongDescription", "ShortDescription", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 20, 22, 46, 7, 905, DateTimeKind.Local).AddTicks(1381), new DateTime(2025, 9, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), "/images/1.jpg", true, "Yazılım sektöründeki en güncel gelişmelerin konuşulacağı, atölye ve panellerin düzenleneceği büyük bir etkinlik.", "Yazılım dünyasının önde gelen isimleriyle buluşma.", new DateTime(2025, 9, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), "Yazılım Zirvesi 2025" },
                    { 2, new DateTime(2025, 8, 23, 22, 46, 7, 905, DateTimeKind.Local).AddTicks(1405), new DateTime(2025, 10, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), "/images/2.jpg", true, "Katılımcılar, iş fikri geliştirme ve sunum teknikleri üzerine eğitim alacaklar.", "Girişimcilik üzerine uygulamalı eğitim.", new DateTime(2025, 10, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), "Girişimcilik Atölyesi" },
                    { 3, new DateTime(2025, 8, 25, 22, 46, 7, 905, DateTimeKind.Local).AddTicks(1412), new DateTime(2025, 11, 20, 19, 0, 0, 0, DateTimeKind.Unspecified), "/images/3.jpg", true, "Yenilikçi sanat eserlerinin ve teknolojik ürünlerin sergileneceği bir etkinlik.", "Teknoloji ile sanatın buluştuğu sergi.", new DateTime(2025, 11, 20, 11, 0, 0, 0, DateTimeKind.Unspecified), "Teknoloji ve Sanat Sergisi" },
                    { 4, new DateTime(2025, 8, 27, 22, 46, 7, 905, DateTimeKind.Local).AddTicks(1418), new DateTime(2025, 9, 25, 17, 0, 0, 0, DateTimeKind.Unspecified), "/images/4.jpg", true, "Katılımcılar, firmalarla birebir görüşme ve iş/staj başvurusu yapma imkanı bulacaklar.", "Farklı sektörlerden firmalarla tanışma fırsatı.", new DateTime(2025, 9, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), "Kariyer Günü" },
                    { 5, new DateTime(2025, 8, 28, 22, 46, 7, 905, DateTimeKind.Local).AddTicks(1425), new DateTime(2025, 12, 2, 18, 0, 0, 0, DateTimeKind.Unspecified), "/images/5.jpg", true, "Katılımcılar, mobil uygulama geliştirme süreçlerini uygulamalı olarak öğrenecekler.", "Mobil uygulama geliştirme temelleri.", new DateTime(2025, 12, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), "Mobil Uygulama Geliştirme Eğitimi" },
                    { 6, new DateTime(2025, 8, 29, 22, 46, 7, 905, DateTimeKind.Local).AddTicks(1431), new DateTime(2025, 9, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), "/images/6.jpg", true, "Uzman konuşmacılarla yapay zeka teknolojilerinin bugünü ve geleceği tartışılacak.", "Yapay zeka alanındaki güncel gelişmeler.", new DateTime(2025, 9, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), "Yapay Zeka Paneli" },
                    { 7, new DateTime(2025, 8, 22, 22, 46, 7, 905, DateTimeKind.Local).AddTicks(1437), new DateTime(2025, 10, 12, 16, 0, 0, 0, DateTimeKind.Unspecified), "/images/7.jpg", true, "Alanında uzman konuşmacılarla siber güvenlikte güncel tehditler ve alınabilecek önlemler tartışılacak.", "Siber tehditler ve korunma yolları.", new DateTime(2025, 10, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), "Siber Güvenlik Semineri" },
                    { 8, new DateTime(2025, 8, 24, 22, 46, 7, 905, DateTimeKind.Local).AddTicks(1464), new DateTime(2025, 11, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), "/images/8.jpg", true, "Katılımcılar, veri bilimi projelerinde kullanılan araçları ve teknikleri uygulamalı olarak öğrenecekler.", "Veri analizi ve makine öğrenmesi uygulamaları.", new DateTime(2025, 11, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Veri Bilimi Çalıştayı" },
                    { 9, new DateTime(2025, 8, 26, 22, 46, 7, 905, DateTimeKind.Local).AddTicks(1471), new DateTime(2025, 12, 11, 12, 0, 0, 0, DateTimeKind.Unspecified), "/images/9.jpg", true, "Takımlar halinde katılımcılar, 24 saat boyunca kendi oyunlarını geliştirecekler ve jüriye sunacaklar.", "24 saatlik oyun geliştirme maratonu.", new DateTime(2025, 12, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), "Oyun Geliştirme Hackathonu" },
                    { 10, new DateTime(2025, 8, 21, 22, 46, 7, 905, DateTimeKind.Local).AddTicks(1477), new DateTime(2025, 10, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), "/images/10.jpg", true, "Görüntü işleme alanında yapay zekanın kullanımı ve örnek projeler anlatılacak.", "Görüntü işleme ve yapay zeka uygulamaları.", new DateTime(2025, 10, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), "Yapay Zeka ile Görüntü İşleme" },
                    { 11, new DateTime(2025, 8, 23, 22, 46, 7, 905, DateTimeKind.Local).AddTicks(1483), new DateTime(2025, 11, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), "/images/11.jpg", true, "Blockchain teknolojisinin geleceği ve kripto paraların sektöre etkisi uzmanlar tarafından tartışılacak.", "Blockchain ve kripto paralar üzerine panel.", new DateTime(2025, 11, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), "Blockchain Teknolojileri Paneli" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Etkinlikler");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
