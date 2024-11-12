using Trabalho_Enciclopédia;

CriadorEnciclopedia tree = new CriadorEnciclopedia();
tree.Ler("wiki.txt");

ListaComando comando = new ListaComando();
comando.Ler("log.txt");

comando.Comandos(comando.listaComando, tree.paiDeTodos);

Console.WriteLine("Digite o que quer filtrar, 0 para monstro e 1 para carta");
string input;
while(true)
{
    input = Console.ReadLine();
    if (Convert.ToInt32(input) == 0 || Convert.ToInt32(input) == 1)
    {
        break;
    }
    else Console.WriteLine("Digitado errado, por favor, digite apenas 1 ou 0");
}

Console.WriteLine(comando.VerificarAcessos(tree.paiDeTodos, Convert.ToInt32(input)) );