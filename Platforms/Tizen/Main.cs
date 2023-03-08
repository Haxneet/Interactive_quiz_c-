using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace Interactive_quiz_by_harneet;

class Program : MauiApplication
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	static void Main(string[] args)
	{
		var app = new Program();
		app.Run(args);
	}
}
