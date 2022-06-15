using CustomLinkedList;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class UnitTest
    {
        [Fact]
        public void TestAdd() 
        {
            CustomLinkedList<string> customList = new CustomLinkedList<string>() { "A", "B", "C"};

            customList.Add("D");

            Assert.Equal("ABCD", string.Join("", customList));
        }

        [Fact]
        public void TestAdd_nullData()
        {   
            CustomLinkedList<string> customList = new CustomLinkedList<string>();

            Assert.Throws<ArgumentNullException>(() => customList.Add(null));
        }

        [Fact]
        public void TestDeletion_True()
        {
            CustomLinkedList<string> list = new CustomLinkedList<string>() { "U", "S", "A" };

            list.Remove("S");

            Assert.Equal("UA", string.Join("", list));
        }

        [Fact]
        public void TestDeletion_False()
        {
            CustomLinkedList<string> customList = new CustomLinkedList<string>() { "U", "S", "A" };

            Assert.False(customList.Remove("R")) ;
        }

        [Fact]
        public void TestDeletion_nullData()
        {
            CustomLinkedList<string> customList = new CustomLinkedList<string>();

            Assert.Throws<ArgumentNullException>(() => customList.Remove(null));
        }

        [Fact]
        public void TestClear()
        {
            CustomLinkedList<string> list = new CustomLinkedList<string> { "U", "S", "A" };

            list.Clear();

            Assert.Empty(list);
        }

        [Fact]
        public void TestContains()
        {
            void test(CustomLinkedList<int> list, int element, bool result)
            {
                Assert.Equal(list.Contains(element), result);
            }
            test(new CustomLinkedList<int>() { 4, 5, 9 }, 4, true);
            test(new CustomLinkedList<int>() { 1, 5, 9 }, 2, false);
        }

        [Fact]
        public void TestContains_NullData()
        {
            CustomLinkedList<string> customList = new CustomLinkedList<string>() { "Glory", "to", "Ukraine" };

            Assert.Throws<ArgumentNullException>(() => customList.Contains(null));
        }

        [Fact]
        public void TestCopyTo()
        {
            CustomLinkedList<string> list = new CustomLinkedList<string>() { "C", "S", "S" };
            var array = new string[list.Count];

            list.CopyTo(array, list.Count - 1);

            Assert.Equal(string.Join("", list), string.Join("", array));
        }

        [Fact]
        public void Enumerator()
        {
            CustomLinkedList<int> customList = new CustomLinkedList<int>();

            customList.Add(1);
            customList.Add(2);
            customList.Add(3);
            customList.Add(4);

            foreach (var item in customList) Assert.True(customList.Contains(item));
        }
    }
}
