using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Utility
{
    public class Node<T>
    {
        private T info;
        private Node<T> link;

        public T Info
        {
            get
            {
                return info;
            }
            set
            {
                info = value;
            }
        }

        public Node<T> Link
        {
            get
            {
                return link;
            }
            set
            {
                link = value;
            }
        }
        public Node()
        {
        }
        public Node(T t)
        {
            info = t;
            link = null;
        }
    }
    public class List<T>
    {
        private Node<T> head;

        public Node<T> Head
        {
            get
            {
                return head;
            }
            set
            {
                head = value;
            }
        }
        public List()
        {
            head = null;
        }
        public void AddHead(T f)
        {
            Node<T> tg = new Node<T>(f);
            tg.Link = head;
            head = tg;
        }
        public void AddTail(T e)
        {
            Node<T> t = new Node<T>(e);
            if (head == null)
                head = t;
            else
            {
                Node<T> tg = head;
                while (tg.Link != null)
                {
                    tg = tg.Link;
                }
                tg.Link = t;
            }
        }
        public void Hien()
        {
            Node<T> tg = head;
            Console.WriteLine("Các phần tử của danh sách:");
            while (tg != null)
            {
                Console.WriteLine("\t" + tg.Info);
                tg = tg.Link;
            }
            Console.WriteLine();
        }
        public void RemoveTail()
        {
            if (head == null)
            {
                Console.WriteLine("Danh sách rỗng");
                return;
            }
            else if (head.Link == null)
            {
                head = null;
            }
            else
            {
                Console.WriteLine("Danh sách đã được xóa đi phần tử cuối:");
                Node<T> tg = head;
                Node<T> t = tg;
                while (tg.Link != null)
                {
                    t = tg;
                    tg = tg.Link;
                }
                t.Link = null;
            }
        }
        public void Xoa_q(Node<T> q)
        {
            Node<T> tg = head;
            Node<T> t = tg;
            while (tg.Link != null)
            {
                if (tg == q)
                    break;
                else
                {
                    t = tg;
                    tg = tg.Link;
                }
            }
            if (q == head)
                head = head.Link;
            else
            {
                if (q.Link == null)
                    t.Link = null;
                else
                    t.Link = q.Link;
            }
        }
    }
}
