namespace ProblemSolving
{
    public class ListNode<T>
    {
        public T val;
        public ListNode<T> next;
        public ListNode()
        {

        }
        public ListNode(T val , ListNode<T> next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}