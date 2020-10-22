using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ComputerStore.DataAccessLayer
{
    public class DataAccessHelper
    {
        private string FileName;
        public string fileName
        {
            get
            {
                return FileName;
            }
            set
            {
                if (value != "")
                    FileName = value;
            }
        }
        public DataAccessHelper()
        {
        }
        public DataAccessHelper(string filename)
        {
            this.FileName = filename;
        }
        public void WriteData(string tmp)
        {
            StreamWriter sw = new StreamWriter(fileName);
            sw.WriteLine(tmp);
            sw.Dispose();
        }
        public void RemoveAll()
        {
            StreamWriter sw = new StreamWriter(FileName);
            sw.Write("");
            sw.Dispose();
        }
    }
}
