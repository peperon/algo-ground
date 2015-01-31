using System.Collections.Generic;

namespace CSharpAlgoGroundWorking
{
    internal class InsertionSort
    {
        public static void Sort(List<int> keys)
        {
            for (int j = 1; j < keys.Count; j++)
            {
                int key = keys[j];
                int i = j - 1;
                while (i >= 0 && keys[i] > key)
                {
                    keys[i + 1] = keys[i];
                    i--;
                }
                keys[i + 1] = key;
            }
        }
    }
}
