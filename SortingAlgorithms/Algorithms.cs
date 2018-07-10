using System;

namespace SortingAlgorithms
{
    /// <summary>
    /// Class which provides merge sort and quick sort algorithms
    /// </summary>
    public static class Algorithms
    {
        #region API

        /// <summary>
        /// Merge Sorting of section of the <paramref name="array" />
        /// </summary>
        /// <param name="array">The array for sorting</param>
        /// <exception cref="ArgumentException">array</exception>
        /// <exception cref="ArgumentNullException">array</exception>
        public static void MergeSort(int[] array)
        {
            if (array.Length == 1)
            {
                return;
            }

            if (array.Length == 0)
            {
                throw new ArgumentException(nameof(array));
            }

            int start = 0, end = array.Length - 1;
            MergeSort(array, start, end);
        }

        /// <summary>
        /// Merge Sorting of section of the array
        /// </summary>
        /// <param name="array">The array for sorting</param>
        /// <param name="start">The start position of section</param>
        /// <param name="end">The end position of section</param>
        /// <exception cref="ArgumentException">End position sould be bigger than start position</exception>
        public static void MergeSort(int[] array, int start, int end)
        {
            if (start > end)
            {
                throw new ArgumentException("End position sould be bigger than start position");
            }

            Insert(array, Divide(array, start, end), start, end);
        }


        /// <summary>
        /// Quick Sorting the array
        /// </summary>
        /// <param name="array">The array for sorting</param>
        public static void QuickSort(int[] array)
        {
            int start = 0, end = array.Length - 1;
            QuickSort(array, start, end, true);
        }

        /// <summary>
        /// Quick Sorting the part of the array
        /// </summary>
        /// <param name="array">The array for sorting</param>
        /// <param name="start">The start position</param>
        /// <param name="end">The end position</param>
        /// <param name="callFromOverrideMethod">Is true, when function is called from override method or recursive
        /// and doesn't need validation of entered start and end positions.</param>
        /// <exception cref="ArgumentException"> array or End position sould be bigger than start position </exception>
        public static void QuickSort(int[] array, int start, int end, bool callFromOverrideMethod = false)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0)
            {
                throw new ArgumentException(nameof(array));
            }

            if (!callFromOverrideMethod)
            {
                if (start > end)
                {
                    throw new ArgumentException("End position sould be bigger than start position");
                }

            }

            if (start >= end)
            {
                return;
            }

            int pivot = Partition(array, start, end);
            QuickSort(array, start, pivot - 1, true);
            QuickSort(array, pivot + 1, end, true);
        }
        #endregion

        #region Private methods for MergeSort

        /// <summary>
        /// Recursive dividing into 2 arrays
        /// </summary>
        /// <param name="array">
        /// Dividing array
        /// </param>
        /// <param name="start">
        /// The start position of sorting
        /// </param>
        /// <param name="end">
        /// The end position of sorting
        /// </param>
        /// <returns>
        /// The part of array
        /// </returns>
        private static int[] Divide(int[] array, int start, int end)
        {
            if (end + 1 - start == 1 || end + 1 - start == 0)
            {
                return array;
            }

            int middle = start + (end - start) / 2;
            int[] array1 = new int[] { };
            Array.Resize(ref array1, middle - start + 1);
            int[] array2 = new int[] { };
            Array.Resize(ref array2, end - middle);
            int i1 = 0, i2 = 0;
            for (int i = start; i <= end; i++)
            {
                if (i <= middle)
                {                    
                    array1[i1++] = array[i];
                }
                else
                {
                    array2[i2++] = array[i];
                }
            }

            return Merge(Divide(array1, 0, array1.Length - 1), Divide(array2, 0, array2.Length - 1));
        }

        /// <summary>
        /// Merging 2 arrays
        /// </summary>
        /// <param name="array1">
        /// The first array </param>
        /// <param name="array2">
        /// The second array
        /// </param>
        /// <returns>
        /// Merged array
        /// </returns>
        private static int[] Merge(int[] array1, int[] array2)
        {
            int t1 = 0, t2 = 0;
            int[] mergedArray = new int[array1.Length + array2.Length];
            for (int i = 0; i < array1.Length + array2.Length; i++)
            {
                if (t1 < array1.Length && t2 < array2.Length)
                {
                    if (array1[t1] < array2[t2])
                    {
                        mergedArray[i] = array1[t1++];
                    }
                    else
                    {
                        mergedArray[i] = array2[t2++];
                    }
                }
                else
                {
                    if (t1 < array1.Length)
                    {
                        mergedArray[i] = array1[t1++];
                    }

                    if (t2 < array2.Length)
                    {
                        mergedArray[i] = array2[t2++];
                    }
                }
            }

            return mergedArray;
        }

        /// <summary>
        /// Copies values from source array to destination array
        /// </summary>
        /// <param name="array1">
        /// destination
        /// </param>
        /// <param name="array2">
        /// source
        /// </param>
        private static void Insert(int[] array1, int[] array2, int start, int end)
        {
            if (start != end)
            {
                for (int i = start, k = 0; i <= end; i++, k++)
                {
                    array1[i] = array2[k];
                }
            }
        }
        #endregion

        #region Private methods for QuickSort
        /// <summary>
        /// Finding the pivot for QuickSort
        /// </summary>
        /// <param name="array">
        /// Array
        /// </param>
        /// <param name="start">
        /// The start position
        /// </param>
        /// <param name="end">
        /// The end position
        /// </param>
        /// <returns>
        /// The pivot
        /// </returns>
        private static int Partition(int[] array, int start, int end)
        {
            int pivot = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i] < array[end])
                {
                    Swap(ref array[i], ref array[pivot]);
                    ++pivot;
                }
            }

            Swap(ref array[end], ref array[pivot]);
            return pivot;
        }

        /// <summary>
        /// Swap two elements of the array
        /// </summary>
        /// <param name="el1">
        /// The first element 
        /// </param>
        /// <param name="el2">
        /// The second element 
        /// </param>
        private static void Swap(ref int el1, ref int el2)
        {
            int temp = el1;
            el1 = el2;
            el2 = temp;
        }


        #endregion
    }
}
