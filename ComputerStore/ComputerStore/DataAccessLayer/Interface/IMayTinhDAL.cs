using System;
using System.Collections.Generic;
using System.Text;
using ComputerStore.Entities;
using ComputerStore.Utility;

namespace ComputerStore.DataAccessLayer.Interface
{
    //Xác định các yêu cầu cần phải thao tác với cơ sở dữ liệu để phục vụ cho phần xử lý nghiệp vụ
    public interface IMayTinhDAL
    {
        List<MayTinh> GetData();
        void Insert(MayTinh mt);
        void Update(MayTinh mt);
        void Delete(string mamt);
    }
}
