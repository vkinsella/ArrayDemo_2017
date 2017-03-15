using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayDemo_2017
{
    class Program
    {
        // creating an array of 5 elements all of type int

        // not that since i have decalred the array here, all methods have access to it
        static int[] myScores = new int [5];
       
        // initialising an array with some values
        static string[]lastNames = { "Murphy", "Ryan", "Kelly", "Smith"};

        static void Main(string[] args)
        {
            GetScores();

            PrintScores();

            double avg = FindAverage(); // using our own average method

            Console.WriteLine("Tne average score is {0}", avg);

            avg = myScores.Average(); // using built in avergae method

            // search for a name entered by the user
            Console.WriteLine("Enter search name : ");
            string target = Console.ReadLine();
        
            bool matchFound = Search(target);

            if (matchFound == true)
                Console.WriteLine("Match Found");
            else
                Console.WriteLine("No person wth this name");

            // or we could build BinarySearch method, which is quicker for large arrays

            Array.Sort(lastNames);  // must be sorted ussing the Sort () method in the Array class for binary search to work

            int position = Array.BinarySearch(lastNames, target); // return the index of the found item, -1 if not found

            
            if (position >= 0)
                Console.WriteLine("Found at position {0}", position);
            else
                Console.WriteLine("Not found");




        }

        static bool Search(string target)
        {
            bool result= false;
            // do search

            int index = 0;  // start position for search
            
            // keep looking until match found or we have got to the end
            while (result == false && index < lastNames.Length)
            {
                if (lastNames[index] == target)
                    result = true;

                index++;

            }
            

            return result;
        }

        static double FindAverage()
        // Method to find the avergae of all values sored in the array
        {
            
            int total = 0;
            double avg;

            // step thtough each element accumulating all the values in the variable total
            for (int i = 0; i < myScores.Length; i++)
            {
                total += myScores[i];
            }

            avg = (double) total / myScores.Length;  // note the (double) cast as i want a decimal result

            return avg;

        }

        static void GetScores()
        // method to populate the array with scores entered by the user
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter score {0} ", i+1);
                myScores[i] = int.Parse(Console.ReadLine());

            }
        }

        static void PrintScores()
        // method to print all the scores in the array
        {
            for (int i = 0; i < myScores.Length; i++)
            {
                Console.WriteLine("Score {0} = {1}", i + 1, myScores[i]);
            }

            // or could use foreach

            foreach (int item in myScores)
            {
                Console.WriteLine("Score = {0}", item);
            }
        }


    }
}
