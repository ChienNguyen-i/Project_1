﻿using System;
using System.Collections.Generic;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;

namespace ComputerStore.DataAccessLayer.Interface
{
    //Xác định các yêu cầu cần phải thao tác với cơ sở dữ liệu để phục vụ cho phần xử lý nghiệp vụ
    public interface INhanVienDAL
    {
        List<NhanVien> GetData();
        void Insert(NhanVien nv);
        void Update(NhanVien nv);
        void Delete(string manv);
    }
}
