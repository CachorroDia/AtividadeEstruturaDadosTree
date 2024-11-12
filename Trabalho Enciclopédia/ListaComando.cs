using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Enciclopédia
{
    internal class ListaComando
    {
        public String[] listaComando;

        public void Ler(String caminho)
        {
            listaComando = File.ReadAllLines(caminho);
        }

        public void Comandos(String[] comandos, TreeNode no)
        {
            TreeNode auxiliar = no;
            for(int i = 0; i < comandos.Length; i++)
            {
                auxiliar = no;
                for(int j = 0; j < comandos[i].Length; j++)
                {
                    if (comandos[i][j].ToString() == "b")
                    {
                        auxiliar = auxiliar.GetPai();
                        auxiliar.vezesAcessado++;
                    }
                    else
                    {
                        auxiliar = auxiliar.GetFilho(comandos[i][j] - '0');
                        auxiliar.vezesAcessado++;
                    }


                }
            }
            
        }

         public String VerificarAcessos(TreeNode node, int index)
        {
            TreeNode valorMax;

            List<TreeNode> lista = new List<TreeNode>();
            node = node.GetFilho(index);
            node.IntegrateToList(lista);

            valorMax = lista[0];
            for(int i = 1; i < lista.Count; i++)
            {
                if (lista[i].vezesAcessado > valorMax.vezesAcessado)
                {
                    valorMax = lista[i];
                }
            }

            Console.WriteLine($"Numero de vezes acessado: {valorMax.vezesAcessado}");
            return valorMax.capitulo;
        }




    }
}
