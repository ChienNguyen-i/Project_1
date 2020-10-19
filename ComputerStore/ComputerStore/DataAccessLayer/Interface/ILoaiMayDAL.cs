using System;
using System.Collections;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;

namespace ComputerStore.DataAccessLayer.Interface
{
    public interface ILoaiMayDAL
    {
        List<LoaiMay> GetData();
        void Insert(LoaiMay lm);
        void Update(List<LoaiMay> list);
    }
}
