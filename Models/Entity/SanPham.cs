namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietGioHangs = new HashSet<ChiTietGioHang>();
        }

        [Key]
        [DisplayName("Mã sản phẩm")]
        public int masanpham { get; set; }


        [StringLength(100)]
        [Required(ErrorMessage ="Nhập tên sản phẩm")]
        [DisplayName("Tên sản phẩm")]
        public string tensanpham { get; set; }

        [DisplayName("Giá bán")]
        [Required(ErrorMessage ="Nhập giá bán")]
        [DataType("decimal",ErrorMessage ="Nhập vào giá cả là số")]
        [Range(10000,200000,ErrorMessage ="Giá bán từ 10000 đến 200000 nghìn đồng")]
        public decimal? giaban { get; set; }

        [DisplayName("Mô tả")]
        [Required(ErrorMessage ="Hãy mô tả ngắn gọn sản phẩm")]
        [Column(TypeName = "ntext")]
        public string mota { get; set; }

        [DisplayName("Loại sản phẩm")]
        [Required(ErrorMessage ="Chọn loại sản phẩm")]
        public int? maloaisanpham { get; set; }

        [DisplayName("Danh mục sản phẩm")]
       
        public int? madanhmuc { get; set; }

        [DisplayName("Đường dẫn ảnh")]
        //[Required(ErrorMessage ="Chọn đường dẫn ảnh")]
        [StringLength(150)]
        public string linkanh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaytao { get; set; }

        [DisplayName("Số lượng")]
        [Range(1,10000,ErrorMessage ="Số lượng sản phẩm từ 1 đến 10000")]
        [Required(ErrorMessage ="Nhập số lượng")]
        public int? soluong { get; set; }

        [DisplayName("Xuất xứ")]
        [StringLength(50)]
        public string xuatxu { get; set; }

        [StringLength(100)]
        public string metatitle { get; set; }

        [DisplayName("Đánh giá chi tiết sản phẩm")]
        [Column(TypeName = "ntext")]
        public string chitiet { get; set; }

        public int uutien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGioHang> ChiTietGioHangs { get; set; }

        public virtual DanhMucSanPham DanhMucSanPham { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}
