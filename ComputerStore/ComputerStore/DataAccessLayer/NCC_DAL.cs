using System;
using System.Collections;
using System.Text;
using System.IO;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.DataAccessLayer.Interface;

namespace ComputerStore.DataAccessLayer
{
    class NCC_DAL : INCC_DAL
    {
        private string txtfile = @"D:\GITHUB\Project_1\ComputerStore\ComputerStore\Data\NCC.txt";
        public List<NCC> GetData()
        {
            List<NCC> list = new List<NCC>();
            StreamReader sr = File.OpenText(txtfile);
            string s = sr.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = ComputerStore.Utility.CongCu.CatXau(s);
                    string[] a = s.Split('\t');
                    list.Add(new NCC(int.Parse(a[0]), a[1], a[2], a[3]));
                }
                s = sr.ReadLine();
            }
            sr.Close();
            return list;
        }
        public int maNCC
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
        public void Insert(NCC ncc)
        {
            int mancc = maNCC + 1;
            StreamWriter sw = File.AppendText(txtfile);
            sw.WriteLine();
            sw.Write(mancc + "\t" + ncc.tenNCC + "\t" + ncc.diaChi + "\t" + ncc.soDT);
            sw.Close();
        }
        public void Update(List<NCC> list)
        {
            StreamWriter sw = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                sw.WriteLine(list[i].maNCC + "\t" + list[i].tenNCC + "\t" + list[i].diaChi + "\t" + list[i].soDT);
            sw.Close();
        }
    }
}
