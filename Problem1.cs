/* 
 * Jamie Terry 
 * Partners: JunBo Park and Anthony Arellano
 * 
 * Problem 1: Create a program that asks a user to enter a string. The program then counts and displays the number of "e" or "E" in the given input. 
 */

using System;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a string: ");
            String input = Console.ReadLine();  //takes input string 
           
           
            Console.WriteLine("There are " + stringCount(input) + " E's in the String"); //sends the string to stringCount method, and returns count of e's
        }

        static int stringCount(String input)
        {

            int eVal = 0;
            for(int i = 0; i<input.Length; i++) //iterates through string 
            {
                if (input[i].Equals('E') || input[i].Equals('e')) //compares chars of string to chars E and e
                    eVal += 1; 
            }

            return eVal;
        }
    }


}
