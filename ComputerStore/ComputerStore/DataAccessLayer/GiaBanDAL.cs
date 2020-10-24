using System;
using System.Collections;
using System.Text;
using System.IO;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.DataAccessLayer.Interface;

namespace ComputerStore.DataAccessLayer
{
    class GiaBanDAL : IGiaBanDAL
    {
        private string txtfile = "Data/GiaBan.txt";
        public List<GiaBan> GetData()
        {
            List<GiaBan> list = new List<GiaBan>();
            StreamReader sr = File.OpenText(txtfile);
            string s = sr.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = ComputerStore.Utility.CongCu.CatXau(s);
                    string[] a = s.Split('\t');
                    list.Add(new GiaBan(int.Parse(a[0]), a[1], double.Parse(a[2]), DateTime.Parse(a[3]), DateTime.Parse(a[4])));
                }
                s = sr.ReadLine();
            }
            sr.Close();
            return list;
        }
        public int maGB
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
        public void Insert(GiaBan gb)
        {
            int magb = maGB + 1;
            StreamWriter sw = File.AppendText(txtfile);
            sw.WriteLine();
            sw.Write(magb + "\t" + gb.maMT + "\t" + gb.giaBan +"\t" + gb.ngayAD + "\t" + gb.ngayThoiAD);
            sw.Close();
        }
        public void Update(List<GiaBan> list)
        {
            StreamWriter sw = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                sw.WriteLine(list[i].maGB + "\t" + list[i].maMT + "\t" + list[i].giaBan + "\t" + list[i].ngayAD + "\t" + list[i].ngayThoiAD);
            sw.Close();
        }
    }
}
