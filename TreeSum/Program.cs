using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeSum
{
    public class TreeNode
    {
        internal int val;
        internal TreeNode left;
        internal TreeNode right;
        internal TreeNode(int x) { val = x; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode t0 = new TreeNode(0);
            TreeNode t10 = new TreeNode(1);
            TreeNode t11 = new TreeNode(2);
            TreeNode t20 = new TreeNode(3);
            TreeNode t21= new TreeNode(4);
            TreeNode t22 = new TreeNode(5);
            TreeNode t23 = new TreeNode(6);
            t0.left = t10;
            t0.right = t11;
            //t10.left = t20;
            //t10.right = t21;
            //t11.left = t22;
            //t11.right = t23;

            TreeNode reverse = inverseBTree(t0);
            bool res = hasPathSum(t0, 3);
            Console.WriteLine();
        }//Main

        static TreeNode inverseBTree(TreeNode root)
        {
            if (root == null) return root;
            
            TreeNode l = inverseBTree(root.left);            
            TreeNode r =inverseBTree(root.right);

            
            root.left = r;
            root.right = l;
            return root;
        }


        static bool hasPathSum(TreeNode root, int sum)
        {
            if (root == null) return false;
            Stack<TreeNode> nodeStack = new Stack<TreeNode>();
            Stack<int> sumStack = new Stack<int>();
            nodeStack.Push(root);
            sumStack.Push(sum - root.val);

            TreeNode curr;
            int currSum = 0;
            while (nodeStack.Count>0)
            {
                //1  push root, substract val
                curr = nodeStack.Pop();
                currSum = sumStack.Pop();

                if (curr.left == null && curr.right == null && currSum == 0)
                    return true;

                //2 process left node
                if (curr.left != null)
                {
                    nodeStack.Push(curr.left);
                    sumStack.Push(currSum - curr.left.val);
                }
                    
                //3 process right node
                if (curr.right != null)
                {
                    nodeStack.Push(curr.right);
                    sumStack.Push(currSum - curr.right.val);
                }
                    
            }
           


            return false;
        }



        /*  
        Given a tree and a sum, return true if  
        there is a path from the root down to a  
        leaf, such that adding up all the values   
        along the path equals the given sum.  

        Strategy: subtract the node value from the  
        sum when recurring down, and check to see 
        if the sum is 0 when you run out of tree.  
        */

        public virtual bool haspathSum(TreeNode node,
                                       int sum)
        {
            if (node == null)
            {
                return (sum == 0);
            }
            else
            {
                bool ans = false;

                /* otherwise check both subtrees */
                int subsum = sum - node.val;
                if (subsum == 0 && node.left == null &&
                                   node.right == null)
                {
                    return true;
                }
                if (node.left != null)
                {
                    ans = ans || haspathSum(node.left, subsum);
                }
                if (node.right != null)
                {
                    ans = ans || haspathSum(node.right, subsum);
                }
                return ans;
            }
        }
    }//Class
}
