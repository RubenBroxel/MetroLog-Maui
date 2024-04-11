using MetroLog.MicrosoftExtensions;
using Microsoft.Extensions.Logging;

namespace MauiApp2;

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

		builder.Logging.AddTraceLogger( _ => { });
		builder.Logging.AddInMemoryLogger( _ => { });
		builder.Logging.AddStreamingFileLogger( option => 
		{ 
			option.RetainDays = 2;               
            option.FolderPath = Path.Combine(FileSystem.Current.CacheDirectory, "InfoBoardLogs");
		});
		
		builder.Services.AddTransient<MainPage>();

		return builder.Build();
	}
}
