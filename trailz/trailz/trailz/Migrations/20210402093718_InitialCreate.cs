using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace trailz.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Trailz");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "Trailz",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "Trailz",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attribute",
                schema: "Trailz",
                columns: table => new
                {
                    AttributeTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribute", x => x.AttributeTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Level",
                schema: "Trailz",
                columns: table => new
                {
                    LevelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.LevelID);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                schema: "Trailz",
                columns: table => new
                {
                    RouteTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.RouteTypeID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "Trailz",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Trailz",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "Trailz",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Trailz",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "Trailz",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Trailz",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "Trailz",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Trailz",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Trailz",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "Trailz",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Trailz",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoggedInUser",
                schema: "Trailz",
                columns: table => new
                {
                    LoggedInUserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoggedInUser", x => x.LoggedInUserID);
                    table.ForeignKey(
                        name: "FK_LoggedInUser_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalSchema: "Trailz",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Route",
                schema: "Trailz",
                columns: table => new
                {
                    RouteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteDate = table.Column<DateTime>(nullable: false),
                    RouteName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Distance = table.Column<float>(nullable: false),
                    Departure = table.Column<string>(nullable: false),
                    Arrival = table.Column<string>(nullable: false),
                    GPXfile = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    minElevation = table.Column<string>(nullable: true),
                    maxElevation = table.Column<string>(nullable: true),
                    LoggedInUserID = table.Column<int>(nullable: false),
                    RouteTypeID = table.Column<int>(nullable: false),
                    LevelID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.RouteID);
                    table.ForeignKey(
                        name: "FK_Route_Level_LevelID",
                        column: x => x.LevelID,
                        principalSchema: "Trailz",
                        principalTable: "Level",
                        principalColumn: "LevelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Route_LoggedInUser_LoggedInUserID",
                        column: x => x.LoggedInUserID,
                        principalSchema: "Trailz",
                        principalTable: "LoggedInUser",
                        principalColumn: "LoggedInUserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Route_Type_RouteTypeID",
                        column: x => x.RouteTypeID,
                        principalSchema: "Trailz",
                        principalTable: "Type",
                        principalColumn: "RouteTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                schema: "Trailz",
                columns: table => new
                {
                    ReviewID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewRequestDate = table.Column<DateTime>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    LoggedUserID = table.Column<int>(nullable: false),
                    RouteID = table.Column<int>(nullable: false),
                    LoggedInUserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Review_LoggedInUser_LoggedInUserID",
                        column: x => x.LoggedInUserID,
                        principalSchema: "Trailz",
                        principalTable: "LoggedInUser",
                        principalColumn: "LoggedInUserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_Route_RouteID",
                        column: x => x.RouteID,
                        principalSchema: "Trailz",
                        principalTable: "Route",
                        principalColumn: "RouteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RouteAttribute",
                schema: "Trailz",
                columns: table => new
                {
                    RouteAttributeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeTypeID = table.Column<int>(nullable: false),
                    RouteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteAttribute", x => x.RouteAttributeID);
                    table.ForeignKey(
                        name: "FK_RouteAttribute_Attribute_AttributeTypeID",
                        column: x => x.AttributeTypeID,
                        principalSchema: "Trailz",
                        principalTable: "Attribute",
                        principalColumn: "AttributeTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteAttribute_Route_RouteID",
                        column: x => x.RouteID,
                        principalSchema: "Trailz",
                        principalTable: "Route",
                        principalColumn: "RouteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRequest",
                schema: "Trailz",
                columns: table => new
                {
                    LoggedInUserRequestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    LoggedInUserID = table.Column<int>(nullable: false),
                    RouteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRequest", x => x.LoggedInUserRequestID);
                    table.ForeignKey(
                        name: "FK_UserRequest_LoggedInUser_LoggedInUserID",
                        column: x => x.LoggedInUserID,
                        principalSchema: "Trailz",
                        principalTable: "LoggedInUser",
                        principalColumn: "LoggedInUserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRequest_Route_RouteID",
                        column: x => x.RouteID,
                        principalSchema: "Trailz",
                        principalTable: "Route",
                        principalColumn: "RouteID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "Trailz",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Trailz",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "Trailz",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "Trailz",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "Trailz",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Trailz",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Trailz",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LoggedInUser_Email",
                schema: "Trailz",
                table: "LoggedInUser",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoggedInUser_UserID",
                schema: "Trailz",
                table: "LoggedInUser",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Review_LoggedInUserID",
                schema: "Trailz",
                table: "Review",
                column: "LoggedInUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_RouteID",
                schema: "Trailz",
                table: "Review",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_Route_LevelID",
                schema: "Trailz",
                table: "Route",
                column: "LevelID");

            migrationBuilder.CreateIndex(
                name: "IX_Route_LoggedInUserID",
                schema: "Trailz",
                table: "Route",
                column: "LoggedInUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Route_RouteTypeID",
                schema: "Trailz",
                table: "Route",
                column: "RouteTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_RouteAttribute_AttributeTypeID",
                schema: "Trailz",
                table: "RouteAttribute",
                column: "AttributeTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_RouteAttribute_RouteID",
                schema: "Trailz",
                table: "RouteAttribute",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRequest_LoggedInUserID",
                schema: "Trailz",
                table: "UserRequest",
                column: "LoggedInUserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRequest_RouteID",
                schema: "Trailz",
                table: "UserRequest",
                column: "RouteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "Trailz");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "Trailz");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "Trailz");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "Trailz");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "Trailz");

            migrationBuilder.DropTable(
                name: "Review",
                schema: "Trailz");

            migrationBuilder.DropTable(
                name: "RouteAttribute",
                schema: "Trailz");

            migrationBuilder.DropTable(
                name: "UserRequest",
                schema: "Trailz");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "Trailz");

            migrationBuilder.DropTable(
                name: "Attribute",
                schema: "Trailz");

            migrationBuilder.DropTable(
                name: "Route",
                schema: "Trailz");

            migrationBuilder.DropTable(
                name: "Level",
                schema: "Trailz");

            migrationBuilder.DropTable(
                name: "LoggedInUser",
                schema: "Trailz");

            migrationBuilder.DropTable(
                name: "Type",
                schema: "Trailz");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "Trailz");
        }
    }
}
