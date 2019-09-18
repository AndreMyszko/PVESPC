// # andre myszko # 2019102420
using System;
using System.Collections.Generic;

namespace CadastroPessoas
{
    class Program
    {
        //Método Main apresenta o MENU, aguarda seleção e separa em casos, apenas SAIR encerra o laço "do/while";
        static void Main(string[] args)
        {
            //_startEnd - boolean(true/false) responsável por encerrar o loop do MENU.
            Boolean _startEnd = true;
            //listaCadastros - responsável por armazenar informações de cadastro (nome, idade, altura) em uma List.
            List<Aluno> listaCadastros = new List<Aluno>();
            do
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("MENU:\n");
                Console.WriteLine($"1-Incluir\n2-Alterar\n3-Excluir\n4-Listar\n5-Pesquisar\n0-SAIR...");
                Console.WriteLine($"\nNúmero de cadastros na lista:\n{listaCadastros.Count}");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Digite sua opção:\n");
                string _option = Console.ReadLine();
                switch (_option)
                {
                    //INCLUIR NA LISTA:
                    case "1":
                        listaCadastros.Add(Incluir());
                        break;
                    //ALTERAR REGISTRO NA LISTA (ID):
                    case "2":
                        Console.WriteLine("\nALTERAR:\n");
                        Console.WriteLine("\nInsira CÓDIGO do registro que deseja alterar:\n");
                        string alt = (Console.ReadLine());
                        Aluno alterar = listaCadastros.Find(x => x.Cod == alt);
                        if (alt != null)
                        {
                            Console.Write("Código: ");
                            alterar.Cod = Console.ReadLine();
                            Console.Write("Nome: ");
                            alterar.Nome = Console.ReadLine();
                            Console.Write("Idade: ");
                            alterar.Idade = Int32.Parse(Console.ReadLine());
                            Console.Write("Data: ");
                            alterar.Data = Console.ReadLine();
                            Console.Write("Altura: ");
                            alterar.Altura = Convert.ToSingle(Console.ReadLine());
                        }
                        else
                        {
                            Console.WriteLine("***Registro não existe nesta lista.***");
                        }
                        break;
                    //EXCLUIR DA LISTA (ID):
                    case "3":
                        Console.WriteLine("\nEXCLUIR:\n");
                        Console.WriteLine("Insira o ID do registro que deseja apagar:\n");
                        int del = Int32.Parse(Console.ReadLine());
                        Boolean confExcl = true;
                        do
                        {
                            Console.WriteLine("Deseja mesmo excluir este item da lista?\n S / N");
                            string _optExcl = Console.ReadLine();
                            switch (_optExcl)
                            {
                                case "S":
                                    if (del <= listaCadastros.Count)
                                    {
                                        listaCadastros.RemoveAt(del);
                                    }
                                    else
                                    {
                                        Console.WriteLine("***Registro não existe nesta lista.***");
                                    }
                                    confExcl = false;
                                    break;
                                case "N":
                                    confExcl = false;
                                    break;
                                default:
                                    Console.WriteLine("Opção inválida\nEscolha entre S (sim) ou N (não)");
                                    break;
                            }
                        }
                        while (confExcl);
                        break;
                    //MOSTRAR LISTA:
                    case "4":
                        Console.WriteLine("\nLISTA:\n");
                        Console.WriteLine("ID - COD. - NOME - IDADE - DATA - ALTURA\n");
                        for (int i = 0; i < listaCadastros.Count; i++)
                        {
                            foreach (Aluno pessoa in listaCadastros)
                            {
                                Console.WriteLine($"{i++} - " +
                                    $"{pessoa.Cod} - " +
                                    $"{pessoa.Nome} - " +
                                    $"{pessoa.Idade} - " +
                                    $"{pessoa.Data} - " +
                                    $"{pessoa.Altura}");
                            }
                        }
                        break;
                    //PESQUISAR(ID):
                    case "5":
                        Console.WriteLine("\nPESQUISAR:\n");
                        Console.WriteLine("Insira o CÓDIGO do registro que deseja pesquisar:\n");
                        string src = Console.ReadLine();
                        Aluno pesq = listaCadastros.Find(x => x.Cod == src);
                        if(pesq != null)
                        {
                            Console.WriteLine($"Cod: {pesq.Cod}");
                            Console.WriteLine($"Nome: {pesq.Nome}");
                            Console.WriteLine($"Idade:{pesq.Idade}");
                            Console.WriteLine($"Data: {pesq.Data}");
                            Console.WriteLine($"Altura: {pesq.Altura}");
                        }
                        break;
                    //ENCERRAR LISTA:
                    case "0":
                        _startEnd = false;
                        Environment.Exit(0);
                        break;
                    //ERRO NA ESCOLHA DE OPÇÃO (DEFAULT)
                    default:
                        Console.WriteLine("\n***Opção não existe.***\nOpções válidas: 1, 2, 3, 4, 5, 0.\n");
                        break;
                }
            } while (_startEnd) ;
        }
        //Método Incluir, ativado com OPÇÃO-1, recebe informações de cadastro (nome, idade, altura).
        public static Aluno Incluir()
        {
            Aluno pessoa = new Aluno();
            Console.Write("\nINCLUIR:\n O CÓDIGO deve conter exatamente 5 dígitos\n");
            bool idConfig = true;
            do
            {
                Console.Write("Código: ");
                pessoa.Cod = Console.ReadLine();
                if (pessoa.Cod.Length != 5)
                {
                    Console.WriteLine("***CÓDIGO fora do formato especificado (5 dígitos)***");
                }
                else 
                {
                    idConfig = false;
                }
            } while (idConfig);
            Console.Write("Nome: ");
            pessoa.Nome = Console.ReadLine(); 
            Console.Write("Idade: ");
            pessoa.Idade = Int32.Parse(Console.ReadLine());
            Console.Write("Data: ");
            pessoa.Data = (Console.ReadLine());
            Console.Write("Altura: ");
            pessoa.Altura = Convert.ToSingle(Console.ReadLine());
            return pessoa;
        }
    }
}