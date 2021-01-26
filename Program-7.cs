/* Jamie Terry 
 * Partners: Anthony Arellano, JunBo Park 
 * 
 * There are three types of edits that can be performed on strings: insert a character, 
 * remove a character, or replace a character. Given two strings, write a function to check 
 * if they are one edit (or zero edits) away.
 * EXAMPLE
 * pale, ple -> true
 * pales. pale -> true
 * pale. bale -> true
 * pale. bake -> false
 * 
 */

using System;

namespace HW2_Prob4_JamieTerry
{
    class Program
    {
        static void Main(string[] args)
        {
            //collects two strings from the user 
            Console.WriteLine("Please enter a string: ");
            string input1 = Console.ReadLine();
            Console.WriteLine("Please make One edit to this string: ");
            string inputEdit = Console.ReadLine();

            //if one edit made returns true statment 
            if (CheckEdits(input1, inputEdit))
                Console.WriteLine("One or less Edits made: true");
            //if more edits are mode, returns false statement
            else
                Console.WriteLine("One Edit made: false");
        }

        static bool CheckEdits(string s1, string s2)
        {
            //length of the given strings
            int m = s1.Length, n = s2.Length;

            //if difference between length is > 1, return false 
            if (Math.Abs(m - n) > 1)
                return false;

            //count of the edits 
            int count = 0;
            int i = 0, j = 0;

            while (i<m && j < n)
            {
                //if the current characters don't match 
                if (s1[i] != s2[i])
                {
                    if (count == 1)
                        return false;

                    //if length of one string is more, 
                    //then only possible edit is to remove a character 
                    if (m > n)
                        i++;
                    else if (m < n)
                        j++;

                    //if length of both strings is the same 
                    else
                    {
                        i++;
                        j++;
                    }

                    count++;
                }

                //if current characters match 
                else
                {
                    i++;
                    j++;
                }
            }

            //if last character is extra in any string 
            if (i < m || j < n)
                count++;

            return count == 1;
            
        }
    }
}
