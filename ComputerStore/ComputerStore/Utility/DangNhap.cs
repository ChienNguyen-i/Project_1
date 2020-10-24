using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Utility
{
    public class DangNhap
    {
        private string User;
        private string Password;
        public DangNhap()
        { }
        public DangNhap(string user, string pass)
        {
            this.User = user;
            this.Password = pass;
        }
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
    }
}
