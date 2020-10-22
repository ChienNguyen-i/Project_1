using System;
using System.Collections;
using System.Text;
using System.IO;
using ComputerStore.Utility;
using ComputerStore.Entities;

namespace ComputerStore.DataAccessLayer
{
    class NCC_DAL
    {
        DataAccessHelper dah = new DataAccessHelper("Data/NCC.txt");
        public string toString(NCC n)
        {
            return n.maNCC + "\t" + n.tenNCC + "\t" + n.diaChi + "\t" + n.soDT;
        }
        public NCC tostring(string s)
        {
            s = CongCu.CatXau(s);
            string[] tmp = s.Split('\t');
            NCC n = new NCC(int.Parse(tmp[0]), tmp[1], tmp[2], tmp[3]);
            return n;
        }
        public void Write(string filename, NCC n)
        {
            FileStream f = new FileStream(filename, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(f);
            sw.WriteLine(toString(n));
            sw.Close();
            f.Close();
        }
        public NCC Read(string filename)
        {
            FileStream f = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(f);
            string kq = sr.ReadLine();
            return tostring(kq);
        }
        public void WriteList(string filename, List<NCC> n)
        {
            FileStream f = new FileStream(filename, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(f);
            Node<NCC> tg = n.Head;
            while (tg != null)
            {
                sw.WriteLine(toString(tg.Info));
                tg = tg.Link;
            }
            sw.Close();
            f.Close();
        }
        public List<NCC> ReadList(string filename)
        {
            FileStream f = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(f);
            List<NCC> list = new List<NCC>();
            string s = sr.ReadLine();
            while (s != null)
            {
                if (s != "")
                    list.AddTail(tostring(s));
                s = sr.ReadLine();
            }
            sr.Close();
            f.Close();
            return list;
        }
    }
}
