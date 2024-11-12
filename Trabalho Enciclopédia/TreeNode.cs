using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Enciclopédia
{
    internal class TreeNode
    {
        public String capitulo;

        public int vezesAcessado;

        private TreeNode _pai;
        private List<TreeNode> _filhoLista = new List<TreeNode>();

        public TreeNode(string capitulo, TreeNode _pai = null)
        {
            this.capitulo = capitulo;
            this._pai = _pai;
        }

        public TreeNode AdicionarFilho(String capitulo, TreeNode pai)
        {
            TreeNode novoNo = new TreeNode(capitulo, pai);
            _filhoLista.Add(novoNo);
            return novoNo;
        }

        public TreeNode GetPai()
        {
            return _pai;
        }

        public TreeNode GetFilho(int index)
        {
            return _filhoLista[index];
        }

        public int NFilhos()
        {
            return _filhoLista.Count;
        }

        public void ImprimirEmOrdem(Action<TreeNode> function)
        {
            function(this);
            foreach (var filho in _filhoLista)
            {
                filho.ImprimirEmOrdem(function);
            }
        }


        public void CallChildren(Action<TreeNode> function)
        {
            function(this);
            foreach (var child in _filhoLista)
            {
                child.CallChildren(function);
            }
        }

        public void IntegrateToList(List<TreeNode> list)
        {
            if (this.NFilhos() < 1)
            {
                list.Add(this);
            }
            else
            {
                foreach (var child in _filhoLista)
                {
                    child.IntegrateToList(list);
                }
            }
        }
    }
}
