using System;
using System.Collections.Generic;
using System.Text;

namespace LabNine
{
    public class BinaryTreeNode
    {
        public string Data { get; set; }
        public BinaryTreeNode Top { get; set; }
        public BinaryTreeNode Bottom { get; set; }

        public BinaryTreeNode(string data, BinaryTreeNode top, BinaryTreeNode bottom)
        {
            Data = data;
            Top = top;
            Bottom = bottom;
        }

    }
    public class BinaryTree
    {
        BinaryTreeNode root = null;

        public void fill(string[] data)
        {
            root.Data = data[0];
            //root.Top = SubNode(data[1])
            
        }
        public BinaryTreeNode SubNode(String data, BinaryTreeNode Top, BinaryTreeNode Bottom)
        {
            BinaryTreeNode node = null;
            node.Data = data;
            node.Top = Top;
            node.Bottom = Bottom;
            return node;
        }
    }
}
