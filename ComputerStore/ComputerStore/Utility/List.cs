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
        { }
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
        public T this[int i]
        {
            get
            {
                Node<T> tg = head;
                int d = 0;
                while (tg.Link != null && d != i)
                {
                    tg = tg.Link;
                    d++;
                }
                return tg.Info;
            }
        }
        public int Count
        {
            get
            {
                if (head == null)
                    return 0;
                Node<T> tg = head;
                int d = 0;
                while (tg.Link != null)
                {
                    tg = tg.Link;
                    d++;
                }
                return d + 1;
            }
        }
        public void Add(T x)
        {
            Node<T> tg = new Node<T>(x);
            if (head == null)
                head= tg;
            else
            {
                Node<T> p = head;
                while (p.Link != null)
                    p = p.Link;
                p.Link = tg;
            }
        }
        public void Add(T x, int i)
        {
            Node<T> tg = new Node<T>(x);
            if (Count == 0)
                head = tg;
            else if (i >= 0 && i <= Count - 1)
            {
                Node<T> p = head;
                int d = 0;
                while (p.Link != null && d != i)
                {
                    p = p.Link;
                    d++;
                }
                if (p == head)
                {
                    tg.Link = head;
                    head = tg; }
                else
                {
                    Node<T> vt = head;
                    Node<T> tvt = vt;
                    while (vt != p)
                    {
                        tvt = vt;
                        vt = vt.Link;
                    }
                    tg.Link = vt;
                    tvt.Link = tg;
                }
            }
        }
        public void RemoveAt(int i)
        {
            if (Count == 0)
                return;
            else if (i >= 0 && i <= Count - 1)
            {
                Node<T> p = head;
                int d = 0;
                while (p.Link != null && d != i)
                {
                    p = p.Link;
                    d++;
                }
                if (head.Link == null)
                    head = null;
                else if (p == head)                
                    head = head.Link;
                else if (p.Link == null)
                {
                    Node<T> tg = head;
                    while (tg.Link.Link != null)
                        tg = tg.Link;
                    tg.Link = null;
                }
                else
                {
                    Node<T> vt = head;
                    Node<T> tvt = vt;
                    while (vt != p)
                    {
                        tvt = vt;
                        vt = vt.Link;
                    }
                    tvt.Link = vt.Link;
                }
            }
        }
    }
}
