using ComputerStore.Entities;
using System;
using System.Collections;
using System.Text;
using ComputerStore.Utility;
using System.IO;
using ComputerStore.DataAccessLayer.Interface;

namespace ComputerStore.DataAccessLayer
{
    class LoaiMayDAL : ILoaiMayDAL
    {
        private string txtfile = @"D:\GITHUB\Project_1\ComputerStore\ComputerStore\bin\Debug\Data\LoaiMay.txt";
        public List<LoaiMay> GetData()
        {
            List<LoaiMay> list = new List<LoaiMay>();
            StreamReader sr = File.OpenText(txtfile);
            string s = sr.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = ComputerStore.Utility.CongCu.CatXau(s);
                    string[] a = s.Split('\t');
                    list.Add(new LoaiMay(int.Parse(a[0]), a[1], a[2]));
                }
                s = sr.ReadLine();
            }
            sr.Close();
            return list;
        }
        public int maLM
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
        public void Insert(LoaiMay lm)
        {
            int malm = maLM + 1;
            StreamWriter sw = File.AppendText(txtfile);
            sw.WriteLine();
            sw.Write(malm + "\t" + lm.tenLM + "\t" + lm.dacDiem);
            sw.Close();
        }
        public void Update(List<LoaiMay> list)
        {
            StreamWriter sw = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                sw.WriteLine(list[i].maLM + "\t" + list[i].tenLM + "\t" + list[i].dacDiem);
            sw.Close();
        }
    }
}
