/*
 * Jamie Terry 
 * Partners: JunBo Park, Anthony Arellano
 * 
 * Write a C# program that asks the user to enter a string. 
 * Then your program should reverse the words in the given string, and display it back to the user.
 * 
 */
 
using System;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a String: ");
            String input = Console.ReadLine(); //user input string 
            String reverse = ""; //set as empty, to itterate through later 

            for (int i = (input.Length-1); i >= 0; i--) //starts itteration at the end of the string, and itterates backwards until at the 0th position
            {
                reverse = reverse + input[i]; //this fills our new string with the backwards version of our user input string, character by character. 
            }

            Console.WriteLine(input + " backwards is: " + reverse);
        }
    }
}
