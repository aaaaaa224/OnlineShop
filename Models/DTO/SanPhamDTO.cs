using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class SanPhamDTO
    {
        //tensanpham=a.tensanpham,soluong=a.soluong,giaban=a.giaban,chitiet=a.chitiet,masanpham=a.masanpham,xuatxu=a.xuatxu,linkanh=a.linkanh,madanhmuc=a.madanhmuc,b.tendanhmucsanpham
        public int masanpham { get; set; }
        public int? soluong { get; set; }
        public string chitiet { get; set; }
        public string xuatxu { get; set; }
        public int? madanhmuc { get; set; }
        public string tendanhmucsanpham { get; set; }
        public decimal? giaban { get; set; }
        public string tensanpham { get; set; }
        public string linkanh { get; set; }
    }
}
