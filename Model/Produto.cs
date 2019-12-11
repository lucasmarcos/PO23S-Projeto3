using System;

namespace Projeto3.Model
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int Valor { get; set; }
        public string Unidade { get; set; }

        public void Debug()
        {
            Console.WriteLine("produto:{Codigo}|{Nome}|{Valor}|{Unidade}");
        }

        public Boolean Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome))    return false;
            if (string.IsNullOrWhiteSpace(Unidade)) return false;

            return true;
        }
    }
}
