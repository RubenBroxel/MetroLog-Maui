using MauiApp2.Services;
//using MetroLog.Maui;
using Microsoft.Extensions.Logging;

namespace MauiApp2;

public partial class MainPage : ContentPage
{
	int count = 0;

	private readonly ILogger _logger;

	
	public MainPage(ILogger<MainPage> logger)
	{
		InitializeComponent();
		_logger = logger;
		_logger.LogInformation("\n++++++++++++++ Main Page Constructor");
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";
		
		_logger.LogInformation("\n++++++++++++++ OnCounterClicked MainPage ");

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

