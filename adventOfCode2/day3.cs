using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace adventOfCode2
{
    class Program
    {
        static List<Patch> patches = new List<Patch>(); //list of overlapping area
        
        class Patch //can be defined by its top left and bottom right coordinates, used to represent both claims and overlapping patches
        {
            public int tlX, tlY, brX, brY; 
        }

        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Addison\source\repos\adventOfCode\day3_input.txt");

            List<Patch> claims = new List<Patch>();
            int sqInCount = 0;

            foreach (string s in lines) //main loop to iterate over claim records
            {
                string[] numbers = Regex.Split(s, @"\D+"); //parse claim records into coordinates and areas
                int[] values = new int[5];
                int i = 0;

                for (int j = 0; j < numbers.Length; j++)
                {
                    if (!string.IsNullOrEmpty(numbers[j]))
                    {
                        values[i] = int.Parse(numbers[j]); //builds a value array with information for each claim
                        i++;
                    }
                }

                Patch newClaim = new Patch(); // builds a patch object based on each claim 
                newClaim.tlX = values[1];
                newClaim.tlY = values[2];
                newClaim.brX = values[1] + values[3] - 1;
                newClaim.brY = values[2] + values[4] - 1;

                for (int k = 0; k < claims.Count; k++)
                { 
                        bool overlaps = DoOverlap(claims[k], newClaim);  //if the claims overlap, then we need to add the sqInches of overlapping space
                        if (overlaps) { sqInCount = AddSqIn(claims[k], newClaim, sqInCount); }
                        overlaps = false;
                    
                }

                claims.Add(newClaim);
               
            }

            Console.WriteLine("Square Inches: {0}", sqInCount);
        }

        static bool DoOverlap(Patch a, Patch b) //determines whether two claims or patches overlap using their 2 defined corners
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
            int patchWidth = Math.Min((Math.Abs(a.brX - b.tlX) + 1), (Math.Abs(b.brX - a.tlX) + 1)); //initial overlapping patch calculation
            int patchHeight = Math.Min((Math.Abs(a.tlY - b.brY) + 1), (Math.Abs(b.tlY - a.brY) + 1));
            Patch newPatch = new Patch();
            newPatch.tlX = Math.Max(a.tlX, b.tlX);
            newPatch.tlY = Math.Max(a.tlY, b.tlY);
            newPatch.brX = newPatch.tlX + patchWidth - 1;
            newPatch.brY = newPatch.tlY + patchHeight - 1;
            
            //if more than two claims overlap the same patch, we only want to count that sq area once, this attempts to find the actual overlapping area
            //this function doesnt work totally correctly yet. still double counts certain area
            foreach (Patch p in patches) 
            {
                if (DoOverlap(newPatch, p)) 
                {
                    int overlapWidth = Math.Min((Math.Abs(newPatch.brX - p.tlX) + 1), (Math.Abs(p.brX - newPatch.tlX) + 1));
                    int overlapHeight = Math.Min((Math.Abs(newPatch.tlY - p.brY) + 1), (Math.Abs(p.tlY - newPatch.brY) + 1));
                    int patchArea = (patchWidth * patchHeight) - (overlapWidth * overlapHeight);
                    return sqInCount + patchArea; 
                }
            }

            patches.Add(newPatch);
            return sqInCount + (patchHeight * patchWidth);
        }
    }
}
