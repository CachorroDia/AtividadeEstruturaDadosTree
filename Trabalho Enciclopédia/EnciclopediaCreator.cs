using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Enciclopédia
{
    internal class EnciclopediaCreator
    {

        private int camadaAtual = 0;
        private String[] load;
        public TreeNode paiDeTodos;

        public void Ler(String caminho)
        {
            load = File.ReadAllLines(caminho);

            paiDeTodos = new TreeNode(load[0]);

            for (int l = 1; l < load.Length; l++)
            {
                verificarCamada(l, paiDeTodos);
            }
            //paiDeTodos.ImprimirEmOrdem(Debug);
        }

        private void verificarCamada(int j, TreeNode no)
        {
            int directoryLevel = 0;
            TreeNode currentNode = no;
            while ( load[j][directoryLevel].ToString() == ".")
            {
                directoryLevel++;
            }


            while(directoryLevel > 1 )
            {
                directoryLevel--;
                if (currentNode.NChilds() < 0)
                {
                    currentNode = currentNode.GetChild(0);
                }
                else
                {
                    currentNode = currentNode.GetChild(currentNode.NChilds() - 1);
                }
                
            }
            currentNode.AdicionarFilho(RemoveWord(load, j), currentNode);


        }


        public String RemoveWord(String[] word, int j)
        {
            String wordWithoutDot = "";
            int i = 0;
            while(i < word[j].Count() )
            {
                if (word[j][i].ToString() != ".")
                {
                    wordWithoutDot = wordWithoutDot.Insert(wordWithoutDot.Length, word[j][i].ToString());
                }
                i++;
            }
            return wordWithoutDot;
        }

        private void Debug(TreeNode no)
        {
            Console.WriteLine(no.chapter);
        }




    }
}
