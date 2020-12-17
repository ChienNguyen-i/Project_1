using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.DataAccessLayer.Interface;

namespace ComputerStore.DataAccessLayer
{
    class HDNhapDAL : IHDNhapDAL
    {
        private string txtfile = "Data/HDNhap.txt";
        public List<HDNhap> GetData()
        {
            List<HDNhap> list = new List<HDNhap>();
            StreamReader sr = File.OpenText(txtfile);
            string s = sr.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = CongCu.CatXau(s);
                    string[] a = s.Split('\t');
                    list.Add(new HDNhap(a[0], a[1], a[2], a[3], a[4], int.Parse(a[5]), double.Parse(a[6]), double.Parse(a[7])));
                }
                s = sr.ReadLine();
            }
            sr.Close();
            return list;
        }
        public string maHDN
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
                    return "HDN0";
                else
                {
                    string[] a = tmp.Split('\t');
                    return a[0];
                }
            }
        }
        public void Insert(HDNhap hdn)
        {
            int mahdn = CongCu.TachSo(maHDN) + 1;
            StreamWriter sw = File.AppendText(txtfile);
            sw.WriteLine();
            sw.Write("HDN" + mahdn + "\t" + hdn.maNV + "\t" + hdn.maNCC + "\t" + hdn.maMT + "\t" + hdn.ngayNhap + "\t" + hdn.soLuong + "\t" + hdn.donGia + "\t" + hdn.tongTien);
            sw.Close();
        }
        public void Update(HDNhap hdn)
        {
            List<HDNhap> list = GetData();
            for (int i = 0; i < list.Count; ++i)
                if (list[i].maHDN == hdn.maHDN)
                {
                    list[i] = hdn;
                    break;
                }
            StreamWriter sw = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                sw.WriteLine(list[i].maHDN + "\t" + list[i].maNV + "\t" + list[i].maNCC + "\t" + list[i].maMT + "\t" + list[i].ngayNhap + "\t" + list[i].soLuong + "\t" + list[i].donGia + "\t" + list[i].tongTien);
            sw.Close();
        }
        public void Delete(string mahdn)
        {
            List<HDNhap> list = GetData();
            StreamWriter sw = File.CreateText(txtfile);
            foreach (HDNhap hdn in list)
                if (hdn.maHDN != mahdn)
                    sw.WriteLine(hdn.maHDN + "\t" + hdn.maNV + "\t" + hdn.maNCC + "\t" + hdn.maMT + "\t" + hdn.ngayNhap + "\t" + hdn.soLuong + "\t" + hdn.donGia + "\t" + hdn.tongTien);
            sw.Close();
        }
    }
}
