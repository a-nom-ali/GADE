using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.vega.gade3.hellosearchtrees
{
    public class Node
    {
        public int data;
        public Node left, right;

        public Node(int data)
        {
            this.data = data;
            this.left = this.right = null;
        }
    }
}