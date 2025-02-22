using Data.Configurations;
using Data.Entities.Building;
using Data.Entities.City;
using Data.Entities.User;
using Data.Presets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Data;

public class TheAgesDBContext(
    DbContextOptions<TheAgesDBContext> options,
    IOptions<CityExtentionOptions> cityExtentionOptions,
    IOptions<BuildingOptions> buildingOptions
    ) : DbContext(options)
{
    public DbSet<UserAccount> userAccounts { get; set; }
    public DbSet<UserGameData> userGameData { get; set; }
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

        modelBuilder.ApplyConfiguration(new UserAcoountConfiguration());
        modelBuilder.ApplyConfiguration(new UserGameDataConfiguration());
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
