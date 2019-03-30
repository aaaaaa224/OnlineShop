using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class KhachDatHangDTO
    {
        public int makhachhang { get; set; }
        public string tenkhachhang { get; set; }
        public string sodienthoai { get; set; }
        public string email { get; set; }
        public string diachi { get; set; }
        public DateTime? ngaydathang { get; set; }
        public  decimal? tongtien { get; set; }
        public int magiohang { get; set; }
    }
}
