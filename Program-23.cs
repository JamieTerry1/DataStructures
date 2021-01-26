/*
 * Jamie Terry 
 * 
 * Partners: Anthony Arellano, JunBo Park
 * 
 * Write a program that opens a text file (“input.txt”) and reads 
 * its contents. Then using a stack it reverses the lines of the 
 * file and saves them into another file (“output.txt”). Make sure 
 * to include running and space complexity for your code.
 * 
 * Hint: use System.IO.File.WriteAllLines and System.IO.File.ReadAllLines,
 * 
 * RUNTIME: O(n)
 * 
 */



using System;
using System.Text;
using System.IO;
using System.Collections;

namespace DSAHW_Week5_Prob2
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = @"file.txt"; //creates the file "file.txt"

            string[] createText = { "Hello", "Bonjour", "Hola", "Aloha" }; //strings to be added to the file

            File.WriteAllLines(path, createText, Encoding.UTF8); //adding strings to the file 

            string[] readText = File.ReadAllLines(path, Encoding.UTF8); //reading the file

            foreach (string s in readText) //writes lines to the console, this is to check the file is getting sent strings correctly. 
                Console.WriteLine(s);

            Console.WriteLine();


            Stack myStack = new Stack(); //initialize the stack

            foreach (string s in readText) //for each string in the file, add it to the stack
            {
                myStack.Push(s);
                
            }


            string newPath = @"output.txt"; //creates the new file to output

            using (StreamWriter sw = File.CreateText(newPath)) //adds lines to output.txt
            {
                while (myStack.Count != 0) //itterates through the stack
                {
                    Console.WriteLine(myStack.Peek()); //writes to console, to make sure strings are being added correctly
                    sw.WriteLine(myStack.Pop()); //pops off the stack. 
                }
            }




        }

    }
}
