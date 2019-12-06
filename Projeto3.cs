using Avalonia;

using Projeto3.DAO;
using Projeto3.View;

namespace Projeto3
{
	public static class Projeto3
	{
		private static AppBuilder BuildAvaloniaApp() =>
			AppBuilder.Configure<App>().UsePlatformDetect();

		public static void Main(string[] args) =>
			BuildAvaloniaApp().Start(Inicio, args);

		private static void Inicio(Application app, string[] args)
		{
			app.Run(new JanelaPrincipal());
		}
	}
}
