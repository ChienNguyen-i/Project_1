using System;
using System.Collections;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;

namespace ComputerStore.Business.Interface
{
    //Xác định các yêu cầu nghiệp vụ của bài toán cần phải thực thi
    public interface IHDBanBLL
    {
        List<HDBan> LayDSHDBan();
        void ThemHDBan(HDBan hdb);
        void XoaHDBan(int mahdb);
        void SuaHDBan(HDBan hdb);
        List<HDBan> TimHDBan(HDBan hdb);
        HDBan LayHDBan(int mahdb);
    }
}
