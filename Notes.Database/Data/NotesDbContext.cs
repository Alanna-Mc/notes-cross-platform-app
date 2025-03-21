using Microsoft.EntityFrameworkCore;
using Notes.Database.Models;
using System.Reflection;
using Microsoft.Extensions.Configuration;

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
    
     optionsBuilder.UseSqlServer(
         config.GetConnectionString("DevelopmentConnection")
     );
 }
    public DbSet<Note> Notes { get; set; }

}