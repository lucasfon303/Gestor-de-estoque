using System;
using System.Globalization;

namespace ConsoleApp3
{
    [System.Serializable]
    internal class ProdFisico : Produto, IEstoque
    {
        public float frete;
        private int estoque;

        public ProdFisico(string nome, float preço, float frete)
        {
            this.nome = nome;
            this.preço = preço;
            this.frete = frete;
        }

        public void AddEntrada()
        {
            Console.WriteLine($"Produto selecionado: {nome}");
            Console.WriteLine($"Informe a quantidade de itens que você deseja adicionar ao estoque:");
            string itensStr = Console.ReadLine();
            bool itensBool = int.TryParse(itensStr, out int itensInt);
            if (itensBool)
            {
                estoque += itensInt;
                Console.WriteLine("Entrada registrada.");
            }
        }

        public void AddSaida()
        {
            Console.WriteLine($"Produto selecionado: {nome}");
            Console.WriteLine($"Informe a quantidade de itens que você deseja remover do estoque:");
            string itensStr = Console.ReadLine();
            bool itensBool = int.TryParse(itensStr, out int itensInt);
            if (itensBool)
            {
                estoque -= itensInt;
                Console.WriteLine("Saída registrada.");
            }
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Preço: R${preço}");
            Console.WriteLine($"Frete: R${frete}");
            Console.WriteLine($"Estoque: {estoque}");
            Console.WriteLine("============================");
        }
    }

}
