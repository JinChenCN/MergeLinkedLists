namespace MergeLinkedLists
{
    public class LinkedList
    {
        private Node _current;
        public Node Head { get; set; }

        public void Add(Node n)
        {
            if (Head == null)
            {
                Head = n;
                _current = Head;
            }
            else
            {
                _current.Next = n;
                _current = _current.Next;
            }
        }
    }
}
