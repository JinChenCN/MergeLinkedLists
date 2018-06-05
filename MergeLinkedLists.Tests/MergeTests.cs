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
            list1.Add(new Node(2));
            list1.Add(new Node(5));
            list1.Add(new Node(8));
            list1.Add(new Node(14));
            list1.Add(new Node(36));

            var list2 = new LinkedList();
            list2.Add(new Node(1));
            list2.Add(new Node(5));
            list2.Add(new Node(10));
            list2.Add(new Node(48));

            var expectedOutput = new LinkedList();
            expectedOutput.Add(new Node(1));
            expectedOutput.Add(new Node(2));
            expectedOutput.Add(new Node(5));
            expectedOutput.Add(new Node(5));
            expectedOutput.Add(new Node(8));
            expectedOutput.Add(new Node(10));
            expectedOutput.Add(new Node(14));
            expectedOutput.Add(new Node(36));
            expectedOutput.Add(new Node(48));

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
