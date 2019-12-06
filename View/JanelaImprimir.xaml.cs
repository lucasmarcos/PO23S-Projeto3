using System;

using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using Projeto3.Model;

namespace Projeto3.View
{
	public class JanelaImprimir : Window
	{
		public Nota Nota
		{
			get => Nota = Nota;
			set => DataContext = Nota;
		}

		public JanelaImprimir()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}
