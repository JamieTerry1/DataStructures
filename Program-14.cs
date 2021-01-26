/*Jamie Terry 
 * Partners: JunBo Park, Anthony Arellano
 * 
 * Remove a node from a singly linked list without knowing the head node. 
 * All you have is the node itself. As a comment, at the beginning of your 
 * code/method, include the running time (big Oh) for your solution.
 * 
 * RUNTIME: O(n)
 * 
 */

using System;

namespace DSA_HW3_Prob3
{
    class Program
    {

        static void Main(string[] args)
        {
            LinkedList myList = new LinkedList();
            myList.AddFront(5);
            myList.AddFront(4);
            myList.AddFront(3);
            myList.AddFront(2);
            myList.AddFront(1);
            myList.Print();
            myList.Delete(myList.Head.Next.Next);
            myList.Print();


        }

        class Node
        {
            //data 
            public int Value { get; set; }
            public Node Next { get; set; }

            public Node(int someValue)
            {
                Value = someValue;
            }
        }

        class LinkedList
        {
            public Node Head { get; set; }

            public void Delete(Node n)
            {
                if (n.Next == null)
                {
                    n = null;
        
                }
                else
                {
                    Node current = n;

                    while (current.Next != null)
                    {
                        current.Value = current.Next.Value;

                        if (current.Next.Next == null)
                        {
                            current.Next = null;
                            break;

                        }

                        current = current.Next;
                    }

                }

                return;
            }

            //adds node to front 
            public void AddFront(int someValue) //running time O(1)
            {
                Node newNode = new Node(someValue); //make a new node
                newNode.Next = Head; //newnode should point to head
                Head = newNode; //change the head to point to the new node
            }

            //checks if list is empty
            public bool IsEmpty() //running time: O(1)
            {
                //return head == null;
                if (Head == null)
                    return true;
                else
                    return false;
            }

            //prints list
            public void Print()
            {

                if (IsEmpty())
                    Console.WriteLine("the list is empty!");
                else
                {
                    Node finger = Head; //starts at the head
                    while (finger != null)//as long
                    {
                        Console.Write(finger.Value + " ");
                        finger = finger.Next; //moves the finger to the right
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                }

            }

        }
        
    }
}
