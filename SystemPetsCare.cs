using PetsCareConsole2._0;
using PetsCareConsole2._0.Criptografy;

//Console.BackgroundColor = ConsoleColor.DarkGray;
//Console.ForegroundColor = ConsoleColor.DarkRed;

Console.WriteLine("\n\n\t\t\t\t\t\t############################################################");
Console.WriteLine("\t\t\t\t\t\t#              Bem vindo ao Sistema Pets Care              #");
Console.WriteLine("\t\t\t\t\t\t############################################################");
//Console.ReadKey();

Console.WriteLine("\t\t\t\t\t\t------------------------------------------------------------");
Console.WriteLine("\t\t\t\t\t\t                    Faça a sua escolha!");
Console.WriteLine("\t\t\t\t\t\t------------------------------------------------------------");

string adeus = "";
do

{
    Console.WriteLine("\t1 - Acessar Sistema\t2 - Cadastrar Usuário\t3 - Acessar Tela Login(em desenvolvimento!)\t4 - Sair do Sistema");
//Console.WriteLine("\t2 - Cadastrar Usuário");
//Console.WriteLine("\t3 - Sair do Sistema");
string opcEscolha = Console.ReadLine();


    switch (opcEscolha)
    {
        case "1":

            var tutor = new Tutores();
            Console.Clear();
            Console.WriteLine("Dados dos Tutores");
            tutor.Tutor();
            Console.Clear();
            break;

        case "2":

            var cadastroUser = new CadastroUser();
            Console.Clear();
            Console.WriteLine("Cadastrar");
            cadastroUser.CadUser();
            Console.Clear();
            break;

        case "4": 
        
            Console.Clear();
            Console.WriteLine("Obrigado pelo seu Tempo!");
            Console.ReadKey();
            Console.Clear();
            adeus = "Sair";
            break;

        case "3":

            var login = new LoginCadastro();
            Console.Clear();
            Console.WriteLine("Acessar Sistema");
            login.Logar();
            Console.Clear();
            break;

        default: 
        
            Console.Clear();
            Console.WriteLine("Opção inválida para este momento!");
            Console.ReadKey();
            Console.Clear();
            
            break;

    }
}
while (adeus != "Sair");
