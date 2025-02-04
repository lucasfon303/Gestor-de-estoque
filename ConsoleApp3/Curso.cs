using System;

namespace ConsoleApp3
{
    [System.Serializable]
    internal class Curso : Produto, IEstoque
    {
        public string autor;
        private int vagas;

        public Curso(string nome, float preço, string autor)
        {
            this.nome = nome;
            this.preço = preço;
            this.autor = autor;
        }

        public void AddEntrada()
        {
            Console.WriteLine($"Curso selecionado: {nome}");
            Console.WriteLine($"Informe a quantidade de vagas que você deseja adicionar:");
            string vagasStr = Console.ReadLine();
            bool vagasBool = int.TryParse(vagasStr, out int vagasInt);
            if (vagasBool)
            {
                vagas += vagasInt;
                Console.WriteLine("Entrada registrada.");
            }
        }

        public void AddSaida()
        {
            Console.WriteLine($"Curso selecionado: {nome}");
            Console.WriteLine($"Informe a quantidade de vagas que você deseja ocupar:");
            string vagasStr = Console.ReadLine();
            bool vagasBool = int.TryParse(vagasStr, out int vagasInt);
            if (vagasBool)
            {
                vagas -= vagasInt;
                Console.WriteLine("Saída registrada.");
            }
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: R${preço}");
            Console.WriteLine($"Vagas restantes: {vagas}");
            Console.WriteLine("============================");
        }
    }
}
