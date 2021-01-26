/* Jamie Terry 
 * Partners: Anthony Arellano, JunBo Park
 * 
 * Problem 2 (Generic Array List): Create a generic array list. Make sure it includes the following methods (and test them with both int and string):
 * 
 * AddFirst
 * AddLast
 * Insert(given a value and an index)
 * DeleteFirst
 * DeleteLast
 * Delete(given a value)
 * Delete(given an index)
 * Reverse
 * IsEmpty
 * Clear
 * Print
 */

using System;

namespace DSA_HW4
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList<int> mylist = new ArrayList<int>(); //initialize the array with integers 
            mylist.AddLast(5);
            mylist.AddLast(15);
            mylist.AddLast(7);
            mylist.AddFront(12);
            mylist.AddFront(37);
            mylist.AddFront(92);
            mylist.Print();

            mylist.Insert(5, 7);
            mylist.Print();

            mylist.DeleteFirst();
            mylist.Print();

            mylist.DeleteLast();
            mylist.Print();

            mylist.DeleteValue(37);
            mylist.Print();

            mylist.DeleteIndex(2);
            mylist.Print();

            mylist.Reverese();
            mylist.Print();

            ArrayList<string> stringlist = new ArrayList<string>();
            stringlist.AddLast("hello");
            stringlist.AddLast("hi");
            stringlist.AddLast("howdy");
            stringlist.AddFront("hola");
            stringlist.AddFront("bonjour");
            stringlist.AddFront("sup");
            stringlist.Print();

            stringlist.Insert("hiii", 5);
            stringlist.Print();

            stringlist.DeleteFirst();
            stringlist.Print();

            stringlist.DeleteLast();
            stringlist.Print();

            stringlist.DeleteValue("bonjour");
            stringlist.Print();

            stringlist.DeleteIndex(1);
            stringlist.Print();

            stringlist.Reverese();
            stringlist.Print();


        }
    }

    class ArrayList<T>
    {
        private T[] values;
        public int Count { get; private set; }
        public int Capacity { get; private set; }


        public ArrayList(int capacity = 10)
        {
            Count = 0; //starts count at index 0
            Capacity = capacity; //capacity becomes 10 by default.
            values = new T[Capacity]; //allocates memory for the array 

        }


        //method to add value to end of ArrayList
        public void AddLast(T someNewValue) 
        {
            if (Count == Capacity)
                ResizeTheArray();

            values[Count] = someNewValue; //adds value to end of array 
            Count++; //moves counter to next position
        }


        //method to insert value at beginning of list 
        public void AddFront(T someNewValue)
        {
            if (Count == Capacity)
                ResizeTheArray();

            for (int i = values.Length-1; i > 0; i--) //starting at the back of the array, and moving to front 
            {
                values[i] = values[i-1]; //move each position up 1
            }

            values[0] = someNewValue; //sets the 0th position to new val 

        }


        //method to insert val at a given index 
        public void Insert(T someNewValue, int i)
        {
            if (Count == Capacity)
                ResizeTheArray();

            for(int j = values.Length; j > i ; j--)
            {
                values[i] = values[i - 1]; //move each position up 1, until it reach user index 
            }
            
            values[i] = someNewValue; //sets user index to the new value 

        }


        //method to delete the first value of the array 
        public void DeleteFirst()
        {

            T[] deleteFirst = new T[values.Length - 1]; //creates array with one less index than values[]
            for(int i = 1; i<values.Length; i++)
            {
                deleteFirst[i-1] = values[i]; //starting at 0 in the second array, fills with values from 1th place of values array list 
            }

            values = deleteFirst; //sets values to be the same as array 


        }


        //method to delete the last value of the array 
        public void DeleteLast()
        {
            T[] deleteLast = new T[values.Length - 1]; //create temp array
            for(int i =0; i<values.Length - 1; i++) //itterates through both values and temp array
            {
                deleteLast[i] = values[i]; //appends values array into temp array (except for final index)
            }

            values = deleteLast; //values array is filled with the temp array 
        }


        //method to delete a specific value 
        public void DeleteValue(T key)
        {
            int instance = 0;
           for (int i = 0; i < Count; i++) //itterates through the array 
            {
               if (values[i].Equals(key))
                  instance++; //counts how many times the "key" appears in the array list 

            }

            T[] temp = new T[values.Length - instance]; //creates new temp array, minus instances of key found 


            int j = 0;
            for (int i =0; i < Count; i++)
            {
                if (!(values[i].Equals(key))) //checks if the key is present 
                {
                    temp[j++] = values[i]; 

                }

            }

            values = temp; //fills in values array list 

        }


        //method to delete a specific index 
        public void DeleteIndex(int index)
        {

            T[] temp = new T[values.Length - 1]; //temp array, length smaller than values by 1
            temp = values; //temp is filled with vlaues of values[]

            for (int i = index; i < values.Length-1; i++) //itterate through arrays, starting at index sent by user
            {
                temp[i] = values[i + 1]; //moves all elements after index to the left
            }

            values = temp; //sets values equal to the temp array 

        }


        //method to reverese the list 
        public void Reverese()
        {
            for (int i = 0; i < values.Length / 2; i++) //itterate through the array 
            {
                T temp = values[i]; //creates new temporary array 
                values[i] = values[values.Length - i - 1]; //moves backwards, to fill array 
                values[values.Length - i - 1] = temp; //fills in array with the remaining values stored in temp "swapping" places 
            }

        }


        //method to check if the list is empty 
        public bool IsEmpty()
        {
            Count = 0; //sets count to 0th position
            if (values[Count] == null) //if the 0th index is null, return true 
            {
                return true;
            }

            return false;

        }


        //method to clear the list 
        public void Clear()
        {
            for(int i = 0; i < values.Length; i ++) //itterates through the array 
            {
                values[i] = default(T); //sets all values to null 
            }

        }


        //method to resize the array 
        public void ResizeTheArray()
        {
            Capacity = Capacity * 2;

            T[] LargerArray = new T[Capacity];

            for (int i = 0; i < Count; i++)
                LargerArray[i] = values[i];

            values = LargerArray; //renames the array to "values"
        }


        //method to print the array 
        public void Print()
        {
            for (int i = 0; i < values.Length; i++)
            {
                Console.Write(values[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
