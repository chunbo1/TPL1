using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midMode
{
    public class ListNode
    {
        int val;
        internal ListNode next;
        internal ListNode(int x) { val = x; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ListNode curr = null;
            ListNode head = new ListNode(0); ;
            for (int i= 0; i<5; i++)
            {
                ListNode a = new ListNode(i);
                if (i == 0) {
                    head.next = a;
                    curr = a;
                }
                else
                {
                    curr.next = a;
                    curr = a;
                }

            }

            Program ins = new Program();
            ins.middleNode(head);

        }

        public ListNode middleNode(ListNode head)
        {
            ListNode a = head;
            ListNode b = head;
            while (b!= null&& b.next!= null)
            {
                a = a.next;
                b = b.next.next;
            }
            return a;
        }
    }
}
