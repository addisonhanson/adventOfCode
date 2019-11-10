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
                    foundTwice = false;
                    foundThrice = false;
                    foreach (int i in lineCount)
                     {
                        if ((i == 2) && (foundTwice == false)) { twice++; foundTwice = true; }
                        else if ((i ==3) && (foundThrice == false)) { thrice++; foundThrice = true; }
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
                int ascii = ((int)c - 97);
                alphabet[ascii]++;
            }


            return alphabet;

        }
    }
}
