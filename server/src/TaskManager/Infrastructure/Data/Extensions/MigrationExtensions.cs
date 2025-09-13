using Microsoft.EntityFrameworkCore.Migrations;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Data.Extensions;

public static class MigrationExtensions
{
    private const string StatusesTable = nameof(TaskManagerDbContext.Statuses);

    public static MigrationBuilder InsertStatuses(this MigrationBuilder builder, params Status[] statuses)
    {
        foreach (var status in statuses)
        {
            builder.InsertData(
                table: StatusesTable,
                columns: ["Title", "Description", "Color", "IsFinishStatus"],
                values: [status.Title, status.Description, status.Color, status.IsFinishStatus]);
        }

        return builder;
    }

    public static MigrationBuilder DeleteStatuses(this MigrationBuilder builder, params string[] titles)
    {
        builder.DeleteData(
            table: StatusesTable,
            keyColumn: "Title",
            keyValues: titles);

        return builder;
    }
}
