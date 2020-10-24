using System;
using System.Collections;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;

namespace ComputerStore.DataAccessLayer.Interface
{
    //Xác định các yêu cầu cần phải thao tác với cơ sở dữ liệu để phục vụ cho phần xử lý nghiệp vụ
    public interface ICTHDNhapDAL
    {
        List<CTHDNhap> GetData();
        void Insert(CTHDNhap cthdn);
        void Update(List<CTHDNhap> list);
    }
}
