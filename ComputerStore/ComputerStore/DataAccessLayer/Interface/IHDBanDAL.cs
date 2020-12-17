using System;
using System.Collections.Generic;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;

namespace ComputerStore.DataAccessLayer.Interface
{
    //Xác định các yêu cầu cần phải thao tác với cơ sở dữ liệu để phục vụ cho phần xử lý nghiệp vụ
    public interface IHDBanDAL
    {
        List<HDBan> GetData();
        void Insert(HDBan hdb);
        void Update(HDBan hdb);
        void Delete(string mahdb);
    }
}
