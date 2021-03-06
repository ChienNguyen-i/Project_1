﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.DataAccessLayer.Interface;

namespace ComputerStore.DataAccessLayer
{
    class KhachHangDAL : IKhachHangDAL
    {
        private string txtfile = "Data/KhachHang.txt";
        public List<KhachHang> GetData()
        {
            List<KhachHang> list = new List<KhachHang>();
            StreamReader sr = File.OpenText(txtfile);
            string s = sr.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = CongCu.CatXau(s);
                    string[] a = s.Split('\t');
                    list.Add(new KhachHang(a[0], a[1], a[2], a[3]));
                }
                s = sr.ReadLine();
            }
            sr.Close();
            return list;
        }
        public string maKH
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
                    return "KH0";
                else
                {
                    string[] a = tmp.Split('\t');
                    return a[0];
                }
            }
        }
        public void Insert(KhachHang kh)
        {
            int makh = CongCu.TachSo(maKH) + 1;
            StreamWriter sw = File.AppendText(txtfile);
            sw.WriteLine("KH" + makh + "\t" + kh.tenKH + "\t" + kh.diaChi + "\t" + kh.soDT);
            sw.Close();
        }
        public void Update(KhachHang kh)
        {
            List<KhachHang> list = GetData();
            for (int i = 0; i < list.Count; ++i)
                if (list[i].maKH == kh.maKH)
                {
                    list[i] = kh;
                    break;
                }
            StreamWriter sw = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                sw.WriteLine(list[i].maKH + "\t" + list[i].tenKH + "\t" + list[i].diaChi + "\t" + list[i].soDT);
            sw.Close();
        }
        public void Delete(string makh)
        {
            List<KhachHang> list = GetData();
            StreamWriter sw = File.CreateText(txtfile);
            foreach (KhachHang kh in list)
                if (kh.maKH != makh)
                    sw.WriteLine(kh.maKH + "\t" + kh.tenKH + "\t" + kh.diaChi + "\t" + kh.soDT);
            sw.Close();
        }
    }
}
