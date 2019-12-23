// Determine whether a doubly linked list is a palindrome. What if it’s singly linked?
// For example, 1 -> 4 -> 3 -> 4 -> 1 returns True while 1 -> 4 returns False

using NUnit.Framework;

namespace Common.Test
{
    public class Test104
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(nameof(Cases))]
        public void Problem104LinkList(string input, bool results)
        {
            //-- Arrange
            var expected = results;

            //-- Act
            var actual = Solution104.IsLinkedListAPalindrome(input);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        [TestCaseSource(nameof(Cases))]
        public void Problem104DoubleLinkList(string input, bool results)
        {
            //-- Arrange
            var expected = results;

            //-- Act
            var actual = Solution104.IsDoubleLinkListAPalindrome(input);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        static object[] Cases = {
            new object[] {  "14341",true   } ,
            new object[] {  "abccba",true   } ,
            new object[] {  "abcba",true    } ,
            new object[] {  "aa",true   } ,
            new object[] {  "a",true    } ,
            new object[] {  "",true  },
            new object[] {  "ab",false  } ,
            new object[] {  "abb",false } ,
            new object[] {  "abcdba",false   }
        };
    }
}
