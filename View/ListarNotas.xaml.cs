using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using Projeto3.DAO;

namespace Projeto3.View
{
	public class ListarNotas : Window
	{
		public DAONota DAONota { get; set; }

		public ListarNotas()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}

		public void Atualizar()
		{
			DataContext = DAONota.ListarNotas();
		}
	}
}
