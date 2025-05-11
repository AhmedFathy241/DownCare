using DownCare.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace DownCare.Infrastructure.Data.SeedData
{
    //public class ActivityDataSeed : IEntityTypeConfiguration<ActivityData>
    //{
    //    public void Configure(EntityTypeBuilder<ActivityData> builder)
    //    {
    //        var activities = LoadActivitiesFromJson();
    //        if (activities != null)
    //        {
    //            builder.HasData(activities);
    //        }
    //    }
    //    private List<ActivityData> LoadActivitiesFromJson()
    //    {
    //        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "DownCare.Infrastructure", "Data");
    //        var jsonFilePath = Path.Combine(basePath, "ActivityData.json");
    //        if (!File.Exists(jsonFilePath))
    //            throw new FileNotFoundException($"🚨 Seed data file not found: {jsonFilePath}");
    //        var jsonData = File.ReadAllText(jsonFilePath);
    //        return JsonSerializer.Deserialize<List<ActivityData>>(jsonData) ?? new List<ActivityData>();
    //    }

    //}
}