﻿using System;
using System.Collections;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;

namespace ComputerStore.Business.Interface
{
    //Xác định các yêu cầu nghiệp vụ của bài toán cần phải thực thi
    public interface IHDNhapBLL
    {
        List<HDNhap> LayDSHDNhap();
        void ThemHDNhap(HDNhap hdn);
        void XoaHDNhap(int mahdn);
        void SuaHDNhap(HDNhap hdn);
        List<HDNhap> TimHDNhap(HDNhap hdn);
        HDNhap LayHDNhap(int mahdn);
    }
}
