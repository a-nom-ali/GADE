using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.vega.gade3.hellosearchtrees
{

    public class BinaryTree
    {
        public Node root;

        public BinaryTree()
        {
            root = null;
        }

        // Given a binary tree, print its nodes depth-first
        public string depthFirstTraversalAsString(Node node)
        {

            return
                // if the node being checked is null
                node == null
                    // return empty string
                    ? ""
                    // otherwise traverse
                    :
                    // first traverse left child
                    depthFirstTraversalAsString(node.left)

                    // then 'visit' current node and 'print' the data of node
                    + node.data + " "

                    // now traverse right child
                    + depthFirstTraversalAsString(node.right);
        }

        public string depthFirstTraversalAsString()
        {
            return depthFirstTraversalAsString(root);
        }

        // // Given a binary tree, print its nodes breadth-first
        // String breadthFirstTraversalAsString()
        // {
        //
        //     // check if a tree jas been setup, otherwise return empty string
        //     if (root == null)
        //     {
        //         return "";
        //     }
        //
        //     // Create a queue to handle level-wise breath-first traversal
        //     Queue<Node> queue = new LinkedList<>();
        //
        //     // Add root to queue - level 0
        //     queue.add(root);
        //
        //     // Start off with an empty response.
        //     String result = "";
        //
        //     // For as long as we find nodes to process
        //     while (!queue.isEmpty())
        //     {
        //
        //         // get next Node n from front of queue
        //         Node n = queue.remove();
        //
        //         // 'visit' Node n by 'printing' data to result
        //         result += n.data + " ";
        //
        //         // add left node to queue if not null
        //         if (n.left != null)
        //         {
        //             queue.add(n.left);
        //         }
        //
        //         // add right node to queue if not null
        //         if (n.right != null)
        //         {
        //             queue.add(n.right);
        //         }
        //     }
        //
        //     return result;
        //
        // }

    }
}