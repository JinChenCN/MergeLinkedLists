using System;
using System.Linq;

namespace MergeLinkedLists
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please input the first list:");
                var list1 = ReadLinkedListFromConsole();

                Console.WriteLine("Please input the second list:");
                var list2 = ReadLinkedListFromConsole();

                var mergedList = Merge(list1.Head, list2.Head);

                if (mergedList != null)
                {
                    PrintAllNodes(mergedList);
                }
                else
                {
                    Console.WriteLine("The out put is empty.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("The input format was invalid.");
            }
            catch (Exception)
            {
                Console.WriteLine("An error happened when merging.");
            }

            Console.ReadKey();
        }

        private static LinkedList ReadLinkedListFromConsole()
        {
            var input = Console.ReadLine();

            var list = new LinkedList();

            if (string.IsNullOrEmpty(input))
            {
                return list;
            }

            foreach (var n in input.Split(' ').Select(int.Parse))
            {
                list.Add(new Node(n));
            }

            return list;
        }

        private static void PrintAllNodes(Node head)
        {
            var current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        public static Node Merge(Node head1, Node head2)
        {
            if (head1 == null)
            {
                return head2;
            }

            if (head2 == null)
            {
                return head1;
            }

            // Always adding nodes from the second list to the first one
            // If second node head data is smaller than first one then exchange it
            if (head1.Data > head2.Data)
            {
                var t = head1;
                head1 = head2;
                head2 = t;
            }

            var mergedLinkedList = new LinkedList {Head = head1};

            while (head1.Next != null && head2 != null)
            {
                if (head1.Next.Data < head2.Data)
                {
                    head1 = head1.Next;
                }
                else
                {
                    var n = head1.Next;
                    var t = head2.Next;
                    head1.Next = head2;
                    head2.Next = n;
                    head1 = head1.Next;
                    head2 = t;
                }
            }

            if (head1.Next == null) 
            {
                head1.Next = head2;
            }

            return mergedLinkedList.Head;
        }
    }
}
