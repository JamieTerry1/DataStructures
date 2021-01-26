/* Jamie Terry 
 * Partners: JunBo Park, Anthony Arellano
 * 
 * Given a linked list of elements (say integers) and an array (of integers) delete 
 * elements from the linked list that are found in the array. As a comment, at the 
 * beginning of your code/method, include the running time (big Oh) for your solution.
 * 
 * RUNTIME: O(n)
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace DSA_HW3_Prob4
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int[] array = { 130, 112, 90, 75, 50, 20, 10 };
            Console.WriteLine("Array: ");
            foreach(int number in array)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();

            LinkedList myList = new LinkedList();
            
            myList.AddFront(10);
            myList.AddFront(17);
            myList.AddFront(21);
            myList.AddFront(50);
            myList.AddFront(77);
            myList.AddFront(92);
            myList.AddFront(112);
            myList.AddFront(131);
            Console.WriteLine("Linked List: ");
            myList.Print();

            Console.WriteLine("after removing repeats from list: ");
            myList.Compare(myList.Head, array);
            myList.Print();
           

            


        }

        class Node
        {
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

            public void Compare(Node Head, int[] array )
            {
                while (array.Contains(Head.Value)) //checks if array contains head's value 
                {
                    Head = Head.Next;
                }

                while (Head != null)
                {
                    if (array.Contains(Head.Next.Value))
                        Head.Next = Head.Next.Next;

                    Head = Head.Next;
                }
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
