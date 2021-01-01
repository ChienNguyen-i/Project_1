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
                    list.Add(new HDNhap(a[0], a[1], a[2], a[3], double.Parse(a[4])));
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
            sw.WriteLine("HDN" + mahdn + "\t" + hdn.maNV + "\t" + hdn.maNCC + "\t" + hdn.ngayNhap + "\t" + hdn.tongTien);
            sw.Close();
        }
        public void Delete(string mahdn)
        {
            List<HDNhap> list = GetData();
            StreamWriter sw = File.CreateText(txtfile);
            foreach (HDNhap hdn in list)
                if (hdn.maHDN != mahdn)
                    sw.WriteLine(hdn.maHDN + "\t" + hdn.maNV + "\t" + hdn.maNCC + "\t" + hdn.ngayNhap + "\t" + hdn.tongTien);
                sw.Close();
        }
        public double TongTien(string mahd)
        {
            StreamReader sr = new StreamReader(txtfile);

            string s;
            double tongTien = 0;

            while ((s = sr.ReadLine()) != null)
            {
                String[] tmp = s.Split('\t');
                if (tmp[0] == mahd)
                {
                    StreamReader sr1 = new StreamReader("Data/CTHDNhap.txt");
                    string s1;
                    while ((s1 = sr1.ReadLine()) != null)
                    {
                        string[] tmp1 = s1.Split('\t');
                        if (tmp1[0] == tmp[0])
                        {
                            double tt = double.Parse(tmp1[4]);
                            tongTien += tt;
                        }
                    }
                    sr1.Close();
                }
            }
            sr.Close();
            return tongTien;
        }
        public string LayNCC(string mamt)
        {
            StreamReader sr = new StreamReader("Data/CTHDNhap.txt");

            string s;
            string ncc = "";

            while ((s = sr.ReadLine()) != null)
            {
                String[] tmp = s.Split('\t');
                if (tmp[1] == mamt)
                {
                    StreamReader sr1 = new StreamReader(txtfile);
                    string s1;
                    while ((s1 = sr1.ReadLine()) != null)
                    {
                        string[] tmp1 = s1.Split('\t');
                        if (tmp1[0] == tmp[0])
                        {
                            string cc = tmp1[2];
                            ncc = cc;
                        }
                    }
                    sr1.Close();
                }
            }
            sr.Close();
            return ncc;
        }
    }
}
