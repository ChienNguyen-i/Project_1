using System;
using System.Collections;
using System.Text;
using System.IO;
using ComputerStore.Utility;
using ComputerStore.Entities;
using System.Linq.Expressions;

namespace ComputerStore.DataAccessLayer
{
    class MayTinhDAL
    {
        DataAccessHelper dah = new DataAccessHelper("Data/MayTinh.txt");
        public string toString(MayTinh mt)
        {
            return mt.maMT + "\t" + mt.maLM + "\t" + mt.tenLM + "\t" + mt.maNCC + "\t" + mt.sLNhap + "\t" + mt.sLCon;
        }
        public MayTinh tostring(string s)
        {
            s = CongCu.CatXau(s);
            string[] tmp = s.Split('\t');
            MayTinh mt = new MayTinh(int.Parse(tmp[0]), tmp[1], tmp[2], tmp[3], int.Parse(tmp[4]), int.Parse(tmp[5]));
            return mt;
        }
        public void Write(string filename, MayTinh m)
        {
            FileStream f = new FileStream(filename, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(f);
            sw.WriteLine(toString(m));
            sw.Close();
            f.Close();
        }
        public MayTinh Read(string filename)
        {
            FileStream f = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(f);
            string kq = sr.ReadLine();
            return tostring(kq);
        }
        public void WriteList(string filename, List<MayTinh> mt)
        {
            FileStream f = new FileStream(filename, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(f);
            Node<MayTinh> tg = mt.Head;
            while (tg != null)
            {
                sw.WriteLine(toString(tg.Info));
                tg = tg.Link;
            }
            sw.Close();
            f.Close();
        }
        public List<MayTinh> ReadList(string filename)
        {
            FileStream f = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(f);
            List<MayTinh> list = new List<MayTinh>();
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
