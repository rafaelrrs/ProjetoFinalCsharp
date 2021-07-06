using AppAt_Entity;
using AppAt_Entity.Repository;
using AppAt_Repositorio.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Formatting = Newtonsoft.Json.Formatting;

namespace AppAt
{
    class Program
    {
        private static IRepositoryAmigo repositoryAmigo = new RepositoryAmigo();

        static void Main(string[] args)
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("=== Gerenciamento de Aniversários de Amigos===");
            Console.WriteLine("==============================================");

            var sair = false;

            while (!sair)
            {
                ExibeOpções();
                var opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        CadastrarAmigo();
                        break;
                    case "2":
                        AtualizarAmigo();
                        break;
                    case "3":
                        ExcluirAmigo();
                        break;
                    case "4":
                        ObterAmigo();
                        break;
                    case "5":
                        ListarTodosAmigo();
                        break;
                    case "6":
                        BuscarAmigoPorNome();
                        break;
                    case "7":
                        ProximoAniversario();
                        break;
                    case "8":
                        Console.WriteLine("---");
                        Console.WriteLine("Tchau Tchau!");
                        Console.WriteLine("---");
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("---");
                        Console.WriteLine("Entre com uma opção valida!");
                        Console.WriteLine("---");
                        break;
                }

            }
            Console.ReadLine();
        }

        private static void ProximoAniversario()
        {
            Console.WriteLine("");
            Console.WriteLine("Entre com o identificador do amigo");

            var id = Convert.ToInt32(Console.ReadLine());
            var amigo = repositoryAmigo.GetAmigoById(id);
            var dias = amigo.ContagemAniversario(amigo.Aniversario);
            Console.WriteLine($"Faltam {dias} dias para o aniversário de {amigo.Nome} {amigo.Sobrenome}.");
        }

        private static void BuscarAmigoPorNome()
        {
            Console.WriteLine("Entre com o nome do amigo: ");
            var nomeBusca = Console.ReadLine();

            var amigo = repositoryAmigo.GetName(nomeBusca);

            Console.WriteLine("");
            Console.WriteLine($"Exibindo amigo com a busca [{nomeBusca}]");
            Console.WriteLine("");
            Console.WriteLine(JsonConvert.SerializeObject(amigo, Formatting.Indented));
            Console.WriteLine("");
            Console.WriteLine("");
        }

        private static void AniversarioDoDia()
        {
            Console.WriteLine("---");
            Console.WriteLine("Aniversário do dia!!!");
            Console.WriteLine("---");

            var amigo = new Amigo();

            //List<Amigo> lAmigosDeHoje = new List<Amigo>();

            //var x = amigo.AniversariosDeHoje(repositoryAmigo.GetAll());
            Console.WriteLine(JsonConvert.SerializeObject(amigo, Formatting.Indented));
        }

        private static void ExcluirAmigo()
        {
            Console.WriteLine("");
            Console.WriteLine("Entre com o identificador do amigo para excluir");

            var id = Convert.ToInt32(Console.ReadLine());

            var amigo = repositoryAmigo.GetAmigoById(id);

            if (amigo == null) 
                Console.WriteLine("Ops..amigo não encontrado :(");
            
            else
            {
                repositoryAmigo.Delete(id);
                Console.WriteLine("---");
                Console.WriteLine("Pronto, amigo excluído!");
                Console.WriteLine("---");
            }
        }

        private static void ListarTodosAmigo()
        {
            Console.WriteLine("Esses são todos os seus amigos!");
            Console.WriteLine("");
            var amigos = repositoryAmigo.GetAll();
            Console.WriteLine(JsonConvert.SerializeObject(amigos, Formatting.Indented));
            Console.WriteLine("");
            Console.WriteLine("");
        }

        private static void ObterAmigo()
        {
            Console.WriteLine("");
            Console.WriteLine("Entre com o identificador do amigo");

            var id = Convert.ToInt32(Console.ReadLine());
            var amigo = repositoryAmigo.GetAmigoById(id);

            Console.WriteLine("");
            Console.WriteLine($"Exibindo amigo com o identificador {id}");
            Console.WriteLine("");
            Console.WriteLine(JsonConvert.SerializeObject(amigo, Formatting.Indented));
            Console.WriteLine("");
            var dias = amigo.ContagemAniversario(amigo.Aniversario);
            Console.WriteLine($"Faltam {dias} dias para o aniversário de {amigo.Nome} {amigo.Sobrenome}.");
        }

        private static void AtualizarAmigo()
        {
            Console.WriteLine("---");
            Console.WriteLine("Entre com o identificado do amigo");

            var id = Convert.ToInt32(Console.ReadLine());
            var amigo = repositoryAmigo.GetAmigoById(id);

            Console.Clear();
            if (amigo == null)
            {
                Console.WriteLine("Amigo não encontrado :(");
            }
            else
            {
                Console.WriteLine("Entre com o nome do Amigo");
                amigo.Nome = Console.ReadLine();

                Console.WriteLine("Entre com o Sobrenome do Amigo");
                amigo.Sobrenome = Console.ReadLine();

                Console.WriteLine("Entre com o Aniversario do Amigo");
                amigo.Aniversario = Convert.ToDateTime(Console.ReadLine());

                repositoryAmigo.Update(amigo, id);

                Console.WriteLine("---");
                Console.WriteLine("Pronto, amigo atualizado!");
                Console.WriteLine("---");
            }
        }

        private static void CadastrarAmigo()
        {
            var amigo = new Amigo();

            Console.Clear();
            Console.WriteLine("---");
            Console.WriteLine("Entre com o nome do amigo");
            amigo.Nome = Console.ReadLine();

            Console.WriteLine("Entre com o sobrenome do amigo");
            amigo.Sobrenome = Console.ReadLine();

            Console.WriteLine("Entre com o aniversario do amigo no formato dd/mm/yyyy");
            amigo.Aniversario = Convert.ToDateTime(Console.ReadLine());

            repositoryAmigo.Create(amigo);

            Console.WriteLine("---");
            Console.WriteLine("Pronto, amigo Cadastro!");
            Console.WriteLine("---");
        }

        private static void ExibeOpções()
        {
            AniversarioDoDia();
            Console.WriteLine("Selecione as opções");
            Console.WriteLine("1 - Para criar um amigo");
            Console.WriteLine("2 - Para atualizar um amigo");
            Console.WriteLine("3 - Para excluir um amigo");
            Console.WriteLine("4 - Para obter um amigo");
            Console.WriteLine("5 - Para exibir todos os amigo");
            Console.WriteLine("6 - Par buscar amigo por nome");
            Console.WriteLine("7 - Proximo Aniversario do amigo");
            Console.WriteLine("8 - Para sair");
        }
    }
}
