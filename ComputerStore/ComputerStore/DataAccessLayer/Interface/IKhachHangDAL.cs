using System;
using System.Collections.Generic;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;

namespace ComputerStore.DataAccessLayer.Interface
{
    //Xác định các yêu cầu cần phải thao tác với cơ sở dữ liệu để phục vụ cho phần xử lý nghiệp vụ
    public interface IKhachHangDAL
    {
        List<KhachHang> GetData();
        void Insert(KhachHang kh);
        void Update(KhachHang kh);
        void Delete(string makh);
    }
}
