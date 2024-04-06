//SoundSync
using System.ComponentModel.DataAnnotations.Schema;

//List<string> listaDasBandas = new List<string> { "Three Days Grace", "Ashes Remain", "Queen"};
Dictionary<string, List<int>> bandasDicionario = new Dictionary<string, List<int>>();
bandasDicionario.Add("Skillet", new List<int> { 8, 6, 10 });
bandasDicionario.Add("Ashes Remain", new List<int>());
void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░░██████╗██╗░░░██╗███╗░░██╗░█████╗░
██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗██╔════╝╚██╗░██╔╝████╗░██║██╔══██╗
╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║╚█████╗░░╚████╔╝░██╔██╗██║██║░░╚═╝
░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║░╚═══██╗░░╚██╔╝░░██║╚████║██║░░██╗
██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝██████╔╝░░░██║░░░██║░╚███║╚█████╔╝
╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░╚═════╝░░░░╚═╝░░░╚═╝░░╚══╝░╚════╝░
");
}
void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as banda");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite uma opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    if (opcaoEscolhidaNumerica == 1)
    {
        Console.WriteLine("Você digitou a opção " + opcaoEscolhida);
    }
    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarBandas();
            break;
        case 2:
            MostrarBandasRegistradas();
            break;
        case 3:
            AvaliarUmaBanda();
            break;
        case 4:
            MediaDeNotasDaBanda();
            break;
        case -1:
            Console.WriteLine("Tchau Tchau! =C");
            break;
        default:
            Console.WriteLine("Opção Inválida");
            break;
    }
}
void RegistrarBandas()
{
    //funcao para registrar uma banda
    Console.Clear();
    ExibirTituloDasOpcoes("Registro de Bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasDicionario.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso");
    Thread.Sleep(1500);
    Console.Clear();
    ExibirOpcoesDoMenu();

}

void MostrarBandasRegistradas()
{
    //funcao para mostrar as bandas que foram registradas
    Console.Clear();
    ExibirTituloDasOpcoes("Exibindo todas as bandas registradas");
    /*for(int i = 0; i < listaDasBandas.Count; i++)
    {
        Console.WriteLine($"Banda: {listaDasBandas[i]}");
    }*/

    foreach (string banda in bandasDicionario.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.WriteLine("\nPressione qualquer tecla para retornar para o menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirTituloDasOpcoes(string titulo)
{
    //funcao para exibir os titulos
    int quantidadeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarUmaBanda()
{
    //digite qual banda deseja avaliar
    //se a banda existir no dicionario >> atribuir uma nota
    //se não exitir >> volte ao menus principal

    Console.Clear();
    ExibirTituloDasOpcoes("Avaliar Banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeBanda = Console.ReadLine()!;

    if (bandasDicionario.ContainsKey(nomeBanda))
    {
        Console.Write($"Qual a nota da banda {nomeBanda}: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasDicionario[nomeBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeBanda}");
        Thread.Sleep(1500);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA Banda {nomeBanda} não está registrada!");
        Console.WriteLine("Digite uma tecla para retornar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

void MediaDeNotasDaBanda()
{
    //perguntar o nome da banda que deseja exibir a media de avaliacoes
    //consultar se a banda está inserida no dicionario
    Console.Clear();
    ExibirTituloDasOpcoes("Medias das Bandas");
    Console.Write("Digite o nome da banda que deseja ver a média: ");
    string nomeBanda = Console.ReadLine()!;

    if (bandasDicionario.ContainsKey(nomeBanda))
    {
        List<int> notasBanda = bandasDicionario[nomeBanda];
        Console.WriteLine($"\nA média   da banda {nomeBanda} é {notasBanda.Average()}.");
        Console.WriteLine("Digite uma tecla para retornar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA Banda {nomeBanda} não está registrada!");
        Console.WriteLine("Digite uma tecla para retornar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}
ExibirLogo();
ExibirOpcoesDoMenu();

