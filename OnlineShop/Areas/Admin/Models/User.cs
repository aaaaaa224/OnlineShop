using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Models
{
    public class User

    { 
       
        [Required(ErrorMessage ="Nhập tài khoản")]
        public string taikhoan { get; set; }
        [Required(ErrorMessage = "Nhập tài mật khẩu")]
        public string matkhau { get; set; }
        public bool ghinhotaikhoan { get; set; }
    }
}