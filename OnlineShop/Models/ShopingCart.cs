using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class ShopingCart
    {
        public ShopingCart() { }

        public List<ItemCart> listItem = new List<ItemCart>();
        public void AddItem(SanPham sp, int soluong=1)
        {

            if (listItem.Exists(item => item.sanpham.masanpham == sp.masanpham))
            {
                listItem.Find(i => i.sanpham.masanpham == sp.masanpham).soluong += soluong;
            }
            else
            {
                listItem.Add(new ItemCart() { sanpham = sp, soluong = soluong });
            }
        }
        public void UpdateAmount(SanPham sp, int soluong)
        {
            listItem.Find(i => i.sanpham.masanpham == sp.masanpham).soluong = soluong;
        }
        public void ReMove(SanPham sp)
        {
            listItem.Remove(listItem.Find(i => i.sanpham.masanpham == sp.masanpham));
        }
        public decimal TotalMoney()
        {
            decimal? tongtien = 0;
            foreach (ItemCart item in listItem)
            {
                tongtien += item.soluong * item.sanpham.giaban;
            }
            return tongtien.Value;
        }
        public int TotalAmmount()
        {
            int soluong = 0;
            foreach (ItemCart item in listItem)
            {
                soluong += item.soluong;
            }
            return soluong;
        }
    }
}