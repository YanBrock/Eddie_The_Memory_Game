using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
//using System.IO;

namespace Eddie.Infrastructure;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        var connectionString = configuration.GetConnectionString("DefaultPgsqlConnection");

        optionsBuilder.UseNpgsql(connectionString);

        return new AppDbContext(optionsBuilder.Options);
    }
}

//public class DatabaseDesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
//{
//    public AppDbContext CreateDbContext(string[] args)
//    {
//        var builder = new DbContextOptionsBuilder<AppDbContext>();

//        builder.UseNpgsql();

//        return new AppDbContext(builder.Options);
//    }
//}