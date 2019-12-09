using Avalonia;

namespace Projeto3
{
	public static class Projeto3
	{
		private static AppBuilder BuildAvaloniaApp() =>
			AppBuilder.Configure<App>().UsePlatformDetect();

		public static void Main(string[] args) =>
			BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
	}
}
