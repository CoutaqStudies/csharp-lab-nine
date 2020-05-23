using System;
using System.Collections.Generic;
using System.Text;

namespace LabNine
{
    public class BinaryTreeNode
    {
        public string Data { get; set; }
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }
        public BinaryTreeNode(string data, BinaryTreeNode left, BinaryTreeNode right)
        {
            Data = data;
            Left = left;
            Right = right;
        }

    }
    public class BinaryTree
    {
        public BinaryTreeNode root = null;
        public void TreeFromList(List<String> list)
        {
            BinaryTreeNode[] nodes = new BinaryTreeNode[list.Count];
            nodes[7] = new BinaryTreeNode(list[7], null, null);
            nodes[6] = new BinaryTreeNode(list[6], nodes[7], null);
            nodes[11] = new BinaryTreeNode(list[7], null, nodes[6]);
            nodes[5] = new BinaryTreeNode(list[5], null, null);
            nodes[4] = new BinaryTreeNode(list[4], nodes[5], null);
            nodes[10] = new BinaryTreeNode(list[10], nodes[11], nodes[4]);
            nodes[12] = new BinaryTreeNode(list[12], null, nodes[10]);
            nodes[3] = new BinaryTreeNode(list[3], null, null);
            nodes[2] = new BinaryTreeNode(list[2], nodes[3], null);
            nodes[9] = new BinaryTreeNode(list[9], null, nodes[2]);
            nodes[1] = new BinaryTreeNode(list[1], null, null);
            nodes[0] = new BinaryTreeNode(list[0], nodes[1], null);
            nodes[8] = new BinaryTreeNode(list[8], nodes[9], nodes[0]);
            nodes[13] = new BinaryTreeNode(list[13], nodes[12], nodes[8]);
            nodes[14] = new BinaryTreeNode(list[14], null, nodes[13]);
            root = nodes[14];
        }
    }
}
