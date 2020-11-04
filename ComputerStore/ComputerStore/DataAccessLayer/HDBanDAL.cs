using System;
using System.Collections;
using System.Text;
using System.IO;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.DataAccessLayer.Interface;

namespace ComputerStore.DataAccessLayer
{
    class HDBanDAL : IHDBanDAL
    {
        private string txtfile = @"D:\GITHUB\Project_1\ComputerStore\ComputerStore\Data\HDBan.txt";
        public List<HDBan> GetData()
        {
            List<HDBan> list = new List<HDBan>();
            StreamReader sr = File.OpenText(txtfile);
            string s = sr.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = ComputerStore.Utility.CongCu.CatXau(s);
                    string[] a = s.Split('\t');
                    list.Add(new HDBan(int.Parse(a[0]), int.Parse(a[1]), int.Parse(a[2]), int.Parse(a[3]), DateTime.Parse(a[4]), int.Parse(a[5]), double.Parse(a[6]), double.Parse(a[7])));
                }
                s = sr.ReadLine();
            }
            sr.Close();
            return list;
        }
        public int maHDB
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
        public void Insert(HDBan hdb)
        {
            int mahdb = maHDB + 1;
            StreamWriter sw = File.AppendText(txtfile);
            sw.WriteLine();
            sw.Write(mahdb + "\t" + hdb.maNV + "\t" + hdb.maKH + "\t" + hdb.maMT + "\t" + hdb.ngayBan + "\t" + hdb.soLuong + "\t" + hdb.donGia + "\t" + hdb.tongTien);
            sw.Close();
        }
        public void Update(List<HDBan> list)
        {
            StreamWriter sw = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                sw.WriteLine(list[i].maHDB + "\t" + list[i].maNV + "\t" + list[i].maKH + "\t"+ list[i].maMT + "\t" + list[i].ngayBan + "\t"+ list[i].soLuong + "\t" + list[i].donGia + "\t" + list[i].tongTien);
            sw.Close();
        }
    }
}
