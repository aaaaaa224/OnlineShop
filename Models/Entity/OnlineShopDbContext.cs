namespace Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OnlineShopDbContext : DbContext
    {
        public OnlineShopDbContext()
            : base("name=OnlineShopDbContext")
        {
        }

        public virtual DbSet<ChiTietGioHang> ChiTietGioHangs { get; set; }
        public virtual DbSet<DanhMucSanPham> DanhMucSanPhams { get; set; }
        public virtual DbSet<GioHang> GioHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<PhanHoi> PhanHois { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietGioHang>()
                .Property(e => e.thanhtien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DanhMucSanPham>()
                .Property(e => e.metatitle)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMucSanPham>()
                .HasMany(e => e.SanPhams)
                .WithOptional(e => e.DanhMucSanPham)
                .HasForeignKey(e => e.madanhmuc);

            modelBuilder.Entity<GioHang>()
                .Property(e => e.tongtien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<GioHang>()
                .HasMany(e => e.ChiTietGioHangs)
                .WithRequired(e => e.GioHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.gioitinh)
                .IsFixedLength();

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.sodienthoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<PhanHoi>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.giaban)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.metatitle)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietGioHangs)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.mota)
                .IsFixedLength();

            modelBuilder.Entity<TinTuc>()
                .Property(e => e.linkanh)
                .IsUnicode(false);
        }
    }
}
