using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Enciclopédia
{
    internal class CriadorEnciclopedia
    {

        private int camadaAtual = 0;
        private String[] carregar;
        public TreeNode paiDeTodos;

        public void Ler(String caminho)
        {
            carregar = File.ReadAllLines(caminho);

            paiDeTodos = new TreeNode(carregar[0]);

            for (int l = 1; l < carregar.Length; l++)
            {
                verificarCamada(l, paiDeTodos);
            }
            //paiDeTodos.ImprimirEmOrdem(Debug);
        }

        private void verificarCamada(int j, TreeNode no)
        {
            int camadaComparador = 0;
            TreeNode noAtual = no;
            while ( carregar[j][camadaComparador].ToString() == ".")
            {
                camadaComparador++;
            }


            while(camadaComparador > 1 )
            {
                camadaComparador--;
                if (noAtual.NFilhos() < 0)
                {
                    noAtual = noAtual.GetFilho(0);
                }
                else
                {
                    noAtual = noAtual.GetFilho(noAtual.NFilhos() - 1);
                }
                
            }
            noAtual.AdicionarFilho(pegarPalavra(carregar, j), noAtual);


        }


        public String pegarPalavra(String[] palavra, int j)
        {
            String palavraSemPonto = "";
            int i = 0;
            while(i < palavra[j].Count() )
            {
                if (palavra[j][i].ToString() != ".")
                {
                    palavraSemPonto = palavraSemPonto.Insert(palavraSemPonto.Length, palavra[j][i].ToString());
                }
                i++;
            }
            return palavraSemPonto;
        }

        private void Debug(TreeNode no)
        {
            Console.WriteLine(no.capitulo);
        }




    }
}
