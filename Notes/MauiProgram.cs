using Microsoft.Extensions.Logging;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Notes.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Notes.Data;
using Notes.ViewModels;

namespace Notes;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

			var a = Assembly.GetExecutingAssembly();
			using var stream = a.GetManifestResourceStream("Notes.appsettings.json");
    
			var config = new ConfigurationBuilder()
    		.AddJsonStream(stream)
    		.Build();
    
			builder.Configuration.AddConfiguration(config);

			var connectionString = builder.Configuration.GetConnectionString("DevelopmentConnection");
			builder.Services.AddDbContext<NotesDbContext>(options => options.UseSqlServer(connectionString));

			builder.Services.AddSingleton<AllNotesViewModel>();
			builder.Services.AddTransient<NoteViewModel>();

			builder.Services.AddSingleton<AllNotesPage>();
			builder.Services.AddTransient<NotePage>();

			#if DEBUG
				builder.Logging.AddDebug();
			#endif
				return builder.Build();
	}
}
