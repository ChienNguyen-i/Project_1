using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Entities
{
    class DangNhap
    {
        #region Các thành phần dữ liệu
        private string User;
        private string Password;
        #endregion
        #region Các phương thức khởi tạo
        public DangNhap()
        { }
        public DangNhap(string user, string pass)
        {
            this.User = user;
            this.Password = pass;
        }
        //Phương thức sao chép
        public DangNhap(DangNhap dn)
        {
            this.User = dn.User;
            this.Password = dn.Password;
        }
        #endregion
        #region Các thuộc tính
        public string user
        {
            get
            {
                return User;
            }
            set
            {
                if (value != "")
                    User = value;
            }
        }
        public string pass
        {
            get
            {
                return Password;
            }
            set
            {
                if (value != "")
                    Password = value;
            }
        }
        #endregion
    }
}
