using System;
using System.Collections.Generic;
using System.Text;

namespace LabNine
{
    internal class BadList
    {
        internal DoubleNode head;
    }
    internal class DoubleNode
    {
        internal int data;
        internal DoubleNode prev;
        internal DoubleNode next;
        public DoubleNode(int d)
        {
            data = d;
            prev = null;
            next = null;
        }
    }
}
