using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Enciclopédia
{
    internal class TreeNode
    {
        public String chapter;

        public int timesAccessed;

        private TreeNode _parent;
        private List<TreeNode> _childList = new List<TreeNode>();

        public TreeNode(string chapter, TreeNode _pai = null)
        {
            this.chapter = chapter;
            this._parent = _pai;
        }

        public TreeNode AdicionarFilho(String chapter, TreeNode parent)
        {
            TreeNode newNode = new TreeNode(chapter, parent);
            _childList.Add(newNode);
            return newNode;
        }

        public TreeNode GetParent()
        {
            return _parent;
        }

        public TreeNode GetChild(int index)
        {
            return _childList[index];
        }

        public int NChilds()
        {
            return _childList.Count;
        }

        public void PrintInOrder(Action<TreeNode> function)
        {
            function(this);
            foreach (var filho in _childList)
            {
                filho.PrintInOrder(function);
            }
        }

        public void CallChildren(Action<TreeNode> function)
        {
            function(this);
            foreach (var child in _childList)
            {
                child.CallChildren(function);
            }
        }

        public void IntegrateToList(List<TreeNode> list)
        {
            if (this.NChilds() < 1)
            {
                list.Add(this);
            }
            else
            {
                foreach (var child in _childList)
                {
                    child.IntegrateToList(list);
                }
            }
        }
    }
}
