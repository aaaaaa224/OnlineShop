using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class UserDao
    {
        OnlineShopDbContext db = null;
        public UserDao()
        {
            db = new OnlineShopDbContext();
        }
        public bool kiemtraTk(string taikhoan,string matkhau)
        {
            User u = db.Users.SingleOrDefault(p => p.matkhau == matkhau && p.taikhoan == taikhoan);
            if (u != null) return true;
            else return false;
        }
        public User GetUser(string taikhoan)
        {
            User u= db.Users.Find(taikhoan);
            return u;
        }
    }
}
