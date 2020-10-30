using System;
using System.Collections;
using System.Text;
using System.IO;
using ComputerStore.Utility;
using ComputerStore.Entities;
using System.Linq.Expressions;
using ComputerStore.DataAccessLayer.Interface;

namespace ComputerStore.DataAccessLayer
{
    class MayTinhDAL : IMayTinhDAL
    {
        private string txtfile = @"D:\GITHUB\Project_1\ComputerStore\ComputerStore\bin\Debug\Data\MayTinh.txt";
        public List<MayTinh> GetData()
        {
            List<MayTinh> list = new List<MayTinh>();
            StreamReader sr = File.OpenText(txtfile);
            string s = sr.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = ComputerStore.Utility.CongCu.CatXau(s);
                    string[] a = s.Split('\t');
                    list.Add(new MayTinh(int.Parse(a[0]), int.Parse(a[1]), a[2], int.Parse(a[3]), int.Parse(a[4]), int.Parse(a[5])));
                }
                s = sr.ReadLine();
            }
            sr.Close();
            return list;
        }
        public int maMT
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
        public void Insert(MayTinh mt)
        {
            int mamt = maMT + 1;
            StreamWriter sw = File.AppendText(txtfile);
            sw.WriteLine();
            sw.Write(mamt + "\t" + mt.maLM + "\t" + mt.tenMT + "\t" + mt.maNCC + "\t" + mt.sLNhap + "\t" + mt.sLCon);
            sw.Close();
        }
        public void Update(List<MayTinh> list)
        {
            StreamWriter sw = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                sw.WriteLine(list[i].maMT + "\t" + list[i].maLM + "\t" + list[i].tenMT + "\t" + list[i].maNCC + "\t" + list[i].sLNhap + "\t" + list[i].sLCon);
            sw.Close();
        }
    }
}