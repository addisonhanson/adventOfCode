using System;

namespace adventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
             
            int[] lineCount; //arry to count iterations of each letter
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Addison\source\repos\adventOfCode\day2_input.txt");
            lineCount = new int[26];
            int twice = 0;
            int thrice = 0;
            bool foundTwice, foundThrice;

                for(int i = 0; i < 26; i++)
                { //initialize array with 0's
                    lineCount[i] = 0;
                }

                foreach (string line in lines)
                {
                    lineCount = countLetters(line);
                    foundTwice = false; //once one letter is found twice, we dont want to double count an ID if we find another letter exactly twice
                    foundThrice = false;
                    foreach (int i in lineCount)
                     {
                    if ((i == 2) && (foundTwice == false)) { twice++; foundTwice = true; } //set bool to true once we find the first one.
                    else if ((i == 3) && (foundThrice == false)) { thrice++; foundThrice = true; }
                      }
                }
            int checkSum = twice * thrice;

            Console.WriteLine("Twice : {0} Thrice: {1} Checksum: {2}\n", twice, thrice, checkSum);
        
        }

        static int[] countLetters(string boxID)
        {
            char[] charArr = boxID.ToCharArray();
            int[] alphabet = new int[26];

            foreach (char c in charArr)
            {
                int ascii = ((int)c - 97); //casts character to int and subtracts 97 (ascii value of 'a') so the alphabet array lines up.
                alphabet[ascii]++;
            }


            return alphabet;

        }
    }
}
