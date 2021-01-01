using System;
using System.Collections.Generic;
using System.Text;
using ComputerStore.Entities;

namespace ComputerStore.DataAccessLayer.Interface
{
    public interface ICTHDBanDAL
    {
        List<CTHDBan> GetData();
        void Insert(CTHDBan cthdb);
        void Delete(string mahdb);
    }
}
