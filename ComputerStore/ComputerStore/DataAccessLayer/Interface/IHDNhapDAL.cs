using System;
using System.Collections.Generic;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;

namespace ComputerStore.DataAccessLayer.Interface
{
    //Xác định các yêu cầu cần phải thao tác với cơ sở dữ liệu để phục vụ cho phần xử lý nghiệp vụ
    public interface IHDNhapDAL
    {
        List<HDNhap> GetData();
        void Insert(HDNhap hdn);
        void Update(HDNhap hdn);
        void Delete(string mahdn);
    }
}
