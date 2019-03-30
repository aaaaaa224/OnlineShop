using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class ItemCart
    {
        public ItemCart() { }
        public SanPham sanpham{ get; set; }
        public int soluong { get; set; }
        public decimal? thanhtien()
        {
            return sanpham.giaban * soluong;
        }
    }
}