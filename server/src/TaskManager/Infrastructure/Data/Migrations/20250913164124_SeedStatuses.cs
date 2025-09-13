using Microsoft.EntityFrameworkCore.Migrations;
using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.Data.Extensions;

#nullable disable

namespace TaskManager.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedStatuses : Migration
    {
        private static Status[] statuses = new Status[]
        {
            new Status()
            {
                Title = "To Do",
                Description = "Task is not started yet",
                Color = "#FF0000",
                IsFinishStatus = false,
            },
            new Status()
            {
                Title = "In Progress",
                Description = "Task is currently being worked on",
                Color = "#FFFF00",
                IsFinishStatus = false,
            },
            new Status()
            {
                Title = "Completed",
                Description = "Task has been finished",
                Color = "#00FF00",
                IsFinishStatus = true,
            },
        };

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertStatuses(statuses);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteStatuses(statuses.Select(x => x.Title).ToArray());
        }
    }
}
