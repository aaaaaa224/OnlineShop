using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class KhachHangDTO
    {
        [Required(ErrorMessage ="Tên khách hàng")]
        [StringLength(50)]
        public string tenkhachhang { get; set; }

        [StringLength(11)]
        [Required(ErrorMessage = "Số điện thoại")]
        public string sodienthoai { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Email")]
        public string email { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "Địa chỉ")]
        public string diachi { get; set; }
    }
}