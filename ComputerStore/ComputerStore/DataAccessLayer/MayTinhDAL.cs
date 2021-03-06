﻿using System;
using System.Collections.Generic;
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
        private string txtfile = "Data/MayTinh.txt";
        public List<MayTinh> GetData()
        {
            List<MayTinh> list = new List<MayTinh>();
            StreamReader sr = File.OpenText(txtfile);
            string s = sr.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    s = CongCu.CatXau(s);
                    string[] a = s.Split('\t');
                    list.Add(new MayTinh(a[0], a[1], a[2], int.Parse(a[3]), double.Parse(a[4])));
                }
                s = sr.ReadLine();
            }
            sr.Close();
            return list;
        }
        public void Insert(MayTinh mt)
        {
            StreamWriter sw = File.AppendText(txtfile);
            sw.WriteLine(mt.maMT + "\t" + mt.tenMT + "\t" + mt.maNCC + "\t" + mt.sLCon + "\t" + mt.giaBan);
            sw.Close();
        }
        public void Update(MayTinh mt)
        {
            List<MayTinh> list = GetData();
            for (int i = 0; i < list.Count; ++i)
                if (list[i].maMT == mt.maMT)
                {
                    list[i] = mt;
                    break;
                }
            StreamWriter sw = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                sw.WriteLine(list[i].maMT + "\t" + list[i].tenMT + "\t" + list[i].maNCC + "\t" + list[i].sLCon + "\t" + list[i].giaBan);
            sw.Close();
        }
        public void Delete(string mamt)
        {
            List<MayTinh> list = GetData();
            StreamWriter sw = File.CreateText(txtfile);
            foreach (MayTinh mt in list)
                if (mt.maMT != mamt)
                    sw.WriteLine(mt.maMT + "\t" + mt.tenMT + "\t" + mt.maNCC + "\t" + mt.sLCon + "\t" + mt.giaBan);
            sw.Close();
        }
        public void Update_Sub(MayTinh mt, int sl)
        {
            List<MayTinh> list = GetData();
            for (int i = 0; i < list.Count; ++i)
                if (list[i].maMT == mt.maMT)
                {
                    list[i] = mt;
                    list[i].sLCon -= sl;
                    break;
                }
            StreamWriter sw = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                sw.WriteLine(list[i].maMT + "\t" + list[i].tenMT + "\t" + list[i].maNCC + "\t" + list[i].sLCon + "\t" + list[i].giaBan);
            sw.Close();
        }
        public void Update_Add(MayTinh mt, int sl)
        {
            List<MayTinh> list = GetData();
            for (int i = 0; i < list.Count; ++i)
                if (list[i].maMT == mt.maMT)
                {
                    list[i] = mt;
                    list[i].sLCon += sl;
                    break;
                }
            StreamWriter sw = File.CreateText(txtfile);
            for (int i = 0; i < list.Count; ++i)
                sw.WriteLine(list[i].maMT + "\t" + list[i].tenMT + "\t" + list[i].maNCC + "\t" + list[i].sLCon + "\t" + list[i].giaBan);
            sw.Close();
        }
    }
}