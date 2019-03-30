namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioHang")]
    public partial class GioHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GioHang()
        {
            ChiTietGioHangs = new HashSet<ChiTietGioHang>();
        }

        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int magiohang { get; set; }

        public int? makhachhang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaydathang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaygiaohang { get; set; }

        public decimal? tongtien { get; set; }

        public bool? tinhtranggiaohang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGioHang> ChiTietGioHangs { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
