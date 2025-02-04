using System;

namespace ConsoleApp3
{
    [System.Serializable]
    internal class Ebook : Produto, IEstoque
    {
        public string autor;
        private int vendas;

        public Ebook(string nome, float preço, string autor)
        {
            this.nome = nome;
            this.preço = preço;
            this.autor = autor;
        }

        public void AddEntrada()
        {
            Console.WriteLine("Não é possível dar entrada no tipo de produto 'E-Book'.");
        }

        public void AddSaida()
        {
            Console.WriteLine($"E-Book selecionado: {nome}");
            Console.WriteLine($"Informe a quantidade de vendas que você deseja adicionar:");
            string vendasStr = Console.ReadLine();
            bool vendasBool = int.TryParse(vendasStr, out int vendasInt);
            if (vendasBool)
            {
                vendas += vendasInt;
                Console.WriteLine("Entrada registrada.");
            }
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: R${preço}");
            Console.WriteLine($"Vendas: {vendas}");
            Console.WriteLine("============================");
        }
    }
}
