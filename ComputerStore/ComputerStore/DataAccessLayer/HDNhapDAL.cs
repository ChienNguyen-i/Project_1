using System;
using System.Collections;
using System.Text;
using System.IO;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.DataAccessLayer.Interface;

namespace ComputerStore.DataAccessLayer
{
    class HDNhapDAL : IHDNhapDAL
    {
        private string txtfile = @"D:\GITHUB\Project_1\ComputerStore\ComputerStore\bin\Debug\Data\HDNhap.txt";
        public List<HDNhap> GetData()
        {
            List<HDNhap> list = new List<HDNhap>();
            StreamReader sr = File.OpenText(txtfile);
            string s = sr.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = ComputerStore.Utility.CongCu.CatXau(s);
                    string[] a = s.Split('\t');
                    list.Add(new HDNhap(int.Parse(a[0]), int.Parse(a[1]), int.Parse(a[2]), DateTime.Parse(a[3]), double.Parse(a[4])));
                }
                s = sr.ReadLine();
            }
            sr.Close();
            return list;
        }
        public int maHDN
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
        public void Insert(HDNhap hdn)
        {
            int mahdn = maHDN + 1;
            StreamWriter sw = File.AppendText(txtfile);
            sw.WriteLine();
            sw.Write(mahdn + "\t" + hdn.maNV + "\t" + hdn.maNCC + "\t" + hdn.ngayNhap + "\t" + hdn.tongTien);
            sw.Close();
        }
        public void Update(List<HDNhap> list)
        {
            StreamWriter sw = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                sw.WriteLine(list[i].maHDN + "\t" + list[i].maNV + "\t" + list[i].maNCC + "\t" + list[i].ngayNhap + "\t" + list[i].tongTien);
            sw.Close();
        }
    }
}
