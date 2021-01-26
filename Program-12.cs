/*
 *  Jamie Terry 
 *  Partners: JunBo Park, Anthony Arellano
 * 
 *  Write code to partition a linked list around a value x, such that all nodes less than x come before all 
 *  nodes greater than or equal to x. lf x is contained within the list, the values of x only need to be after 
 *  the elements less than x (see the book for an example). The partition element x can appear anywhere in 
 *  the "right partition"; it does not need to appear between the left and right partitions. As a comment, 
 *  at the beginning of your code/method, include the running time (big Oh) for your solution.
 * 
 * RUNTIME: O(n)
 * 
 * code mostly used from https://www.geeksforgeeks.org/partitioning-a-linked-list-around-a-given-value-and-keeping-the-original-order/
 * added comments to show my understanding of the code, also went over this with group 
 * 
 */


using System;

namespace DSA_HW3_Prob1
{
    class Program
    {

        //driver code
        public static void Main()

        {
            //starting with an empty list
            Node head = NewNode(10);
            head.next = NewNode(4);
            head.next.next = NewNode(5);
            head.next.next.next = NewNode(30);
            head.next.next.next.next = NewNode(2);
            head.next.next.next.next.next = NewNode(50);

            int x = 7;
            head = Partition(head, x);
            PrintList(head);
        }

        //linked list node 
        public class Node
        {
            public int data;
            public Node next;
        }

        //function to create a new node
        static Node NewNode(int data)
        {
            Node newNode = new Node();
            newNode.data = data;
            newNode.next = null;
            return newNode;
        }

        //function to make two seperate lists and return 
        static Node Partition(Node head, int x)
        {
            Node smallerHead = null, smallerLast = null; //linked list of values smaller than x

            Node greaterLast = null, greaterHead = null; //linked list of values greater than x

            Node equalHead = null, equalLast = null; //linked list of values equal to x


            //itterate through original list and connect nodes of appropriate linked lists 
            while (head != null)
            {
                if (head.data == x)
                {
                    //if current node is equal to x, append it to the list of x values 
                    if (equalHead == null)
                        equalHead = equalLast = head; //sets equalHead and eqaul last to head (this will happen to start) 
                    else
                    {
                        equalLast.next = head; //sets value after x as the head of second linked list 
                        equalLast = equalLast.next; //moves to next node 
                    }
                }

                //if current node is less than x, append it to the list of smaller values 
                else if (head.data < x) //when node data is less than x
                {
                    if (smallerHead == null)
                        smallerLast = smallerHead = head; //will initially set smallerLast and smallerHead to the value of head 
                    else
                    {
                        smallerLast.next = head; //points the lsit to add values found to be less than head 
                        smallerLast = head; //last number before x is set 
                    }
                }

                else //append to the list of greater values 
                {
                    if (greaterHead == null)
                        greaterLast = greaterHead = head; //initially sets head and last of the second list to head 
                    else
                    {
                        greaterLast.next = head; //points the list to add values greater than x to the head of this list 
                        greaterLast = head; //first number after x
                    }
                }
                head = head.next; //increments the list 

            }

            //fix end of greater linked list to NULL if this list has some nodes 
            if (greaterLast != null)
                greaterLast.next = null;

            //connect three lists 

            //if smaller list is empty 
            if (smallerHead == null)
            {
                if (equalHead == null) //if x is not present 
                    return greaterHead; //only list will have been assigned to the right of x

                equalLast.next = greaterHead; //if x is present, then x is added to the front of the list 
                return equalHead; //List is returned 
            }

            //if smaller list is not empty and equal list is empty 
            if (equalHead == null)
            {
                smallerLast.next = greaterHead; //end of smaller list now points to beginning of bigger list 
                return smallerHead; //this is the head of list 
            }

            //if both the smaller and equal list are non-empty
            smallerLast.next = equalHead; //the last node of the smaller list now points to x value 
            equalLast.next = greaterHead; //the x value then points to the beginning of the second list 
            return smallerHead; //returns appended list 


        }

        //function to print linked list 
        static void PrintList(Node head)
        {
            Node temp = head;
            while (temp != null)
            {
                Console.WriteLine(temp.data + " ");
                temp = temp.next;
            }
        }
    }
}
