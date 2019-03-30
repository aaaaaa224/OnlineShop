namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ma { get; set; }

        [StringLength(50)]
        public string linkanh { get; set; }

        [StringLength(10)]
        public string mota { get; set; }
    }
}
