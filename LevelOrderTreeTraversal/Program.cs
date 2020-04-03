// Recursive c# program for level  
// order traversal of Binary Tree  
using System;

/* Class containing left and right 
   child of current node and key value*/
public class Node
{
    public int data;
    public Node left, right;
    public Node(int item)
    {
        data = item;
        left = right = null;
    }
}

class GFG
{
    // Root of the Binary Tree  
    public Node root;

    public void BinaryTree()
    {
        root = null;
    }

    /* function to print level order  
       traversal of tree*/
    public virtual void printLevelOrder()
    {
        int h = height(root);
        int i;
        for (i = 1; i <= h; i++)
        {
            printGivenLevel(root, i);
        }
    }

    /* Compute the "height" of a tree --  
    the number of nodes along the longest  
    path from the root node down to the 
    farthest leaf node.*/
    public virtual int height(Node root)
    {
        if (root == null)
        {
            return 0;
        }
        else
        {
            /* compute height of each subtree */
            int lheight = height(root.left);
            int rheight = height(root.right);

            /* use the larger one */
            if (lheight > rheight)
            {
                return (lheight + 1);
            }
            else
            {
                return (rheight + 1);
            }
        }
    }

    /* Print nodes at the given level */
    public virtual void printGivenLevel(Node root,
                                        int level)
    {
        if (root == null)
        {
            return;
        }
        if (level == 1)
        {
            Console.Write(root.data + " ");
        }
        else if (level > 1)
        {
            printGivenLevel(root.left, level - 1);
            printGivenLevel(root.right, level - 1);
        }
    }

    // Driver Code 
    public static void Main(string[] args)
    {
        GFG tree = new GFG();
        tree.root = new Node(2);
        tree.root.left = new Node(1);
        tree.root.right = new Node(3);
        tree.root.left.left = new Node(4);
        tree.root.left.right = new Node(5);

        Console.WriteLine("Level order traversal " +
                              "of binary tree is ");
        tree.printLevelOrder();
    }
}

// This code is contributed by Shrikant13 