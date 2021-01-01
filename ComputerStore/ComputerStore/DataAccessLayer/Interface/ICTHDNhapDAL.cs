using System;
using System.Collections.Generic;
using System.Text;
using ComputerStore.Entities;

namespace ComputerStore.DataAccessLayer.Interface
{
    public interface ICTHDNhapDAL
    {
        List<CTHDNhap> GetData();
        void Insert(CTHDNhap cthdn);
        void Delete(string mahdn);
    }
}
