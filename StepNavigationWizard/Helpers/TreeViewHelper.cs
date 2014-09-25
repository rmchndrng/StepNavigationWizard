using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StepNavigationWizard.Helpers
{
    public class TreeViewHelper
    {
        public static TreeNode[] GetTreeNodes(List<Step> list)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            if (list != null && list.Count > 0)
            {
                foreach (Step step in list)
                {
                    TreeNode node = new TreeNode(step.Text, GetTreeNodes(step.Steps));
                    node.Name = step.Name;
                    nodes.Add(node);
                }
            }
            return nodes.ToArray();
        }


        internal static TreeNode GetNextNode(TreeNode treeNode)
        {
            if (treeNode.Nodes != null && treeNode.Nodes.Count > 0)
            {
                return treeNode.Nodes[0];
            }
            else
            {
                if (treeNode.NextNode != null)
                {
                    return treeNode.NextNode;
                }
                else if (treeNode.NextVisibleNode != null)
                {
                    return treeNode.NextVisibleNode;
                }
            }
            return treeNode;
        }

        internal static TreeNode GetPrevName(TreeNode treeNode)
        {
            if (treeNode.PrevNode != null && treeNode.PrevNode.Nodes.Count > 0)
            {
                return treeNode.PrevNode.Nodes[treeNode.PrevNode.Nodes.Count - 1];
            }
            else
            {
                if (treeNode.PrevNode != null)
                {
                    return treeNode.PrevNode;
                }
                else
                {
                    if (treeNode.Parent != null)
                    {
                        return treeNode.Parent;
                    }
                }
            }

            return treeNode;
        }
    }
}
