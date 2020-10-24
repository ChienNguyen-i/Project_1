using System;
using System.Collections;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;

namespace ComputerStore.Business.Interface
{
    //Xác định các yêu cầu nghiệp vụ của bài toán cần phải thực thi
    public interface ICTHDBanBLL
    {
        List<CTHDBan> LayDSCTHDBan();
        void ThemCTHDBan(CTHDBan cthdb);
        void XoaCTHDBan(int macthdb);
        void SuaCTHDBan(CTHDBan cthdb);
        List<CTHDBan> TimCTHDBan(CTHDBan cthdb);
        CTHDBan LayCTHDBan(int macthdb);
    }
}
