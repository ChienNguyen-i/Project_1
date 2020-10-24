using System;
using System.Collections;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;

namespace ComputerStore.Business.Interface
{
    //Xác định các yêu cầu nghiệp vụ của bài toán cần phải thực thi
    public interface INhanVienBLL
    {
        List<NhanVien> LayDSNhanVien();
        void ThemNhanVien(NhanVien nv);
        void XoaNhanVien(int manv);
        void SuaNhanVien(NhanVien nv);
        List<NhanVien> TimNhanVien(NhanVien nv);
        NhanVien LayNhanVien(int manv);
    }
}
