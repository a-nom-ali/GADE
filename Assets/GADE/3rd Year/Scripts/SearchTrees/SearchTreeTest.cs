using System.Collections;
using System.Collections.Generic;
using com.vega.gade3.hellosearchtrees;
using UnityEngine;
using UnityEngine.UI;

public class SearchTreeTest : MonoBehaviour
{
    private Text _text;
    private BinaryTree _tree;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
        _tree = createTree();

        _text.text = _tree.depthFirstTraversalAsString();
    }

    private BinaryTree createTree() {
        var tree = new BinaryTree();
        // Level 1
        tree.root = new Node(1);

        // Level 2
        tree.root.left = new Node(2);
        tree.root.right = new Node(3);

        // Level 3
        tree.root.left.left = new Node(4);
        tree.root.left.right = new Node(5);
        tree.root.right.left = new Node(6);
        tree.root.right.right = new Node(7);

        // Level 4
        tree.root.left.left.left = new Node(8);
        tree.root.right.left.left = new Node(9);
        tree.root.right.left.right = new Node(10);

        return tree;
    }
}
