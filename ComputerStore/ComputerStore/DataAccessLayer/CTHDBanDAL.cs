using System;
using System.Collections;
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
                    s = ComputerStore.Utility.CongCu.CatXau(s);
                    string[] a = s.Split('\t');
                    list.Add(new CTHDBan(int.Parse(a[0]), a[1], a[2], int.Parse(a[3]), double.Parse(a[4]), double.Parse(a[5])));
                }
                s = sr.ReadLine();
            }
            sr.Close();
            return list;
        }
        public int maCTHDB
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
        public void Insert(CTHDBan cthdb)
        {
            int macthdb = maCTHDB + 1;
            StreamWriter sw = File.AppendText(txtfile);
            sw.WriteLine();
            sw.Write(macthdb + "\t" + cthdb.maHDB + "\t" + cthdb.maMT + "\t" + cthdb.soLuong + "\t" + cthdb.donGia + "\t" + cthdb.thanhTien);
            sw.Close();
        }
        public void Update(List<CTHDBan> list)
        {
            StreamWriter sw = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                sw.WriteLine(list[i].maCTHDB + "\t" + list[i].maHDB + "\t" + list[i].maMT + "\t" + list[i].soLuong + "\t" + list[i].donGia + "\t" + list[i].thanhTien);
            sw.Close();
        }
    }
}
