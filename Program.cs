
using System.Reflection.Metadata;
using System.Text;

Dictionary<string,List<int>> bandasRegistradas = new Dictionary <string, List<int>>() {
    {"Nirvana", new List<int>() {10,10,10}},
    {"Pearl Jam", new List<int>() {8,5,6}}, 
    {"Pantera", new List<int>() {10,10,10}}
    } ;

void ExibirLogo()
{

    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");

    string mensagemBoasVindas = "Bem vindos ao Scream Sound";

    Console.WriteLine("");
    Console.WriteLine(mensagemBoasVindas);
    Console.WriteLine("");
}

void ExibirMenu()
{
    Console.WriteLine("Digite 1 para registrar uma banda.");
    Console.WriteLine("Digite 2 para mostrar todas as bandas.");
    Console.WriteLine("Digite 3 para avaliar uma banda.");
    Console.WriteLine("Digite 4 para exibir a média de uma banda.");
    Console.WriteLine("Digite 5 para exibir todas as notas de uma banda.");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
}

void AguardarTecla(){
    Console.WriteLine();
    Console.WriteLine("Digite qualque tecla para voltar ao menu principal.");
    Console.ReadKey();     
}

void VoltarParaMenuPrincipal(){
    Console.Clear();

    ExibirLogo();
    ExibirMenu(); 
 }

bool LocalizarBanda(string banda)
 {
    if (!bandasRegistradas.ContainsKey(banda)){

        Console.WriteLine($"{banda} não localizada.");
        Thread.Sleep(2000);      

        return false;
    }

    return true;
 }

void MostrarBandas()
{

    ExibirTitulo("Exibir Bandas");
       
    foreach (var banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    AguardarTecla();

    VoltarParaMenuPrincipal();   
}

void RegistrarBandas()
{

    Console.Clear();
   
    ExibirTitulo("Registro de Bandas");

    Console.Write("Digite o nome da banda que deseja registrar: ");

    string banda = Console.ReadLine()!;

    bandasRegistradas.Add(banda, new List<int>());
    
    Console.WriteLine($"{banda} registrada com sucesso.");

    Thread.Sleep(2000);
    
    VoltarParaMenuPrincipal(); 
}

void EncerrarPrograma(){

    Console.Write("Selecionado Sair. Bye! :-)"); 
    Thread.Sleep(2000);
    Console.Clear();
}

void AvaliarBanda(){

    ExibirTitulo("Avaliar Banda");

    Console.Write("Digite o nome da banda que deseja Avaliar:");
    string nomeBanda = Console.ReadLine()!;

    if (!LocalizarBanda(nomeBanda)){             
            
        VoltarParaMenuPrincipal();
        return;
    }

    Console.Write("Digite a nota da banda:");
    int nota = int.Parse(Console.ReadLine()!);

    bandasRegistradas[nomeBanda].Add(nota);


    Console.Write("Banda avaliada com sucesso");
    Thread.Sleep(4000);
    
    VoltarParaMenuPrincipal();     
}

void ExibirTitulo(string titulo){

    int tamanhoTitulo = titulo.Length;
    StringBuilder sb  = new StringBuilder("*",titulo.Length+2);

    for (int i = 0; i < tamanhoTitulo+2; i++){
        sb.Insert(0,"*");
    }

    string label = sb.ToString();

    Console.WriteLine();
    Console.WriteLine(label);
    Console.WriteLine("  " +titulo);
    Console.WriteLine(label);
    Console.WriteLine();
}

void ExibirTodasNotasDeUmaBanda(){

    ExibirTitulo("Mostrar notas de uma Banda");

    Console.Write("Digite o nome da banda que deseja ver as notas:");
    string nomeBanda = Console.ReadLine()!;

    if (!LocalizarBanda(nomeBanda)){              
           
        VoltarParaMenuPrincipal();
        return;
    }

    foreach (var nota in bandasRegistradas[nomeBanda].Select((value,i)=>(value, i))){
        Console.WriteLine($"Nota {nota.i}: {nota.value}");
    }

   AguardarTecla();

   VoltarParaMenuPrincipal();
}

void ExibirMediaDeUmaBanda()
{

    Console.Write("Digite o nome da banda que deseja Verificar a média:");
    string nomeBanda = Console.ReadLine()!;

    if (!LocalizarBanda(nomeBanda)){             
            
        VoltarParaMenuPrincipal();
        return;        
    }

    Console.WriteLine($"A média da banda {nomeBanda} é: {bandasRegistradas[nomeBanda].Average()} ");

    AguardarTecla();

    VoltarParaMenuPrincipal();
}


ExibirLogo();
ExibirMenu();

int opcao = 0;
while (opcao != -1)
{
    int.TryParse(Console.ReadLine(), out opcao);

    switch (opcao)
    {
        case -1: EncerrarPrograma(); 
            break;
        case 1: RegistrarBandas(); 
            break;
        case 2: MostrarBandas(); 
            break;
        case 3: AvaliarBanda(); 
            break;
        case 4: ExibirMediaDeUmaBanda(); 
            break;

        case 5: ExibirTodasNotasDeUmaBanda(); 
            break;            
        default: Console.WriteLine($" A opção {opcao.ToString()} é inválida. Escolha novamente a opcao"); break;
    }
}
