using ComputerStore.DataAccessLayer.Interface;
using System;
using System.Collections;
using System.Text;
using System.IO;
using ComputerStore.Utility;
using ComputerStore.Entities;

namespace ComputerStore.DataAccessLayer
{
    class LoaiMayDAL : ILoaiMayDAL
    {
        private string txtfile = "Data/LoaiMay.txt";
        public List<LoaiMay> GetData()
        {
            List<LoaiMay> list = new List<LoaiMay>();
            StreamReader f = File.OpenText(txtfile);
            string s = f.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = ComputerStore.Utility.CongCu.CatXau(s);
                    string[] a = s.Split('\t');
                    list.Add(new LoaiMay(a[0], a[1]));
                }
                s = f.ReadLine();
            }
            f.Close();
            return list;
        }
        public int maLM
        {
            get
            {
                StreamReader f = File.OpenText(txtfile);
                string s = f.ReadLine();
                string tmp = "";
                while (s != null)
                {
                    if (s != "")
                        tmp = s;
                    s = f.ReadLine();
                }
                f.Close();
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
            StreamWriter f = File.AppendText(txtfile);
            f.WriteLine();
            f.Write("LM" + maLM + "\t" + lm.tenLM + "\t" + lm.dacDiem);
            f.Close();
        }
        public void Update(List<LoaiMay> list)
        {
            StreamWriter f = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                f.WriteLine("LM" + list[i].maLM + "\t" + list[i].tenLM + "\t" + list[i].dacDiem);
            f.Close();
        }
    }
}
