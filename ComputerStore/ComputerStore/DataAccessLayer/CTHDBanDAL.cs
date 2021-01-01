using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.DataAccessLayer.Interface;

namespace ComputerStore.DataAccessLayer
{
    class CTHDBanDAL : ICTHDBanDAL
    {
        private string txtfile = "Data/CTHDBan.txt";
        public List<CTHDBan> GetData()
        {
            List<CTHDBan> list = new List<CTHDBan>();
            StreamReader sr = File.OpenText(txtfile);
            string s = sr.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = CongCu.CatXau(s);
                    string[] a = s.Split('\t');
                    list.Add(new CTHDBan(a[0], a[1], int.Parse(a[2]), double.Parse(a[3]), double.Parse(a[4])));
                }
                s = sr.ReadLine();
            }
            sr.Close();
            return list;
        }
        public void Insert(CTHDBan cthdb)
        {
            StreamWriter sw = File.AppendText(txtfile);
            sw.WriteLine(cthdb.maHDB + "\t" + cthdb.maMT + "\t" + cthdb.soLuong + "\t" + cthdb.donGia + "\t" + cthdb.thanhTien);
            sw.Close();
        }
        public void Delete(string mahdb)
        {
            List<CTHDBan> list = GetData();
            StreamWriter sw = File.CreateText(txtfile);
            foreach (CTHDBan cthdb in list)
                if (cthdb.maHDB != mahdb)
                    sw.WriteLine(cthdb.maHDB + "\t" + cthdb.maMT + "\t" + cthdb.soLuong + "\t" + cthdb.donGia + "\t" + cthdb.thanhTien);
            sw.Close();
        }
    }
}
