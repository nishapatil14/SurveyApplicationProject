using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyApp.Migrations
{
    public partial class inputchoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "choices",
                table: "Questions");

            migrationBuilder.CreateTable(
                name: "choices",
                columns: table => new
                {
                    choiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(nullable: false),
                    choicedata = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_choices", x => x.choiceId);
                    table.ForeignKey(
                        name: "FK_choices_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_choices_QuestionId",
                table: "choices",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "choices");

            migrationBuilder.AddColumn<string>(
                name: "choices",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
