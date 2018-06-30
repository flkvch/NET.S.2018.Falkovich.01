using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingAlgorithms.Tests
{
    [TestClass]
    public class AlgorithmsTests
    {
        [TestMethod]
        public void MergeSort_ArrayWithOneElement_ArrayWithOneElement()
        {
            int[] expected = { 3 };
            Algorithms.MergeSort(expected);
            CollectionAssert.AreEqual(expected, expected);
        }

        [TestMethod]
        public void MergeSort_EmptyArray_EmptyArray()
        {
            int[] expected = { };
            Algorithms.MergeSort(expected);
            CollectionAssert.AreEqual(expected, expected);
        }

        [TestMethod]
        public void MergeSort_SortedArray_UnchangedArray()
        {
            int[] expected = { 13, 16, 20, 28, 55, 81, 85, 90 };
            Algorithms.MergeSort(expected);
            CollectionAssert.AreEqual(expected, expected);
        }

        [TestMethod]
        public void MergeSort_ArrayWithRandomElements_SortedArray()
        {
            int[] actual = { 20, 55, 81, 16, 28, 13, 85, 90 };
            int[] expected = { 13, 16, 20, 28, 55, 81, 85, 90 };
            Algorithms.MergeSort(actual);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MergeSort_ReverseSortedArray_SortedArray()
        {
            int[] actual = { 90, 85, 81, 55, 28, 20, 16, 13 };
            int[] expected = { 13, 16, 20, 28, 55, 81, 85, 90 };
            Algorithms.MergeSort(actual);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MergeSort_SameValuesArray_SortedArray()
        {
            int[] actual = { 13, 13, 13, 13, 13, 13, 13 };
            int[] expected = { 13, 13, 13, 13, 13, 13, 13 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MergeSort_BigValuesRandomArray_SortedArray()
        {
            int length = int.MaxValue / 100000;
            int[] actual = new int[length];
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                actual[i] = rnd.Next(-length / 2, length / 2);
            }

            Algorithms.MergeSort(actual);

            bool check = true;
            for (int i = 0; i < length - 1; i++)
            {
                if (actual[i] > actual[i + 1])
                {
                    check = false;
                    break;
                }
            }

            Assert.IsTrue(check);
        }

        [TestMethod]
        public void MergeSort_PartOfArray_SortedPartOfArray()
        {
            int[] actual = { 20, 55, 81, 16, 28, 13, 85, 90 };
            Algorithms.MergeSort(actual, 2, 5);
            int[] expected = { 20, 55, 13, 16, 28, 81, 85, 90 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void QuickSort_Woutendposition_ArgumentException()
        {
            int[] actual = { 58, 90, 15, 18, 3, 70, 80 };
            Algorithms.QuickSort(actual, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void QuickSort_StartBiggerThanEnd_ArgumentException()
        {
            int[] actual = { 58, 90, 15, 18, 3, 70, 80 };
            Algorithms.QuickSort(actual, 5, 1);
        }

        [TestMethod]
        public void QuickSortEmptyArray_EmptyArray()
        {
            int[] expected = { };
            Algorithms.QuickSort(expected);
            CollectionAssert.AreEqual(expected, expected);
        }

        [TestMethod]
        public void QuickSort_OneElementArray_OneElementArray()
        {
            int[] actual = { 13 };
            int[] expected = { 13 };
            Algorithms.QuickSort(actual);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuickSort_SortedArray_UnchangedArray()
        {
            int[] actual = { 13, 16, 20, 28, 55, 81, 85, 90 };
            int[] expected = { 13, 16, 20, 28, 55, 81, 85, 90 };
            Algorithms.QuickSort(actual);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuickSort_ArrayWithRandomElements_SortedArray()
        {
            int[] actual = { 20, 55, 81, 16, 28, 13, 85, 90 };
            int[] expected = { 13, 16, 20, 28, 55, 81, 85, 90 };
            Algorithms.QuickSort(actual);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuickSort_ReverseSortedArray_SortedArray()
        {
            int[] actual = { 90, 85, 81, 55, 28, 20, 16, 13 };
            int[] expected = { 13, 16, 20, 28, 55, 81, 85, 90 };
            Algorithms.QuickSort(actual);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuickSortSameValuesArray_SortedArray()
        {
            int[] actual = { 13, 13, 13, 13, 13, 13, 13 };
            int[] expected = { 13, 13, 13, 13, 13, 13, 13 };
            Algorithms.QuickSort(actual);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuickSort_BigValuesRandomArray_SortedArray()
        {
            int length = int.MaxValue / 10000;
            int[] actual = new int[length];
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                actual[i] = rnd.Next(-length / 2, length / 2);
            }

            Algorithms.QuickSort(actual);

            bool check = true;
            for (int i = 0; i < length - 1; i++)
            {
                if (actual[i] > actual[i + 1])
                {
                    check = false;
                    break;
                }
            }

            Assert.IsTrue(check);
        }

        [TestMethod]
        public void QuickSort_PartOfArray_SortedPartOfArray()
        {
            int[] actual = { 20, 55, 81, 16, 28, 13, 85, 90 };
            Algorithms.QuickSort(actual, 2, 5);
            int[] expected = { 20, 55, 13, 16, 28, 81, 85, 90 };
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
