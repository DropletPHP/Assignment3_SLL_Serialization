using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
    [Serializable, KnownType(typeof(SLL))]
    public class SLL : ILinkedListADT
    {
        private Node head;
        private int count;

        public SLL()
        {
            head = null;
            count = 0;
        }
        public void Add(User value, int index)
        {
            if (index < 0 || index >= this.count) throw new IndexOutOfRangeException();

            Node newNode = new Node(value, null);

            if (head == null) throw new InvalidOperationException();
            else if (index == 0)
            {
                newNode.SetNext(head.GetNext());
                head = newNode;
            }
            else
            {
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.GetNext();
                    if (current == null)
                    {
                        throw new ArgumentOutOfRangeException("index is way off!");
                    }
                }
                newNode.SetNext(current.GetNext());
                current.SetNext(newNode);
            }
            count++;
        }

        public void AddFirst(User value)
        {
            Node newNode = new Node(value, head);
            head = newNode;
            count++;
        }

        public void AddLast(User value)
        {
            Node newNode = new Node(value, null);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.GetNext() != null)
                {
                    current = current.GetNext();
                }
                current.SetNext(newNode);
            }
            count++;
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }

        public bool Contains(User value)
        {
            Node current = head;
            while (current != null)
            {
                if (current.GetValue().Equals(value)) return true;
                current = current.GetNext();
            }
            return false;
        }
            public User GetValue(int index)
        {
            if (index < 0 || index >= count) throw new IndexOutOfRangeException();
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.GetNext();
            }
            return current.GetValue();
        }

        public int IndexOf(User value)
        {
            Node current = head;
            int index = 0;
            while (current != null)
            {
                if (current.GetValue().Equals(value)) return index;
                current = current.GetNext();
                index++;
            }
            return -1;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= count) throw new IndexOutOfRangeException();
            if (index == 0)
            {
                head = head.GetNext();
            }
            else
            {
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.GetNext();
                }
                current.SetNext(current.GetNext().GetNext());
            }
            count--;
        }

        public void RemoveFirst()
        {
            if (head == null) throw new InvalidOperationException();
            head = head.GetNext();
            count--;
        }

        public void RemoveLast()
        {
            if (head == null) throw new InvalidOperationException();
            if (head.GetNext() == null)
            {
                head = null;
            }
            else
            {
                Node current = head;
                while (current.GetNext().GetNext() != null)
                {
                    current = current.GetNext();
                }
                current.SetNext(null);
            }
            count--;
        }

        public void Replace(User value, int index)
        {
            if (index < 0 || index >= count) throw new IndexOutOfRangeException();

            Node newNode = new Node(value, null);

            if (head == null) throw new InvalidOperationException();
            else if (index == 0)
            {
                newNode.SetNext(head.GetNext());
                head = newNode;
            }
            else
            {
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.GetNext();
                    if (current == null)
                    {
                        throw new ArgumentOutOfRangeException("index is out of range");
                    }
                }
                newNode.SetNext(current.GetNext());
                current.SetNext(newNode);
            }

        }

        public int Count()
        {
            return count;
        }

        /* Optional method to test: Insert a new User object after a specific existing User object
        in the SLL.*/
        public void InsertAfter(User existingUser, User newUser)
        {
            if (head == null) throw new InvalidOperationException("Doble check it dude! The list is empty.");

            Node newNode = new Node(newUser, null);
            Node current = head;

            while (current != null)
            {
                if (current.GetValue().Equals(existingUser))
                {
                    newNode.SetNext(current.GetNext());
                    current.SetNext(newNode);
                    count++;
                    return;
                }
                current = current.GetNext();
            }
            throw new ArgumentException("The specified User is not found in the list.");
        }

    }
}
