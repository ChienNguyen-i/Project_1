using System;
using System.Collections;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;

namespace ComputerStore.Business.Interface
{
    //Xác định các yêu cầu nghiệp vụ của bài toán cần phải thực thi
    public interface IGiaBanBLL
    {
        List<GiaBan> LayDSGiaBan();
        void ThemGiaBan(GiaBan gb);
        void XoaGiaBan(int magb);
        void SuaGiaBan(GiaBan gb);
        List<GiaBan> TimGiaBan(GiaBan gb);
        GiaBan LayGiaBan(int magb);
    }
}
