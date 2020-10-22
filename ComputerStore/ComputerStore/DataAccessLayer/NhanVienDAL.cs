using System;
using System.Collections;
using System.Text;
using System.IO;
using ComputerStore.Utility;
using ComputerStore.Entities;

namespace ComputerStore.DataAccessLayer
{
    class NhanVienDAL
    {
        DataAccessHelper dah = new DataAccessHelper("Data/NhanVien.txt");
        public string toString(NhanVien nv)
        {
            return nv.maNV + "\t" + nv.tenNV + "\t" + nv.gioiTinh + "\t" + nv.diaChi + "\t" + nv.soDT + "\t" + nv.loaiNV;
        }
        public NhanVien tostring(string s)
        {
            s = CongCu.CatXau(s);
            string[] tmp = s.Split('\t');
            NhanVien nv = new NhanVien(int.Parse(tmp[0]), tmp[1], tmp[2], tmp[3], tmp[4], tmp[5]);
            return nv;
        }
        public void Write(string filename, NhanVien nv)
        {
            FileStream f = new FileStream(filename, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(f);
            sw.WriteLine(toString(nv));
            sw.Close();
            f.Close();
        }
        public NhanVien Read(string filename)
        {
            FileStream f = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(f);
            string kq = sr.ReadLine();
            return tostring(kq);
        }
        public void WriteList(string filename, List<NhanVien> nv)
        {
            FileStream f = new FileStream(filename, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(f);
            Node<NhanVien> tg = nv.Head;
            while (tg != null)
            {
                sw.WriteLine(toString(tg.Info));
                tg = tg.Link;
            }
            sw.Close();
            f.Close();
        }
        public List<NhanVien> ReadList(string filename)
        {
            FileStream f = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(f);
            List<NhanVien> list = new List<NhanVien>();
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
