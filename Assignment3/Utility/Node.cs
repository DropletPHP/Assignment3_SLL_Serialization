using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
    [Serializable]
    public class Node
    {
        private User value;
        private Node next;

        public Node(User value, Node next)
        {
            this.value = value;
            this.next = next;
        }

        public User GetValue()
        {
            return this.value;
        }

        public Node GetNext()
        {
            return this.next;
        }

        public void SetValue(User value)
        {
            this.value = value;
        }

        public void SetNext(Node next)
        {
            this.next = next;
        }
    }

}
