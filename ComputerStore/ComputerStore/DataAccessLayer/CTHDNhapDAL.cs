using System;
using System.Collections;
using System.Text;
using System.IO;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.DataAccessLayer.Interface;

namespace ComputerStore.DataAccessLayer
{
    class CTHDNhapDAL : ICTHDNhapDAL
    {
        private string txtfile = "Data/CTHDNhap.txt";
        public List<CTHDNhap> GetData()
        {
            List<CTHDNhap> list = new List<CTHDNhap>();
            StreamReader sr = File.OpenText(txtfile);
            string s = sr.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = ComputerStore.Utility.CongCu.CatXau(s);
                    string[] a = s.Split('\t');
                    list.Add(new CTHDNhap(int.Parse(a[0]), int.Parse(a[1]), int.Parse(a[2]), int.Parse(a[3]), double.Parse(a[4]), double.Parse(a[5])));
                }
                s = sr.ReadLine();
            }
            sr.Close();
            return list;
        }
        public int maCTHDN
        {
            get
            {
                StreamReader sr = File.OpenText(txtfile);
                string s = sr.ReadLine();
                string tmp = "";
                while (s != null)
                {
                    if (s != "")
                        tmp = s;
                    s = sr.ReadLine();
                }
                sr.Close();
                if (tmp == "")
                    return 0;
                else
                {
                    tmp = ComputerStore.Utility.CongCu.ChuanHoaXau(tmp);
                    string[] a = tmp.Split('\t');
                    return int.Parse(a[0]);
                }
            }
        }
        public void Insert(CTHDNhap cthdn)
        {
            int macthdn = maCTHDN + 1;
            StreamWriter sw = File.AppendText(txtfile);
            sw.WriteLine();
            sw.Write(macthdn + "\t" + cthdn.maHDN + "\t" + cthdn.maMT + "\t" + cthdn.soLuong + "\t" + cthdn.donGia + "\t" + cthdn.thanhTien);
            sw.Close();
        }
        public void Update(List<CTHDNhap> list)
        {
            StreamWriter sw = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                sw.WriteLine(list[i].maCTHDN + "\t" + list[i].maHDN + "\t" + list[i].maMT + "\t" + list[i].soLuong + "\t" + list[i].donGia + "\t" + list[i].thanhTien);
            sw.Close();
        }
    }
}
