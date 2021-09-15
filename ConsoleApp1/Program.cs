using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Result
    {

        /*
         * Complete the 'countMax' function below.
         *
         * The function is expected to return a LONG_INTEGER.
         * The function accepts STRING_ARRAY upRight as parameter.
         */
        public static long countMax(List<string> upRight)
        {
            long maxRow = 0;
            long maxCol = 0;
            var processingInstructions = new List<ProcessingInstruction>();

            foreach (var instruction in upRight)
            {
                var rowColValues = instruction.Split(new[] { " " }, StringSplitOptions.None);
                var processingInstruction = new ProcessingInstruction { EndingRow = Convert.ToInt64(rowColValues[0]), EndingCol = Convert.ToInt64(rowColValues[1]) };
                processingInstructions.Add(processingInstruction);

                if (processingInstruction.EndingRow > maxRow)
                {
                    maxRow = processingInstruction.EndingRow;
                }

                if (processingInstruction.EndingCol > maxCol)
                {
                    maxCol = processingInstruction.EndingCol;
                }
            }

            long[,] grid = new long[maxCol, maxRow];
            long maxValue = ApplyInstructionsAndGetMaxValue(processingInstructions, grid);
            var maxValueCount = CountMaxValueOccurrences(maxCol, maxRow, grid, maxValue);

            return maxValueCount;
        }

        private static long CountMaxValueOccurrences(long maxCol, long maxRow, long[,] grid, long maxValue)
        {
            long maxValueCount = 0;

            for (long i = 0; i < maxCol; i++)
            {
                for (long j = 0; j < maxRow; j++)
                {
                    if (grid[i, j] == maxValue)
                    {
                        maxValueCount++;
                    }
                }
            }

            return maxValueCount;
        }

        private static long ApplyInstructionsAndGetMaxValue(List<ProcessingInstruction> processingInstructions, long[,] grid)
        {
            long maxValue = 0;

            foreach (var processingInstruction in processingInstructions)
            {
                for (long i = 0; i < processingInstruction.EndingCol; i++)
                {
                    for (long j = 0; j < processingInstruction.EndingRow; j++)
                    {
                        grid[i, j] = grid[i, j] + 1;

                        if (grid[i, j] > maxValue)
                        {
                            maxValue = grid[i, j];
                        }
                    }
                }
            }

            return maxValue;
        }

        class ProcessingInstruction
        {
            public long EndingRow { get; set; }
            public long EndingCol { get; set; }
        }
    }

    class Solution
    {
        public static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int upRightCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<string> upRight = new List<string>();

            for (int i = 0; i < upRightCount; i++)
            {
                string upRightItem = Console.ReadLine();
                upRight.Add(upRightItem);
            }

            long result = Result.countMax(upRight);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();

            List<string> upRight1 = new List<string> { "2 3", "3 7", "4 1" };
            long result1 = Result.countMax(upRight1);
            Console.WriteLine(result1);

            List<string> upRight2 = new List<string> { "1 4", "2 3", "4 1" };
            long result2 = Result.countMax(upRight2);
            Console.WriteLine(result2);

            Console.ReadLine();
        }
    }
}
