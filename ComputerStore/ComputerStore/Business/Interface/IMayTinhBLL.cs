using System;
using System.Collections;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;

namespace ComputerStore.Business.Interface
{
    //Xác định các yêu cầu nghiệp vụ của bài toán cần phải thực thi
    public interface IMayTinhBLL
    {
        List<MayTinh> LayDSMayTinh();
        void ThemMayTinh(MayTinh mt);
        void XoaMayTinh(string mamt);
        void SuaMayTinh(MayTinh mt);
        List<MayTinh> TimMayTinh(MayTinh mt);
        MayTinh LayMayTinh(string mamt);
    }
}
