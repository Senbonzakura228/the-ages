using Infrastructure.Configurations;
using Domain.Entities.Building;
using Domain.Entities.City;
using Infrastructure.Presets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure;

public class TheAgesDBContext(
    DbContextOptions<TheAgesDBContext> options,
    IOptions<CityExtentionOptions> cityExtentionOptions,
    IOptions<BuildingOptions> buildingOptions
    ) : DbContext(options)
{
    public DbSet<UserCityMap> userCityMaps { get; set; }
    public DbSet<Building> buildings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (tableName == null) continue;
            modelBuilder.Entity(entityType.ClrType).ToTable(TableToSnakeCase(tableName));
        }

        modelBuilder.ApplyConfiguration(new UserCityMapConfiguration());
        modelBuilder.ApplyConfiguration(new UserCityExtentionConfiguration());
        modelBuilder.ApplyConfiguration(new CityBuildingConfiguration());

        modelBuilder.ApplyConfiguration(new BuildingConfiguration(buildingOptions.Value));
        modelBuilder.ApplyConfiguration(new CityExtentionConfiguration(cityExtentionOptions.Value));

        base.OnModelCreating(modelBuilder);
    }

    private string TableToSnakeCase(string input)
    {
        return string.Concat(input.Select((x, i) =>
            i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
    }
}
