using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace adventOfCode2
{
    class Program
    {
        
        class Patch //can be defined by its top left and bottom right coordinates
        {
            public int tlX, tlY, brX, brY; 
        }

        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Addison\source\repos\adventOfCode\test_input.txt");
            List<Patch> patches = new List<Patch>();
            int sqInCount = 0;

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
                newPatch.tlX = values[1];
                newPatch.tlY = values[2];
                newPatch.brX = values[1] + values[3];
                newPatch.brY = values[2] + values[4];

                
                patches.Add(newPatch);
               
            }

            Console.WriteLine(patches.Count);
           
            for (int i = 0; i < patches.Count; i++)
            {
                for(int j = 1; j < patches.Count; j++)
                {
                    bool overlaps = DoOverlap(patches[i], patches[j]);
                    Console.WriteLine(overlaps);
                    if (overlaps) { sqInCount = AddSqIn(patches[i], patches[j], sqInCount); }
                    overlaps = false;
                }
            }

            Console.WriteLine(sqInCount);
        }

        static bool DoOverlap(Patch a, Patch b)
        {
            // If one rectangle is on left side of other  
            if (a.tlX > b.brX || b.tlX > a.brX)
            {
                return false;
            }

            // If one rectangle is above other  
            if (a.tlY > b.brY || b.tlY > a.brY)
            {
                return false;
            }
            return true;
        }

        static int AddSqIn(Patch a, Patch b, int sqInCount)
        {
            int patchWidth = Math.Abs((a.brX - b.tlX));
            int patchHeight = Math.Abs((a.tlY - b.brY));
            Console.WriteLine("Width: {0} Height: {1}", patchWidth, patchHeight);
            return sqInCount + (patchHeight * patchWidth);
        }
    }
}
