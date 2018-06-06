using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MergeLinkedLists.Tests
{
    [TestClass]
    public class MergeTests
    {
        [TestMethod]
        public void Merge_two_non_empty_linked_lists_successfully()
        {
            // Arrange
            var list1 = new LinkedList();
            foreach (var n in new[] { 2, 5, 8, 14, 36 })
            {
                list1.Add(new Node(n));
            }

            var list2 = new LinkedList();
            foreach (var n in new[] { 1, 5, 10, 48 })
            {
                list2.Add(new Node(n));
            }

            var expectedOutput = new LinkedList();
            foreach (var n in new[] { 1, 2, 5, 5, 8, 10, 14, 36, 48 })
            {
                expectedOutput.Add(new Node(n));
            }

            // Act
            var actualOutput = Program.Merge(list1.Head, list2.Head);

            // Assert
            actualOutput.Should().BeEquivalentTo(expectedOutput.Head);
        }

        [TestMethod]
        public void Merge_two_empty_lists_should_return_null()
        {
            // Arrange
            var list1 = new LinkedList();
            var list2 = new LinkedList();

            // Act
            var actualOutput = Program.Merge(list1.Head, list2.Head);

            // Assert
            actualOutput.Should().Be(null);
        }
    }
}
