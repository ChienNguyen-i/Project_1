using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.DataAccessLayer.Interface;

namespace ComputerStore.DataAccessLayer
{
    class HDBanDAL : IHDBanDAL
    {
        private string txtfile = "Data/HDBan.txt";
        public List<HDBan> GetData()
        {
            List<HDBan> list = new List<HDBan>();
            StreamReader sr = File.OpenText(txtfile);
            string s = sr.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = CongCu.CatXau(s);
                    string[] a = s.Split('\t');
                    list.Add(new HDBan(a[0], a[1], a[2], a[3], double.Parse(a[4])));
                }
                s = sr.ReadLine();
            }
            sr.Close();
            return list;
        }
        public string maHDB
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
                    return "HDB0";
                else
                {
                    string[] a = tmp.Split('\t');
                    return a[0];
                }
            }
        }
        public void Insert(HDBan hdb)
        {
            int mahdb = CongCu.TachSo(maHDB) + 1;
            StreamWriter sw = File.AppendText(txtfile);
            sw.WriteLine("HDB" + mahdb + "\t" + hdb.maNV + "\t" + hdb.maKH + "\t" + hdb.ngayBan + "\t" + hdb.tongTien);
            sw.Close();
        }
        public void Delete(string mahdb)
        {
            List<HDBan> list = GetData();
            StreamWriter sw = File.CreateText(txtfile);
            foreach (HDBan hdb in list)
                if (hdb.maHDB != mahdb)
                    sw.WriteLine(hdb.maHDB + "\t" + hdb.maNV + "\t" + hdb.maKH + "\t" + hdb.ngayBan + "\t" + hdb.tongTien);
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
                    StreamReader sr1 = new StreamReader("Data/CTHDBan.txt");
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
    }
}
