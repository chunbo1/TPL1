using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTowList
{
    public class ListNode
    {
        internal int val;
        internal ListNode next;
        internal ListNode(int x) { val = x; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            ListNode head1 = new ListNode(0);
            head1 = CreateList(random, 3, 5);
            ListNode head2 = new ListNode(0);
            head2 = CreateList(random,1, 5);
            printList(head1);
            printList(head2);
            ListNode combined = MergeTwoList(head1, head2);
            printList(combined);
        }//Main

        private static ListNode CreateList(Random random, int start, int factor)
        {
            ListNode curr = null;
            ListNode head = new ListNode(0); 
            for (int i = start; i < start+5; i++)
            {
                ListNode newNode = new ListNode(i+factor);
                if (i == start)
                {
                    head.next = newNode;
                    curr = newNode;
                }
                else
                {
                    curr.next = newNode;
                    curr = newNode;
                }

            }
            return head;
        }

        static ListNode MergeTwoList(ListNode  l1, ListNode  l2)
        {
            ListNode temp_node = new ListNode(0);
            ListNode curr = temp_node;

            while (l1!= null && l2!= null)
            {
                if (l1.val < l2.val)
                {
                    curr.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    curr.next = l2;
                    l2 = l2.next;
                }
                curr = curr.next;

            }//while

            if (l1 != null)
                curr.next = l1;
            if (l2 != null)
                curr.next = l2;

            return temp_node.next;
        }

        /* Method to print linked list */
        static void printList(ListNode head)
        {
            ListNode temp = head;
            while (temp != null)
            {
                Console.Write(temp.val+ " ");
                temp = temp.next;
            }
            Console.WriteLine();
        }

    }//Class
}
