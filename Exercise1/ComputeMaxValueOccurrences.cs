using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise1
{
    public static class ComputeMaxValueOccurrences
    {
        public static long CountMax(List<string> upRight)
        {
            long maxRow = 0;
            long maxCol = 0;
            long endingRow = 0;
            long endingCol = 0;

            long[,] processingInstructions = new long[upRight.Count, 2];

            for (int i = 0; i < upRight.Count; i++)
            {
                var rowColValues = upRight[i].Split(new[] { " " }, StringSplitOptions.None);
                endingRow = Convert.ToInt64(rowColValues[0]);
                endingCol = Convert.ToInt64(rowColValues[1]);
                processingInstructions[i, 0] = endingRow;
                processingInstructions[i, 1] = endingCol;

                if (endingRow > maxRow)
                {
                    maxRow = endingRow;
                }

                if (endingCol > maxCol)
                {
                    maxCol = endingCol;
                }
            }

            long[,] grid = new long[maxCol, maxRow];
            long maxValue = ApplyInstructionsAndGetMaxValue(processingInstructions, grid, upRight.Count);
            long maxValueCount = CountMaxValueOccurrences(maxCol, maxRow, grid, maxValue);

            return maxValueCount;
        }

        private static long ApplyInstructionsAndGetMaxValue(long[,] processingInstructions, long[,] grid, int numberOfInstructions)
        {
            long maxValue = 0;
            long endingRow = 0;
            long endingCol = 0;

            for (int x = 0; x < numberOfInstructions; x++)
            {
                endingRow = processingInstructions[x, 0];
                endingCol = processingInstructions[x, 1];

                for (long i = 0; i < endingCol; i++)
                {
                    for (long j = 0; j < endingRow; j++)
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
    }
}
