using System;
using System.Collections;
using System.Text;
using System.IO;
using ComputerStore.Utility;
using ComputerStore.Entities;

namespace ComputerStore.DataAccessLayer
{
    class HDNhapDAL
    {
        DataAccessHelper dah = new DataAccessHelper("Data/HDNhap.txt");
        public string toString(HDNhap hdn)
        {
            return hdn.maHDN + "\t" + hdn.maNV + "\t" + hdn.maNCC + "\t" + hdn.ngayNhap + "\t" + hdn.tongTien;
        }
        public HDNhap tostring(string s)
        {
            s = CongCu.CatXau(s);
            string[] tmp = s.Split('\t');
            HDNhap hdn = new HDNhap(int.Parse(tmp[0]), tmp[1], tmp[2], DateTime.Parse(tmp[3]), double.Parse(tmp[4]));
            return hdn;
        }
        public void Write(string filename, HDNhap hdn)
        {
            FileStream f = new FileStream(filename, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(f);
            sw.WriteLine(toString(hdn));
            sw.Close();
            f.Close();
        }
        public HDNhap Read(string filename)
        {
            FileStream f = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(f);
            string kq = sr.ReadLine();
            return tostring(kq);
        }
        public void WriteList(string filename, List<HDNhap> hdn)
        {
            FileStream f = new FileStream(filename, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(f);
            Node<HDNhap> tg = hdn.Head;
            while (tg != null)
            {
                sw.WriteLine(toString(tg.Info));
                tg = tg.Link;
            }
            sw.Close();
            f.Close();
        }
        public List<HDNhap> ReadList(string filename)
        {
            FileStream f = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(f);
            List<HDNhap> list = new List<HDNhap>();
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
