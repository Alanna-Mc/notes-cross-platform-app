using Microsoft.EntityFrameworkCore;
using Notes.Database.Models;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace Notes.Database.Data;
public class NotesDbContext : DbContext
{

    public NotesDbContext()
    { }
    public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options)
    { }

     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 {
     var a = Assembly.GetExecutingAssembly();
     var resources = a.GetManifestResourceNames();
     using var stream = a.GetManifestResourceStream("Notes.Database.appsettings.json");
    
     var config = new ConfigurationBuilder()
         .AddJsonStream(stream)
         .Build();

    var isAndroid = OperatingSystem.IsAndroid(); 
// or if (DeviceInfo.Platform == DevicePlatform.Android) { ... }

    var connectionStringName = isAndroid ? "AndroidConnection" : "LocalConnection";
    optionsBuilder.UseSqlServer(
        config.GetConnectionString(connectionStringName)
         //m => m.MigrationsAssembly("Notes.Migrations")
     );

      // Enable detailed logging
    optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    Console.WriteLine($"[DEBUG] OperatingSystem.IsAndroid() = {OperatingSystem.IsAndroid()}");


 }
    public DbSet<Note> Notes { get; set; }
    public DbSet<Project> Projects { get; set; }


}