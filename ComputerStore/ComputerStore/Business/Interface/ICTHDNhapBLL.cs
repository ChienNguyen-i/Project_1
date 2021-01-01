using System;
using System.Collections.Generic;
using System.Text;
using ComputerStore.Entities;

namespace ComputerStore.Business.Interface
{
    public interface ICTHDNhapBLL
    {
        List<CTHDNhap> LayDS_CTHDNhap();
        void ThemCTHDNhap(CTHDNhap cthdn);
        void XoaCTHDNhap(string mahdn);
        List<CTHDNhap> LayCTHDNhap(CTHDNhap cthdn);
    }
}
