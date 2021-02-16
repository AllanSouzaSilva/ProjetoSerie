using System;
using System.Collections.Generic;


namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();

            while (OpcaoUsuario.ToUpper() != "X")
            {

                switch (OpcaoUsuario)
                {
                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        InseriSerie();
                    break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                OpcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void ExcluirSerie()
        {
           Console.WriteLine("Digite o id da série: ");
           int indiceSerie = int.Parse(Console.ReadLine());
           repositorio.Exclui(indiceSerie);
        }

private static void VisualizarSerie(){
    Console.WriteLine("Digite o id de série: ");
    int indiceSerie = int.Parse(Console.ReadLine());
    var serie = repositorio.RetornaPorId(indiceSerie);

    System.Console.WriteLine(serie);
}
        private static void AtualizarSerie()
        {
            Console.Write("Digite o Id da serie: ");
            int indiaSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
            Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

            Serie atualizarSerie = new Serie(id: indiaSerie,
            genero: (Genero)entradaGenero,
            titulo:entradaTitulo,
            ano: entradaAno,
            descricao: entradaDescricao);

            repositorio.Atualiza(indiaSerie, atualizarSerie);
        }

        private static void InseriSerie()
        {
         Console.WriteLine("Inserir nova série");

			
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
                
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Inserir(novaSerie);
        }

        private static void ListarSerie()
        {
            Console.WriteLine("Listar serie");
            var lista = repositorio.Lista();
            if(lista.Count == 0){
                Console.WriteLine("Nenhuma série encontrada.");
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluido" : ""));
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("[1] - Listar série");
            Console.WriteLine("[2] - Inserir nova série");
            Console.WriteLine("[3] - Atualizar série");
            Console.WriteLine("[4] - Excluir série");
            Console.WriteLine("[5] - Visualizar série");
            Console.WriteLine("[C] - Limpar tela");
            Console.WriteLine("[X] - Sair");

            string OpcaoUsuario = Console.ReadLine().ToUpper();

            Console.WriteLine();
            return OpcaoUsuario;
        }
    }
}
