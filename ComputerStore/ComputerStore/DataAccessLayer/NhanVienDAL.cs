using System;
using System.Collections;
using System.Text;
using System.IO;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.DataAccessLayer.Interface;
using System.Text.RegularExpressions;

namespace ComputerStore.DataAccessLayer
{
    class NhanVienDAL : INhanVienDAL
    {
        private string txtfile = "Data/NhanVien.txt";
        public List<NhanVien> GetData()
        {
            List<NhanVien> list = new List<NhanVien>();
            StreamReader sr = File.OpenText(txtfile);
            string s = sr.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = CongCu.CatXau(s);
                    string[] a = s.Split('\t');
                    list.Add(new NhanVien(a[0], a[1], a[2], a[3], a[4], a[5], a[6]));
                }
                s = sr.ReadLine();
            }
            sr.Close();
            return list;
        }
        public string maNV
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
                    return "NV0";
                else
                {
                    string[] a = tmp.Split('\t');
                    return a[0];
                }
            }
        }
        public void Insert(NhanVien nv)
        {
            int manv = CongCu.TachSo(maNV) + 1;
            StreamWriter sw = File.AppendText(txtfile);
            sw.WriteLine();
            sw.Write("NV" + manv + "\t" + nv.tenNV + "\t"+ nv.ngaySinh + "\t" + nv.gioiTinh + "\t" + nv.diaChi + "\t" + nv.soDT + "\t" + nv.loaiNV);
            sw.Close();
        }        
        public void Update(List<NhanVien> list)
        {
            StreamWriter sw = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                sw.WriteLine(list[i].maNV + "\t" + list[i].tenNV + "\t" + list[i].ngaySinh + "\t" + list[i].gioiTinh + "\t" + list[i].diaChi + "\t" + list[i].soDT + "\t" + list[i].loaiNV);
            sw.Close();
        }
    }
}
