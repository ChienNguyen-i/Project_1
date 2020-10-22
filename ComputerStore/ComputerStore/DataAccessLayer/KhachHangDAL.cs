using System;
using System.Collections;
using System.Text;
using System.IO;
using ComputerStore.Utility;
using ComputerStore.Entities;

namespace ComputerStore.DataAccessLayer
{
    class KhachHangDAL
    {
        DataAccessHelper dah = new DataAccessHelper("Data/KhachHang.txt");
        public string toString(KhachHang kh)
        {
            return kh.maKH + "\t" + kh.tenKH + "\t" + kh.gioiTinh + "\t" + kh.diaChi + "\t" + kh.soDT;
        }
        public KhachHang tostring(string s)
        {
            s = CongCu.CatXau(s);
            string[] tmp = s.Split('\t');
            KhachHang kh = new KhachHang(int.Parse(tmp[0]), tmp[1], tmp[2], tmp[3], tmp[4]);
            return kh;
        }
        public void Write(string filename, KhachHang kh)
        {
            FileStream f = new FileStream(filename, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(f);
            sw.WriteLine(toString(kh));
            sw.Close();
            f.Close();
        }
        public KhachHang Read(string filename)
        {
            FileStream f = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(f);
            string kq = sr.ReadLine();
            return tostring(kq);
        }
        public void WriteList(string filename, List<KhachHang> kh)
        {
            FileStream f = new FileStream(filename, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(f);
            Node<KhachHang> tg = kh.Head;
            while (tg != null)
            {
                sw.WriteLine(toString(tg.Info));
                tg = tg.Link;
            }
            sw.Close();
            f.Close();
        }
        public List<KhachHang> ReadList(string filename)
        {
            FileStream f = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(f);
            List<KhachHang> list = new List<KhachHang>();
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
