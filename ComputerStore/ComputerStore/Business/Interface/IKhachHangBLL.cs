﻿using System;
using System.Collections.Generic;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;

namespace ComputerStore.Business.Interface
{
    //Xác định các yêu cầu nghiệp vụ của bài toán cần phải thực thi
    public interface IKhachHangBLL
    {
        List<KhachHang> LayDSKhachHang();
        void ThemKhachHang(KhachHang kh);
        void XoaKhachHang(string makh);
        void SuaKhachHang(KhachHang kh);
        List<KhachHang> TimKhachHang(KhachHang kh);
        KhachHang LayKhachHang(string makh);
    }
}
