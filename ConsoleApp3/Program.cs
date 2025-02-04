using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp3
{
    internal class Program
    {
        static List<IEstoque> prodEstoque = new List<IEstoque>();
        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saida, Sair }
        enum Prod { ProdFis = 1, Ebook, Curso }
        static string erro = "Opção inválida.\nPressione ENTER para retornar ao menu inicial.";
        public static string retornar = "Pressione ENTER para retornar ao menu inicial.";
        static bool escolheuSair = false;

        static void Main(string[] args)
        {
            Carregar();
            while (escolheuSair == false)
            {
                Console.Clear();

                Console.WriteLine("-GESTOR DE ESTOQUE-");
                Console.WriteLine("Selecione qual das opções você deseja acessar:");
                Console.WriteLine("1 - Listar\n2 - Adicionar\n3 - Remover\n4 - Registrar entrada\n5 - Registrar saída\n6 - Sair");

                string opStr = Console.ReadLine();
                Console.Clear();
                bool opBool = int.TryParse(opStr, out int opInt);
                if (opBool == false)
                {
                    Console.WriteLine(erro);
                    Console.ReadLine();
                }
                else
                {
                    Menu opção = (Menu)opInt;

                    if (opInt > 0 && opInt < 7)
                    {
                        switch (opção)
                        {
                            case Menu.Listar:
                                Console.WriteLine("-LISTA DE PRODUTOS-");
                                Listagem();
                                Console.WriteLine(retornar);
                                Console.ReadLine();
                                break;
                            case Menu.Adicionar:
                                CadastrarProd();
                                break;
                            case Menu.Remover:
                                Remoção();
                                break;
                            case Menu.Entrada:
                                DarEntrada();
                                break;
                            case Menu.Saida:
                                DarBaixa();
                                break;
                            case Menu.Sair:
                                Sair();
                                break;
                        }
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine(erro);
                        Console.ReadLine();
                    }
                }
            }
        }
        static void Listagem()
        {
            int i = 0;
            if (prodEstoque.Count <= 0)
            {
                Console.WriteLine("Não há produtos cadastrados.");
            }
            else
            {
                Console.WriteLine("============================");
                foreach (IEstoque produtos in prodEstoque)
                {
                    Console.WriteLine($"ID = {i}");
                    produtos.Exibir();
                    i++;
                }
            }
        }
        static void Remoção()
        {
            Console.WriteLine("-REMOÇÃO DE PRODUTOS-");
            if (prodEstoque.Count == 0)
            {
                Console.WriteLine("Não há produtos cadastrados.");
            }
            else
            {
                Listagem();
                Console.WriteLine("Informe o ID do produto o qual você deseja remover:");
                bool IDbool = int.TryParse(Console.ReadLine(), out int ID);
                if (IDbool == false)
                {
                    Console.WriteLine(erro);
                    Console.ReadLine();
                }
                else
                {
                    if (ID <= 0 && ID < prodEstoque.Count);
                    {
                        prodEstoque.RemoveAt(ID);
                        Salvar();
                    }
                }
            }
            Console.WriteLine(retornar);
            Console.ReadLine();
        }
        static void CadastrarProd()
        {
            Console.WriteLine("-CADASTRO DE PRODUTO-");
            Console.WriteLine("Informe qual tipo de produto você deseja cadastrar:\n1 - Produto físico\n2 - E-Book\n3 - Curso");
            string opStr = Console.ReadLine();
            Console.Clear();
            bool opBool = int.TryParse(opStr, out int opInt);
            if (opBool == false)
            {
                Console.WriteLine(erro);
                Console.ReadLine();
            }
            else
            {
                Prod opProd = (Prod)opInt;
                if (opInt > 0 && opInt < 4)
                {
                    switch (opProd)
                    {
                        case Prod.ProdFis:
                            AddProdFis();
                            break;
                        case Prod.Curso:
                            AddCurso();
                            break;
                        case Prod.Ebook:
                            AddEbook();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine(erro);
                    Console.ReadLine();
                }
            }
        }
        static void AddProdFis()
        {
            Console.WriteLine("Insira o nome do produto:");
            string nome = Console.ReadLine();
            Console.WriteLine("Insira o preço do produto: (apenas números)");
            string preçoStr = Console.ReadLine();
            bool preçoBool = float.TryParse(preçoStr, out float preçoFloat);
            if (preçoBool == false)
            {
                Console.WriteLine(erro);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Insira o preço do frete: (apenas números)");
                string freteStr = Console.ReadLine();
                bool freteBool = float.TryParse(freteStr, out float freteFloat);
                if (freteBool == false)
                {
                    Console.WriteLine(erro);
                    Console.ReadLine();
                }
                else
                {
                    ProdFisico pf = new ProdFisico(nome, preçoFloat, freteFloat);
                    prodEstoque.Add(pf);
                    Salvar();
                    Console.WriteLine($"Cadastro concluído! {retornar}");
                    Console.ReadLine();
                }
            }
        }
        static void AddEbook()
        {
            Console.WriteLine("Insira o nome do livro:");
            string nome = Console.ReadLine();
            Console.WriteLine("Insira o nome do autor:");
            string autor = Console.ReadLine();
            Console.WriteLine("Insira o preço do produto: (apenas números)");
            string preçoStr = Console.ReadLine();
            bool preçoBool = float.TryParse(preçoStr, out float preçoFloat);
            if (preçoBool == false)
            {
                Console.WriteLine(erro);
                Console.ReadLine();
            }
            else
            {
                Ebook pe = new Ebook(nome, preçoFloat, autor);
                prodEstoque.Add(pe);
                Salvar();
                Console.WriteLine($"Cadastro concluído! {retornar}");
                Console.ReadLine();
            }
        }
        static void AddCurso()
        {
            Console.WriteLine("Insira o nome do curso:");
            string nome = Console.ReadLine();
            Console.WriteLine("Insira o nome do autor:");
            string autor = Console.ReadLine();
            Console.WriteLine("Insira o preço do curso: (apenas números)");
            string preçoStr = Console.ReadLine();
            bool preçoBool = float.TryParse(preçoStr, out float preçoFloat);
            if (preçoBool == false)
            {
                Console.WriteLine(erro);
                Console.ReadLine();
            }
            else
            {
                Curso pc = new Curso(nome, preçoFloat, autor);
                prodEstoque.Add(pc);
                Salvar();
                Console.WriteLine($"Cadastro concluído! {retornar}");
                Console.ReadLine();
            }
        }
        static void DarEntrada()
        {
            Console.WriteLine("-ENTRADA DE PRODUTOS-");
            if (prodEstoque.Count == 0)
            {
                Console.WriteLine("Não há produtos cadastrados.");
            }
            else
            {
                Listagem();
                Console.WriteLine("Informe o ID do produto o qual você deseja dar entrada:");
                bool IDbool = int.TryParse(Console.ReadLine(), out int ID);
                if (IDbool == true)
                {
                    if (ID >= 0 && ID < prodEstoque.Count)
                    {
                        prodEstoque[ID].AddEntrada();
                        Salvar();
                        Console.WriteLine(retornar);
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine(erro);
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine(erro);
                    Console.ReadLine();
                }
            }
        }
        static void DarBaixa()
        {
            Console.WriteLine("-SAÍDA DE PRODUTOS-");
            if (prodEstoque.Count == 0)
            {
                Console.WriteLine("Não há produtos cadastrados.");
            }
            else
            {
                Listagem();
                Console.WriteLine("Informe o ID do produto o qual você deseja dar baixa:");
                bool IDbool = int.TryParse(Console.ReadLine(), out int ID);
                if (IDbool == true)
                {
                    if (ID >= 0 && ID < prodEstoque.Count)
                    {
                        prodEstoque[ID].AddSaida();
                        Salvar();
                        Console.WriteLine(retornar);
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine(erro);
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine(erro);
                    Console.ReadLine();
                }
            }
        }
        static void Sair()
        {
            Console.WriteLine("-SAIR-");
            Console.WriteLine("Você tem certeza que deseja sair?\n1 - Sim\n2 - Não");
            string opStr = Console.ReadLine();
            bool opBool = int.TryParse(opStr, out int opInt);
            if (opBool == false)
            {
                Console.WriteLine(erro);
                Console.ReadLine();
            }
            else
            {
                if (opInt == 1)
                {
                    escolheuSair = true;
                }
                else if (opInt == 2)
                {
                    Console.WriteLine(retornar);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine(erro);
                }
            }
        }
        static void Salvar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, prodEstoque);

            stream.Close();
        }
        static void Carregar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try
            {
                prodEstoque = (List<IEstoque>)encoder.Deserialize(stream);

                if (prodEstoque == null)
                {
                    prodEstoque = new List<IEstoque>();
                }
            }
            catch (Exception)
            {
                prodEstoque = new List<IEstoque>();
            }
            stream.Close();
        }
    }
}

