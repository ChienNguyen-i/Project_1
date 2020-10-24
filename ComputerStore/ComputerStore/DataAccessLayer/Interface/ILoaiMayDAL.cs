﻿using System;
using System.Collections;
using System.Text;
using ComputerStore.Entities;
using ComputerStore.Utility;

namespace ComputerStore.DataAccessLayer.Interface
{
    //Xác định các yêu cầu cần phải thao tác với cơ sở dữ liệu để phục vụ cho phần xử lý nghiệp vụ
    public interface ILoaiMayDAL
    {
        List<LoaiMay> GetData();
        void Insert(LoaiMay lm);
        void Update(List<LoaiMay> list);
    }
}
