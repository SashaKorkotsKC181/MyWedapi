using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MyWedapi.Migrations
{
    public partial class InitialOfListsOfTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "my_lists",
                columns: table => new
                {
                    my_list_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_my_lists", x => x.my_list_id);
                });

            migrationBuilder.CreateTable(
                name: "my_tasks",
                columns: table => new
                {
                    my_task_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    do_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    done = table.Column<bool>(type: "boolean", nullable: false),
                    my_list_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_my_tasks", x => x.my_task_id);
                    table.ForeignKey(
                        name: "fk_my_tasks_my_lists_my_list_id",
                        column: x => x.my_list_id,
                        principalTable: "my_lists",
                        principalColumn: "my_list_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_my_tasks_my_list_id",
                table: "my_tasks",
                column: "my_list_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "my_tasks");

            migrationBuilder.DropTable(
                name: "my_lists");
        }
    }
}
