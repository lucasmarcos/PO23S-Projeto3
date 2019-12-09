using System;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;

using Projeto3.Model;

namespace Projeto3.View
{
	public class ImprimirNota : Window
	{
		public void SetNota(Nota nota)
		{
			DataContext = nota;
		}

		public ImprimirNota()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}
