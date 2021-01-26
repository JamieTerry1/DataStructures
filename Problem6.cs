/*
 * Jamie Terry 
 * Partners: JunBo Park, Anthony Arellano 
 * 
 * modify your program 5 so everything seen in the console window 
 * (including all twenty random questions and user's answers) is also 
 * saved into a file, named output.txt.
 *
 */

using System;
using System.IO;

namespace Problem6
{
    class RandomNumberSample
    {
        static void Main(string[] args)
        {
            StreamWriter fileHandler = new StreamWriter("output.txt");
            
            int c = 0, correct = 0;
            char userOp = '+';

            Console.WriteLine("Welcome to a test the proves your mathematical prowess! " +
                "Are you able to solve these problems?");
            fileHandler.WriteLine("Welcome to a test the proves your mathematical prowess! " +
                "Are you able to solve these problems?");

            int i = 0;
            while (i < 20) //while loop so the program generates 20 problems 
            {
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


                Console.WriteLine(a + " " + userOp + " " + b);
                fileHandler.WriteLine(a + " " + userOp + " " + b);

                String answer = Console.ReadLine();
                fileHandler.WriteLine(answer);

                int intAnswer = Int32.Parse(answer); //converts input string to int

                if (c == intAnswer) // compares the actual answer to user answer, increments # correct 
                    correct++;
                i++;
            }

            Console.WriteLine("Congratulations! You got " + correct + " problems correct!"); //gives final correct amount the user got 
            fileHandler.WriteLine("Congratulations! You got " + correct + " problems correct!");
            fileHandler.Close();
        }
    }
}
