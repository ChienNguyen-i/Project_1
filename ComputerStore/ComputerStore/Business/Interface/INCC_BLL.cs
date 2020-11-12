using System;
using System.Collections;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;

namespace ComputerStore.Business.Interface
{
    //Xác định các yêu cầu nghiệp vụ của bài toán cần phải thực thi
    public interface INCC_BLL
    {
        List<NCC> LayDSNCC();
        void ThemNCC(NCC ncc);
        void XoaNCC(string mancc);
        void SuaNCC(NCC ncc);
        List<NCC> TimNCC(NCC ncc);
        NCC LayNCC(string mancc);
    }
}
