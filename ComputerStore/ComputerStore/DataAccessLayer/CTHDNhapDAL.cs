using System;
using System.Collections.Generic;
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
                    s = CongCu.CatXau(s);
                    string[] a = s.Split('\t');
                    list.Add(new CTHDNhap(a[0], a[1], int.Parse(a[2]), double.Parse(a[3]), double.Parse(a[4])));
                }
                s = sr.ReadLine();
            }
            sr.Close();
            return list;
        }
        public void Insert(CTHDNhap cthdn)
        {
            StreamWriter sw = File.AppendText(txtfile);
            sw.WriteLine(cthdn.maHDN + "\t" + cthdn.maMT + "\t" + cthdn.soLuong + "\t" + cthdn.donGia + "\t" + cthdn.thanhTien);
            sw.Close();
        }
        public void Delete(string mahdn)
        {
            List<CTHDNhap> list = GetData();
            StreamWriter sw = File.CreateText(txtfile);
            foreach (CTHDNhap cthdn in list)
                if (cthdn.maHDN != mahdn)
                    sw.WriteLine(cthdn.maHDN + "\t" + cthdn.maMT + "\t" + cthdn.soLuong + "\t" + cthdn.donGia + "\t" + cthdn.thanhTien);
            sw.Close();
        }
    }
}