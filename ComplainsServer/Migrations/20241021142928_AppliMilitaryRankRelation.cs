using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplainsServer.Migrations
{
    /// <inheritdoc />
    public partial class AppliMilitaryRankRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Complains");

            migrationBuilder.AddColumn<int>(
                name: "MilitaryRankId",
                table: "Complains",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Complains_MilitaryRankId",
                table: "Complains",
                column: "MilitaryRankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Complains_MilitaryRanks_MilitaryRankId",
                table: "Complains",
                column: "MilitaryRankId",
                principalTable: "MilitaryRanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complains_MilitaryRanks_MilitaryRankId",
                table: "Complains");

            migrationBuilder.DropIndex(
                name: "IX_Complains_MilitaryRankId",
                table: "Complains");

            migrationBuilder.DropColumn(
                name: "MilitaryRankId",
                table: "Complains");

            migrationBuilder.AddColumn<string>(
                name: "Rank",
                table: "Complains",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
