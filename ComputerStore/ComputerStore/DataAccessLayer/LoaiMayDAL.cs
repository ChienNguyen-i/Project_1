﻿using ComputerStore.Entities;
using System;
using System.Collections;
using System.Text;
using ComputerStore.Utility;
using System.IO;

namespace ComputerStore.DataAccessLayer
{
    class LoaiMayDAL
    {
        DataAccessHelper dah = new DataAccessHelper("Data/LoaiHang.txt");
        public string toString(LoaiMay lm)
        {
            return lm.maLM + "\t" + lm.tenLM + "\t" + lm.dacDiem;
        }
        public LoaiMay tostring(string s)
        {
            s = CongCu.CatXau(s);
            string[] tmp = s.Split('\t');
            LoaiMay lm = new LoaiMay(int.Parse(tmp[0]), tmp[1], tmp[2]);
            return lm;
        }
        public void Write(string filename, LoaiMay lm)
        {
            FileStream f = new FileStream(filename, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(f);
            sw.WriteLine(toString(lm));
            sw.Close();
            f.Close();
        }
        public LoaiMay Read(string filename)
        {
            FileStream f = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(f);
            string kq = sr.ReadLine();
            return tostring(kq);
        }
        public void WriteList(string filename, List<LoaiMay> lm)
        {
            FileStream f = new FileStream(filename, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(f);
            Node<LoaiMay> tg = lm.Head;
            while (tg != null)
            {
                sw.WriteLine(toString(tg.Info));
                tg = tg.Link;
            }
            sw.Close();
            f.Close();
        }
        public List<LoaiMay> ReadList(string filename)
        {
            FileStream f = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(f);
            List<LoaiMay> list = new List<LoaiMay>();
            string s = sr.ReadLine();
            while (s != null)
            {
                if (s != "")
                    list.AddTail(tostring(s));
                s = sr.ReadLine();
            }
            sr.Close();
            f.Close();
            return list;
        }
    }
}
