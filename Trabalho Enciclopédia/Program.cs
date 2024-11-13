using Trabalho_Enciclopédia;

EnciclopediaCreator tree = new EnciclopediaCreator();
tree.Ler("wiki.txt");

CommandList comando = new CommandList();
comando.Read("log.txt");

comando.Command(comando.commandList, tree.paiDeTodos);

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

comando.VerifyAccess(tree.paiDeTodos, Convert.ToInt32(input));