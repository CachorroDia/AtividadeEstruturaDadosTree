using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Enciclopédia
{
    internal class CommandList
    {
        public String[] commandList;

        public void Read(String path)
        {
            commandList = File.ReadAllLines(path);
        }

        public void Command(String[] command, TreeNode node)
        {
            TreeNode auxiliar = node;
            for(int i = 0; i < command.Length; i++)
            {
                auxiliar = node;
                for(int j = 0; j < command[i].Length; j++)
                {
                    if (command[i][j].ToString() == "b")
                    {
                        auxiliar = auxiliar.GetParent();
                        auxiliar.timesAccessed++;
                    }
                    else
                    {
                        auxiliar = auxiliar.GetChild(command[i][j] - '0');
                        auxiliar.timesAccessed++;
                    }
                }
            }
            
        }

         public String VerifyAccess(TreeNode node, int index)
        {
            TreeNode maxValue;

            List<TreeNode> list = new List<TreeNode>();
            node = node.GetChild(index);
            node.IntegrateToList(list);

            maxValue = list[0];
            for(int i = 1; i < list.Count; i++)
            {
                if (list[i].timesAccessed > maxValue.timesAccessed)
                {
                    maxValue = list[i];
                }
            }

            Console.WriteLine($"\nPágina : {maxValue.chapter}\n|_Número de vezes acessada: {maxValue.timesAccessed}");
            Console.WriteLine($"|_Localizado em : {maxValue.GetParent().chapter}.");
            return maxValue.chapter;
        }
    }
}
