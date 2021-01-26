/* Jamie Terry 
 * Partners: Anthony Arellano , JunBo Park 
 * 
 * Let Q be a non-empty queue, and let S be an empty stack. Write a C# 
 * program that reverses the order of the elements in Q, using S. Make 
 * sure to include running and space complexity for your code.
 * Example: if initially the order of the objects in Q is 1,2,3,4,5,6, 
 * then after reversing the objects, the order of the objects in Q is 6,5,4,3,2,1.
 * 
 * Note: For this part you may use any Queue and Stack classes you wish 
 * (implemented in class, or from the C# library). You can write all code in Main,
 * or (ideally) you would create a method (that can be reused!).
 * 
 */


using System;
using System.Collections.Generic;

namespace DSAHW_Week5_Prob1
{
    class Program
    {

        public static LinkedList<int> queue;


        //driver method RUNTIME: O(1)
        static void Main(string[] args)
        {
            queue = new LinkedList<int>(); //initiialziation of the queue
            queue.AddLast(10);
            queue.AddLast(20);
            queue.AddLast(30);
            queue.AddLast(40);
            queue.AddLast(50);
            queue.AddLast(60);
            queue.AddLast(70);
            queue.AddLast(80);
            queue.AddLast(90);
            queue.AddLast(100);

            ReverseQueue(); 
            Print();
        }


        //method that reverses the queue using a stack 
        //RUNTIME: O(n)
        public static void ReverseQueue()
        {
            Stack<int> stack = new Stack<int>(); //initiaize the stack 
            while(queue.Count > 0) 
            {
                stack.Push(queue.First.Value); //pushes first value of the queue onto the stack 
                queue.RemoveFirst(); //dequeues the queue 
            }
            while (stack.Count > 0)
            {
                queue.AddLast(stack.Peek()); //enquese the queue 
                stack.Pop(); //pops off the stack 
            }
        }


        //method that prints the queue 
        //RUNTIME: O(n)
        public static void Print()
        {
            while (queue.Count > 0) //itterates through the queue 
            {
                Console.Write(queue.First.Value + " "); //prints the first value of the queue 
                queue.RemoveFirst(); //removes the value to move to next position.
            }

            Console.WriteLine();
        }
    }
}
