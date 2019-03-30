namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            GioHangs = new HashSet<GioHang>();
        }

        [Key]
        public int makhachhang { get; set; }

        [StringLength(50)]
        public string tenkhachhang { get; set; }

        [StringLength(10)]
        public string gioitinh { get; set; }

        [StringLength(11)]
        public string sodienthoai { get; set; }

        public DateTime? ngaysinh { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(100)]
        public string taikhoan { get; set; }

        [StringLength(100)]
        public string matkhau { get; set; }
        [StringLength(200)]
        public string diachi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHangs { get; set; }
    }
}
