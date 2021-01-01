using System;
using System.Collections.Generic;
using System.Text;
using ComputerStore.Entities;

namespace ComputerStore.Business.Interface
{
    public interface ICTHDBanBLL
    {
        List<CTHDBan> LayDS_CTHDBan();
        void ThemCTHDBan(CTHDBan cthdb);
        void XoaCTHDBan(string mahdb);
        List<CTHDBan> LayCTHDBan(CTHDBan cthdb);
    }
}
