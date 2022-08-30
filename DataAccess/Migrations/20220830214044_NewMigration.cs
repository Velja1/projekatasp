using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Width",
                table: "Vessels",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Vessels",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Length",
                table: "Vessels",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Height",
                table: "Vessels",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManufactersID",
                table: "Vessels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypesID",
                table: "Vessels",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RoleID",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleID1",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RolesID",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservationID",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Manufacters",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vessels_ManufactersID",
                table: "Vessels",
                column: "ManufactersID");

            migrationBuilder.CreateIndex(
                name: "IX_Vessels_TypesID",
                table: "Vessels",
                column: "TypesID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID1",
                table: "Users",
                column: "RoleID1");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RolesID",
                table: "Roles",
                column: "RolesID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationID",
                table: "Reservations",
                column: "ReservationID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UsersId",
                table: "Reservations",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Reservations_ReservationID",
                table: "Reservations",
                column: "ReservationID",
                principalTable: "Reservations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_UsersId",
                table: "Reservations",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Roles_RolesID",
                table: "Roles",
                column: "RolesID",
                principalTable: "Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleID1",
                table: "Users",
                column: "RoleID1",
                principalTable: "Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vessels_Manufacters_ManufactersID",
                table: "Vessels",
                column: "ManufactersID",
                principalTable: "Manufacters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vessels_Types_TypesID",
                table: "Vessels",
                column: "TypesID",
                principalTable: "Types",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Reservations_ReservationID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UsersId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Roles_RolesID",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleID1",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Vessels_Manufacters_ManufactersID",
                table: "Vessels");

            migrationBuilder.DropForeignKey(
                name: "FK_Vessels_Types_TypesID",
                table: "Vessels");

            migrationBuilder.DropIndex(
                name: "IX_Vessels_ManufactersID",
                table: "Vessels");

            migrationBuilder.DropIndex(
                name: "IX_Vessels_TypesID",
                table: "Vessels");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleID1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Roles_RolesID",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReservationID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UsersId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ManufactersID",
                table: "Vessels");

            migrationBuilder.DropColumn(
                name: "TypesID",
                table: "Vessels");

            migrationBuilder.DropColumn(
                name: "RoleID1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RolesID",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ReservationID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Reservations");

            migrationBuilder.AlterColumn<string>(
                name: "Width",
                table: "Vessels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Vessels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Length",
                table: "Vessels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Height",
                table: "Vessels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "RoleID",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Manufacters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
