using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace adventOfCode2
{
    class Program
    {

        class Patch
        {
            public int trX, trY, blX, blY;
        }

        void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Addison\source\repos\adventOfCode\test_input.txt");
            Patch[] patches;

            foreach (string s in lines)
            {
                string[] numbers = Regex.Split(s, @"\D+");
                int[] values = new int[5];
                int i = 0;

                for (int j = 0; j < numbers.Length; j++)
                {
                    if (!string.IsNullOrEmpty(numbers[j]))
                    {
                        values[i] = int.Parse(numbers[j]);
                        i++;
                    }
                }

                Patch newPatch = new Patch();
                newPatch.trX = values[1] + values[3];
                newPatch.trY = values[2];
                newPatch.blX = values[1] + values[3];
                newPatch.blY = values[2] + values[4];


            }
        }
    }
}
