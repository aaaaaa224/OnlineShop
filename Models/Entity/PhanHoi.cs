namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanHoi")]
    public partial class PhanHoi
    {
        [Key]
        public int ma { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage ="Tên của bạn")]
        public string tennguoiphanhoi { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Email của bạn")]
        public string email { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Nội dung")]
        public string noidung { get; set; }
    }
}
