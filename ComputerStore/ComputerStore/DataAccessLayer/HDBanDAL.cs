using System;
using System.Collections;
using System.Text;
using System.IO;
using ComputerStore.Utility;
using ComputerStore.Entities;

namespace ComputerStore.DataAccessLayer
{
    class HDBanDAL
    {
        DataAccessHelper dah = new DataAccessHelper("Data/HDBan.txt");
        public string toString(HDBan hdb)
        {
            return hdb.maHDB + "\t" + hdb.maNV + "\t" + hdb.maKH + "\t" + hdb.ngayBan + "\t" + hdb.tongTien;
        }
        public HDBan tostring(string s)
        {
            s = CongCu.CatXau(s);
            string[] tmp = s.Split('\t');
            HDBan hdb = new HDBan(int.Parse(tmp[0]), tmp[1], tmp[2], DateTime.Parse(tmp[3]), double.Parse(tmp[4]));
            return hdb;
        }
        public void Write(string filename, HDBan hdb)
        {
            FileStream f = new FileStream(filename, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(f);
            sw.WriteLine(toString(hdb));
            sw.Close();
            f.Close();
        }
        public HDBan Read(string filename)
        {
            FileStream f = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(f);
            string kq = sr.ReadLine();
            return tostring(kq);
        }
        public void WriteList(string filename, List<HDBan> hdb)
        {
            FileStream f = new FileStream(filename, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(f);
            Node<HDBan> tg = hdb.Head;
            while (tg != null)
            {
                sw.WriteLine(toString(tg.Info));
                tg = tg.Link;
            }
            sw.Close();
            f.Close();
        }
        public List<HDBan> ReadList(string filename)
        {
            FileStream f = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(f);
            List<HDBan> list = new List<HDBan>();
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
