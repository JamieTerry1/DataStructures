/*
 * Jamie Terry 
 * 
 * Partners: Anthony Arellano, JunBo Park
 * 
 * Implement a Queue class using two stacks (for hints, see problem 
 * 3.4/page 99 from "Cracking the coding interviews..."). What is 
 * the running time for enqueue() and dequeue()? Make your classes 
 * generic. Make sure to include running and space complexity for 
 * your methods. 
 * 
 * Note: the question may seem hard at first, but once you figure 
 * out the logic, the coding is straightforward (and quite short). 
 * So before you start coding it, please discuss it with your team.
 * 
 * code referenced: https://www.geeksforgeeks.org/queue-using-stacks/
 * 
 */



using System;
using System.Collections;

namespace DSAHW_Week5_Prob3
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue q = new Queue();//initializes queue 
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);

            Console.WriteLine(q.Dequeue() + " ");
            Console.WriteLine(q.Dequeue() + " ");
            Console.WriteLine(q.Dequeue());
    
        }

        Stack s1 = new Stack(); //initializes stack 1
        Stack s2 = new Stack(); //initializes stack 2

        //runtime O(n)
        public void Enqueue(int x)
        {
            // Move all elements from s1 to s2  
            while (s1.Count > 0)
            {
                s2.Push(s1.Pop()); //pops elements from 1 and pushes to 2
                
            }

            // Push item into s1 , adding at the back of the queue 
            s1.Push(x);

            // Push everything back to s1  
            while (s2.Count > 0)
            {
                s1.Push(s2.Pop()); //pops elements from s2 into s1
                
            }
        }

        //runtime: O(1)
        public int Dequeue()
        {
            // if first stack is empty  
            if (s1.Count == 0)
                Console.WriteLine("Queue is Empty, cannot dequeue");

            // Return top of s1  (or the front of the queue) 
            int x = (int)s1.Peek();
            s1.Pop(); //pops the value from s1
            return x; //returns the dequeued value 
        }
    }
}
