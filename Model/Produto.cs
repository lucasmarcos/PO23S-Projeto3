using System;

namespace Projeto3.Model
{
    public class Produto
    {
        public Int32 Codigo { get; set; }
        public String Nome { get; set; }
        public Int32 Valor { get; set; }
        public String Unidade { get; set; }
			
        public void Debug()
        {
            Console.WriteLine($"produto:{Codigo}|{Nome}|{Valor}|{Unidade}");
        }

        public Boolean Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome))    return false;
            if (string.IsNullOrWhiteSpace(Unidade)) return false;

            return true;
        }
    }
}