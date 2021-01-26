/* Jamie Terry 
 * Partners: Anthony Arellano, JunBo Park 
 * 
 * runtime: O(log n)
 * 
 */


using System;

namespace HW2_Prob2_JamieTerry
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        int sumDigits(int n) //digit can have a value up to 10^d, if n = 10^d then d = log(n), so O(log n)
        {
            int sum = 0; 
            while (n > 0) 
            {
                sum += n % 10; 
                n /= 10; 
            }
            return sum;
        }
    }
}
