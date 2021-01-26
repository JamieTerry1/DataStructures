/* Jamie Terry 
 * Partners: JunBo Park, Anthony Arellano 
 * 
 * Given a circular linked list, implement an algorithm that returns the node at the beginning of the loop. 
 * As a comment, at the beginning of your code/method, include the running time (big Oh) for your solution.
 * DEFINITION:  Circular linked list: A (corrupt) linked list in which a node's next pointer points to an 
 * earlier node, so as to make a loop in the linked list.
 * 
 * EXAMPLE
 * Input:  A ->  B -> C -> D ->  E -> C [the same C as earlier!]
 * Output: C
 * 
 * RUNTIME: O(n)
 * 
 * modified code from: https://www.geeksforgeeks.org/find-first-node-of-loop-in-a-linked-list/
 * also met with partners to go over code 
 * 
 */

using System;
using System.Collections.Generic;
using System.Xml;

namespace DSA_HW3_Prob2
{
   
    using System;
    class LinkedListLoop
    {
        //creation of the Node class 
        class Node
        {
            public int data;
            public Node next;
        };

        //method to add new node 
        static Node newNode(int data)
        {
            Node temp = new Node();
            temp.data = data;
            temp.next = null;
            return temp;
        }

        //prints linked list
        static void printList(Node head)
        {
            while (head != null)
            {
                Console.Write(head.data + " ");
                head = head.next;
            }
            Console.WriteLine();
        }

        // Function to detect loop in a linked list that may contain loop
        static Node detectLoop(Node head)
        {
            // If list is empty or has only one node without loop
            if (head == null || head.next == null)
                return null; //this will exit out, since there was nothing to find 

            Node slow = head, fast = head; //sets slow and fast to start at the beginning node 

            // Move slow 1 step and fast 2 steps 
            slow = slow.next;
            fast = fast.next.next;

            // Search for loop using slow and fast pointers
            while (fast != null &&
                   fast.next != null) //runs while fast and the next node are not null (using fast since this will encounter nodes before slow)
            {
                if (slow == fast)
                    break; //this prevents an infinite loop when fast and slow find the same point, and sends to later while loop
                slow = slow.next; //skips by 1
                fast = fast.next.next; //skips by 2
            }

            // If loop does not exist
            if (slow != fast) //if fast and slow are never equal, there is no loop
                return null;

            // If loop exists. Start slow from head and fast from meeting point.
            slow = head; //starts slow at beginning again 
            while (slow != fast)
            {
                slow = slow.next; //steps by single increments now 
                fast = fast.next; //steps by single step through the loop
            }

            return slow; //when slow is equal to fast the point where the loop begins will be returned 
        }

        // Driver code
        public static void Main(String[] args)
        {
            Node head = newNode(50);
            head.next = newNode(20);
            head.next.next = newNode(15);
            head.next.next.next = newNode(4);
            head.next.next.next.next = newNode(10);
            head.next.next.next.next.next = newNode(5);

            // Create a loop for testing
            head.next.next.next.next.next = head.next.next; //this is causing a pointer to point to a previous node, instead of a null statement 

            Node loop = detectLoop(head);

            if (loop == null)
                Console.Write("Loop does not exist");
            else
                Console.Write("Loop starting node is " + loop.data);
        }
    }
}
