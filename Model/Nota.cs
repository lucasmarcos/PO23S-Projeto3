using System;
using System.Collections.ObjectModel;

using ReactiveUI;

namespace Projeto3.Model
{
	public class Nota : ReactiveObject
	{
		public Int32 Codigo { get; set; }
		public Int32 Total { get; set; }
		public DateTime Data { get; set; }

		public ObservableCollection<Tuple<Produto, Int32, Int32>> Produtos { get; set; }

		private Empresa _empresa;
		public Empresa Empresa
		{
			get => _empresa;
			set => this.RaiseAndSetIfChanged(ref _empresa, value);
		}

		private Cliente _cliente;
		public Cliente Cliente
		{
			get => _cliente;
			set => this.RaiseAndSetIfChanged(ref _cliente, value);
		}

		public Nota()
		{
			Produtos = new ObservableCollection<Tuple<Produto, Int32, Int32>>();
		}

		public void CalcularTotal()
		{
			Total = 0;
			foreach (var p in Produtos)
			{
				Total += p.Item3;
			}
		}

		public void Debug()
		{
			_empresa.Debug();
			Console.WriteLine($"nota:{Codigo}|{Data}|{Total}");
			_cliente.Debug();
			foreach (var p in Produtos)
			{
				Console.Write($"{p.Item2}, {p.Item3}");
				p.Item1.Debug();
			}
		}
	}
}
