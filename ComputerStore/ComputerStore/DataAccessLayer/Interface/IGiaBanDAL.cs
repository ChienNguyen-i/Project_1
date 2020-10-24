using System;
using System.Collections;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;

namespace ComputerStore.DataAccessLayer.Interface
{
    //Xác định các yêu cầu cần phải thao tác với cơ sở dữ liệu để phục vụ cho phần xử lý nghiệp vụ
    public interface IGiaBanDAL
    {
        List<GiaBan> GetData();
        void Insert(GiaBan gb);
        void Update(List<GiaBan> list);
    }
}
