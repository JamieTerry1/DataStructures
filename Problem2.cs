/*
 * Jamie Terry 
 * Partners: JunBo Park, Anthony Arellano 
 * 
 * Write a function that returns the nth prime number. For example, nthPrime(1) should return 2 since 2 is the first prime number, 
 * nth Prime(2) should return 3, nthPrime(3) should return 5, and so on. 
 * 
 * Hint: Use the IsPrime method from class 
 */

using System;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("The prime number is " + nthPrime(10)); //sends number to nthPrime to check what the nth Prime number is 
        }

        static bool IsPrime(int num) //isPrime function to check if value is Prime (from class) 
        {
            if (num == 2)
                return true;
            else if (num % 2 == 0)
                return false;

            for (int i = 3; i <= Math.Sqrt(num); i += 2)
            {
                if (num % i == 0)
                    return false;
            }
                return true;
        }

        static int nthPrime(int nextPrime) 
        {

            if (nextPrime == 1) //if given 1, we know the first prime number is 2 (it is also the only even prime)
                return 2;

            int primeFound = 3; //starting at 3, since this is the next prime number 
            int nthCounter = 2; //starting at 2, since this would be our next position, since nthPrime(1) is already accounted for above. 
            while (nthCounter < nextPrime)
            {
                primeFound+=2; //skip by two, since we know evens cannot be prime (this is to make program more efficient) 

                if (IsPrime(primeFound)) //this moves the counter forward by one, to continue until nthCounter = nextPrime (in this case, 10) 
                    nthCounter++; 
            }

            return primeFound;

        }
    }
}
