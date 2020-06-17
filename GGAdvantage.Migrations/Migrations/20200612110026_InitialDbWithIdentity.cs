using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GGAdvantage.Migrations.Migrations
{
    public partial class InitialDbWithIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuctionTimeLeftLU",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionTimeLeftLU", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemClass",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClassID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegionLU",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ShortName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionLU", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemSubclass",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SubclassID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ItemClassId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSubclass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemSubclass_ItemClass_ItemClassId",
                        column: x => x.ItemClassId,
                        principalTable: "ItemClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Realm",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Population = table.Column<string>(nullable: true),
                    Queue = table.Column<bool>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BattleGroup = table.Column<string>(nullable: true),
                    Locale = table.Column<string>(nullable: true),
                    Timezone = table.Column<string>(nullable: true),
                    ConnectedrealmsJson = table.Column<string>(nullable: true),
                    RegionLUId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Realm_RegionLU_RegionLUId",
                        column: x => x.RegionLUId,
                        principalTable: "RegionLU",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ItemID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    ItemSubclassId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_ItemSubclass_ItemSubclassId",
                        column: x => x.ItemSubclassId,
                        principalTable: "ItemSubclass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuctionCurrent",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Owner = table.Column<string>(nullable: true),
                    Bid = table.Column<long>(nullable: true),
                    Buyout = table.Column<long>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    AuctionTimeLeftLUId = table.Column<int>(nullable: false),
                    ItemId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionCurrent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuctionCurrent_AuctionTimeLeftLU_AuctionTimeLeftLUId",
                        column: x => x.AuctionTimeLeftLUId,
                        principalTable: "AuctionTimeLeftLU",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuctionCurrent_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuctionDailyStatistic",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataJson = table.Column<string>(nullable: true),
                    ItemId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionDailyStatistic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuctionDailyStatistic_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuctionCurrentRealmAssoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AuctionCurrentId = table.Column<Guid>(nullable: false),
                    RealmId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionCurrentRealmAssoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuctionCurrentRealmAssoc_AuctionCurrent_AuctionCurrentId",
                        column: x => x.AuctionCurrentId,
                        principalTable: "AuctionCurrent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuctionCurrentRealmAssoc_Realm_RealmId",
                        column: x => x.RealmId,
                        principalTable: "Realm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuctionDailyStatisticRealmAssoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AuctionDailyStatisticId = table.Column<Guid>(nullable: false),
                    RealmId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionDailyStatisticRealmAssoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuctionDailyStatisticRealmAssoc_AuctionDailyStatistic_AuctionDailyStatisticId",
                        column: x => x.AuctionDailyStatisticId,
                        principalTable: "AuctionDailyStatistic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuctionDailyStatisticRealmAssoc_Realm_RealmId",
                        column: x => x.RealmId,
                        principalTable: "Realm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuctionCurrent_AuctionTimeLeftLUId",
                table: "AuctionCurrent",
                column: "AuctionTimeLeftLUId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionCurrent_ItemId",
                table: "AuctionCurrent",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionCurrentRealmAssoc_AuctionCurrentId",
                table: "AuctionCurrentRealmAssoc",
                column: "AuctionCurrentId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionCurrentRealmAssoc_RealmId",
                table: "AuctionCurrentRealmAssoc",
                column: "RealmId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionDailyStatistic_ItemId",
                table: "AuctionDailyStatistic",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionDailyStatisticRealmAssoc_AuctionDailyStatisticId",
                table: "AuctionDailyStatisticRealmAssoc",
                column: "AuctionDailyStatisticId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionDailyStatisticRealmAssoc_RealmId",
                table: "AuctionDailyStatisticRealmAssoc",
                column: "RealmId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemSubclassId",
                table: "Item",
                column: "ItemSubclassId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSubclass_ItemClassId",
                table: "ItemSubclass",
                column: "ItemClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Realm_RegionLUId",
                table: "Realm",
                column: "RegionLUId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuctionCurrentRealmAssoc");

            migrationBuilder.DropTable(
                name: "AuctionDailyStatisticRealmAssoc");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "AuctionCurrent");

            migrationBuilder.DropTable(
                name: "AuctionDailyStatistic");

            migrationBuilder.DropTable(
                name: "Realm");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "AuctionTimeLeftLU");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "RegionLU");

            migrationBuilder.DropTable(
                name: "ItemSubclass");

            migrationBuilder.DropTable(
                name: "ItemClass");
        }
    }
}
