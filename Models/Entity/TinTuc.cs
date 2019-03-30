namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinTuc")]
    public partial class TinTuc
    {
        [Key]
        public int ma { get; set; }

        [Required(ErrorMessage ="Nhập tên tin tức")]
        [StringLength(100)]
        public string ten { get; set; }

        [Required(ErrorMessage ="Nội dung Tin tức")]
        [Column(TypeName = "ntext")]
        public string mota { get; set; }

        [StringLength(100)]
        public string linkanh { get; set; }
    }
}
