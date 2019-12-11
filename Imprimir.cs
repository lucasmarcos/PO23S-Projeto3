using System;
using System.Drawing.Printing;

namespace PO23S_Projeto3
{
	public class Imprimir
	{
		public Imprimir()
		{
			var printDocument = new PrintDocument();
			printDocument.Print();
		}
	}
}
