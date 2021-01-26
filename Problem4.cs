/*
 * Jamie Terry 
 * Pertners: JunBo Park, Anthony Arellano 
 * 
 * Write a C# program that randomly generates two integers between 1 and 15 inclusively, called a and b. 
 * Then it randomly generates a number between 1 and 4, called operation. 
 * 1=a+b, 2=a*b, 3=a-b, 4=a/b, the user must answer what the operation equals 
 * if the user answers correctly, then output a congradulations message, otherwise output a message indicating the answer entered was wrong. 
 */

using System;

namespace Problem4
{
    class RandomNumberSample
    {
        static void Main(string[] args)
        {
            int c = 0;
            char userOp = '+';

            Random rnd = new Random();
            int a = rnd.Next(1, 16); //randomly generates val between 1-15
            int b = rnd.Next(1, 16); 
            int op = rnd.Next(1, 5); //randomly generates val between 1-4

            if (op == 1) //addition if op = 1
            {
                c = a + b; //shows operand when doing console write 
                userOp = '+';
            }
            else if (op == 2) //multiplication if op = 2
            {
                c = a * b;
                userOp = '*';
            }
            else if (op == 3) //sub if op = 3
            {
                c = a - b;
                userOp = '-';
            }
            else if (op == 4) //div if op = 4
            {
                c = a / b;
                userOp = '/';
            }

            Console.WriteLine("Welcome to a test the proves your mathematical prowess! Are you able to solve this?");
            Console.WriteLine(a + " " + userOp + " " + b);
            String answer = Console.ReadLine(); 

            int intAnswer = Int32.Parse(answer); //converts input string to int

            if (c == intAnswer) // compares the actual answer to user answer 
                Console.WriteLine("Congradulations! You must be a genious (: ");
            else
                Console.WriteLine("Not quite. Maybe you should use a calculator next time...");

        }
    }
}

    
