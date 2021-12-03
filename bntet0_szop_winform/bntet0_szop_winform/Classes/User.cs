using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bntet0_szop_winform.Classes
{
    public class User
    {
        private int id;
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        private int admin;

        public User()
        {

        }

        public User(int id, string username, string password, int admin)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.admin = admin;
        }

        public int Admin
        {
            get
            {
                return admin;
            }
            set
            {
                admin = value;
            }
        }

    }
}
