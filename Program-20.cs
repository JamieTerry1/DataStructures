/* Jamie Terry 
 * Partners: Anthony Arellano, JunBo Park 
 * 
 * Create a doubly linked list that is generic. Make sure it includes the following methods (and test them with both int and string):
 * 
 * AddFirst
 * AddLast
 * DeleteFirst
 * DeleteLast
 * Delete(given a value)
 * Delete(given a node)
 * Reverse
 * IsEmpty
 * Clear
 * Print
 */


using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml;

namespace DSA_HW4_Prob1
{
    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList<int> mylist = new DoubleLinkedList<int>();
            mylist.AddFirst(5);
            mylist.AddFirst(10);
            mylist.AddFirst(21);
            mylist.AddLast(17);
            mylist.AddLast(20);
            mylist.AddLast(9);
            mylist.Print();
            mylist.DeleteFirst();
            mylist.Print();
            mylist.DeleteLast();
            mylist.Print();
            mylist.DeleteNode(mylist.head.next);
            mylist.Print();
            mylist.DeleteValue(17);
            mylist.Print();
            //mylist.Reverse();
            //mylist.Print();
            


        }
    }

    public class DoubleLinkedList<T>
    {

        public DNode<T> head;

        public class DNode<T> //creates the nodes to be used in the linked list 
        {
            public  T data;
            public DNode<T> prev;
            public DNode<T> next;
            public DNode(T d)
            {
                data = d;
                prev = null;
                next = null;
            }

            public DNode()
            {
                prev = null;
                next = null;
            }
        }


        public DoubleLinkedList()
        {
            head = null;
        }


        //RUNTIME: O(1)
        //add to the front of the list 
        public void AddFirst(T data)
        {
            DNode<T> newNode = new DNode<T>(data); //retrieves data 
            newNode.next = head; //sets the head to point to the next value 
            newNode.prev = null; //set to null, since the head cannot point backwards 

            if (head != null)
                head.prev = newNode; //sets the previous pointer of the new node 

            head = newNode; //head is assigned new node 

        }


        //RUNTIME:  O(N)
        //add to the end of the list 
        public void AddLast( T data)
        {
            DNode<T> newNode = new DNode<T>(data);
            if (head == null) //if the list is empty 
            {
                newNode.prev = null;
                head = newNode; //set the value sent as the head 
                return;
            }

            DNode<T> lastNode = GetLastNode(); //retrieves the last node 
            lastNode.next = newNode;//sets next value to be the value added to the end 
            newNode.prev = lastNode; //sets the previous value to be te value before added node 
        }


        //RUNTIME: O(1)
        //delete the first node 
        public void DeleteFirst()
        {
            head = head.next; //the next node is now the head 
           
        }


        //RUNTIME: O(N)
        //delete the last node 
        public void DeleteLast()
        {
            GetLastNode().prev.next = null; //points node before lest node to null

        }


        //RUNTIME: O(N)
        //delete a given value 
        public void DeleteValue(T key)
        {
            DNode<T> temp = head; //sets temp node to the head 
            if (temp != null && temp.data.Equals(key)) //if the temp is not null, and the temp data is equal to the value to delete 
            {
                head = temp.next; //set the head equal to the next node 
                head.prev = null; //since 2nd node is now the head, set previous to null
            }

            while (temp!= null) //moves the temp node value through the list until it finds key value 
            {

                if (temp.data.Equals(key)) //if the key is equal to the temp value 
                {
                    if (temp == null)
                        return;

                    if (temp.next != null)
                        temp.next.prev = temp.prev; //connects next node to point to the node before the deleted node 

                    if (temp.prev != null)
                        temp.prev.next = temp.next; //previous node points to the node after the deleted node 
                }

                temp = temp.next;
            }

        }


        //RUNTIME: O(N)
        //delete a given node 
        public void DeleteNode(DNode<T> delete)
        {
            DNode<T> temp = head; //assigns temp to the first node 
            if (temp != null && temp == delete) //if the front of the list is the node
            {
                head = temp.next; //move head to next value
                head.prev = null; //previous becomes null
            }

            while (temp != null && temp != delete) //itterate through list until finds node to delete 
                temp = temp.next; //moves to itterate 

            if (temp == null) //when temp equals null, returns, since this is an empty list 
                return;

            if (temp.next != null) //sets the previous value for the next node 
                temp.next.prev = temp.prev;

            if (temp.prev != null) //sets the next value for the previous node 
                temp.prev.next = temp.next;



            //if I could implement the code JunBo came up with this would be runtime O(1), however, this code breaks my reverse function...
            //if (IsEmpty()) 
            //    Console.WriteLine("The list is empty. There is no node to delete");

            //else
            //{
            //    if (delete == head)
            //        delete = delete.next;

            //    else
            //        delete.prev.next = delete.next;
            //}
        }


        //RUNTIME: O(N)
        //method to find the last node of the linked list 
        public DNode<T> GetLastNode() 
        {
            DNode<T> temp = head;
            while (temp.next != null) //itterates until it hits the end of the list 
            {
                temp = temp.next;
            }
            return temp; //returns the last node 
        }


        //RUNTIME: O(N)
        //reverse the list 
        public void Reverse()
        {
            DNode<T> start = head;
            DNode<T> end = GetLastNode();


                while (start != end) //this while loop is to reverese the string if there is an odd # of nodes 
                {
                    T temp = end.data; //sets temp to last node 
                    end.data = start.data; //last node data filled with start data
                    start.data = temp; //first node filled with temp data (end data)

                    if (start.next == end) //breaks out of loop 
                        break;

                    start = start.next; //moves start up one 
                    end = end.prev; //moves end back one 
                
                } 


        }


        //RUNTIME: O(1)
        //check if list is empty 
        public bool IsEmpty()
        {
            if (head == null) //if head is null, then the list is empty 
                return true;

            return false; //otherwise list has data 
                   
        }


        //RUNTIME: O(1)
        //clear the list 
        public void Clear()
        {
            head = null; //head becomes null, clearing the list 
            head.next = null; //the head's next pointer becomes null 
        }


        //RUNTIME: O(N)
        //print the list 
        public void Print()
        {
            DNode<T> temp = head; //sets temp to the front of the list 

            while( temp != null)
            {
                Console.Write(temp.data); //prints temp's current value 
                Console.Write(" ");
                temp = temp.next; //moves to next node 
                
            }
            Console.WriteLine();
        }
    }
}
