using System.Collections.ObjectModel;

using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

using Projeto3.DAO;
using Projeto3.Model;

namespace Projeto3.View
{
	public class ListarNotas : Window
	{
		public DAONota DAONota { get; set; }
		public Empresa Empresa { get; set; }

		private DataGrid DataGridNotas;

		public ListarNotas()
		{
			InitializeComponent();
			DataGridNotas = this.FindControl<DataGrid>("Notas");
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}

		public void Atualizar()
		{
			var notas = DAONota.ListarNotas();
			DataContext = new ObservableCollection<Nota>(notas);
		}

		public void Remover(object s, RoutedEventArgs e)
		{
			var nota = (Nota) DataGridNotas.SelectedItem;
			DAONota.Remover(nota);
			((ObservableCollection<Nota>) DataContext).Remove(nota);
		}

		public void Imprimir(object s, RoutedEventArgs e)
		{
			Close();
			var nota = (Nota) DataGridNotas.SelectedItem;
			nota.Empresa = Empresa;
			App.Imprimir(nota);
		}

	}
}
