
/* Jamie Terry 
 * partners: Anthony Arellano, JunBo Park 
 * 
 * Palindrome Permutation: Given a string, write a function to check if it is a permutation of a 
 * palindrome. A palindrome is a word or phrase that is the same forwards and backwards. A 
 * permutation is a rearrangement of letters. The palindrome does not need to be limited to just 
 * dictionary words.
 * 
 * EXAMPLE
 * Input: Tact Coa
 * Output: True    (explanation - not part of the output ... permutations: "taco cat". "atco cta". etc.)
 * 
 */

using System;

namespace HW2_Prob3_JamieTerry
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a string to see if it is a permutation of a palindrome: ");
            string input = Console.ReadLine();

            input = input.Replace(" ", String.Empty);

            if (CheckPermutation(input))
                Console.WriteLine("True");
            else
                Console.WriteLine("False");
        }

        /// <summary>
        /// Counts the number of odd occurences of a character in a String. 
        /// If the odd number is > 1, the method returns false. 
        /// </summary>
        /// <param name="input">user input to be checked</param>
        /// runtime: O(n)
        /// <returns></returns>

        //current code cannot take in a space w/o returning false 
        static bool CheckPermutation(string input)
        {
            int NumberOfChars = 256;

            //Creates a count array and fills with the vlaue 0
            int[] count = new int[NumberOfChars];
            Array.Fill(count, 0);

            //for each character in input string, incremement count in 
            //the corresponding count array 
            for (int i = 0; i < input.Length; i++)
            {
                count[(int)(input[i])]++; 
            }

            //count odd occuring characters 
            int odd = 0;
            for (int i = 0; i < NumberOfChars; i++)
            {
                if ((count[i] & 1) == 1)
                    odd++;

                if (odd > 1)
                    return false;
            }

            //return true if odd count is 0 || 1
            return true;
            
        }
    }
}
