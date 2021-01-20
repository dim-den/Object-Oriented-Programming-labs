using System;

namespace OOPLab4
{
        static class StatisticOperation
        {
            public static int Sum(List<int> list)
            {
                int sum = 0;
                for (int i = 0; i < list.Size; i++)
                {
                    sum += list[i];
                }
                return sum;
            }

            public static int DifferenceMaxMin(List<int> list)
            {
                int max = list[0], min = list[0];
                for (int i = 1; i < list.Size; i++)
                {
                    if (list[i] > max) max = list[i];
                    if (list[i] < min) min = list[i];
                }
                return max - min;
            }

            public static int CountElements(List<int> list)
            {
                return list.Size;
            }

            public static int CountWords(this string str)
            {
                return str.Split(' ').Length;
            }

            public static int CountZeros(this List<int> list)
            {
                int count = 0;
                for (int i = 0; i < list.Size; i++)
                    if (list[i] == 0) count++;
                return count;
            }
        }
}
