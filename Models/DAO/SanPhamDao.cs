using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using PagedList.Mvc;
using System.Data.SqlClient;
using System.Data;
using Models.DTO;

namespace Models.DAO
{
    public class SanPhamDao
    {
        OnlineShopDbContext db = null;
        public SanPhamDao()
        {
            db = new OnlineShopDbContext();
        }
      
        public List<SanPham> timkiem(string timkiem,int danhmuc)
        {
            List<SanPham> li = new List<SanPham>();
            string chuoiketnoi = @"Data Source=.\SqlExpress;Initial Catalog=Demo;Integrated Security=True";
            SqlConnection con = new SqlConnection(chuoiketnoi);
            con.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_timkiemsanpham";
            command.Parameters.Add("@timkiem",SqlDbType.NVarChar,100).Value=timkiem;
            command.Parameters.Add("@danhmuc", SqlDbType.Int).Value=danhmuc;
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(command);
            adap.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                SanPham sp = new SanPham()
                {
                    masanpham = (int)dr["masanpham"],
                    tensanpham = dr["tensanpham"].ToString(),
                    giaban = (decimal)dr["giaban"],
                    uutien=(int)dr["uutien"],
                    linkanh=dr["linkanh"].ToString(),
                    madanhmuc=(int)dr["madanhmuc"],
                    maloaisanpham=(int)dr["maloaisanpham"],
                    mota=dr["mota"].ToString(),
                    xuatxu=dr["xuatxu"].ToString(),
                    soluong=(int)dr["soluong"]
                    ,chitiet=dr["chitiet"].ToString()
                };
               li.Add(sp);
            }
            con.Close();
            con.Dispose();
            return li;
        }
        public IQueryable<SanPham> dsSanPham()
        {
            return db.SanPhams.Select(p => p);
        }
        public void Create(SanPham sp)
        {
            try
            {
                db.SanPhams.Add(sp);
                db.SaveChanges();
            }
            catch (Exception)
            {

                
            }
        }
        //public SanPhamDTO searchProduct1(int id)
        //{
        //    var sp = from a in db.SanPhams
                     
        //              join b in db.DanhMucSanPhams on a.madanhmuc equals b.madanhmucsanpham
        //              select new SanPhamDTO { tensanpham = a.tensanpham, soluong = a.soluong, giaban = a.giaban, chitiet = a.chitiet, masanpham = a.masanpham, xuatxu = a.xuatxu, linkanh = a.linkanh, madanhmuc = a.madanhmuc, tendanhmucsanpham = b.tendanhmucsanpham }
        //              ;
        //    return sp;
        //}
        public SanPham searchProduct(int id)
        {
            return db.SanPhams.Find(id);
        }
        public void Edit(SanPham sp)
        {
            db.Entry(sp).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            SanPham sp = db.SanPhams.Find(id);
            if (sp != null)
            {
                db.SanPhams.Remove(sp);
                db.SaveChanges();
            }
        }
        
        public IEnumerable<SanPham> listProduct(int pagenumber,int pagesize)
        {
            return db.SanPhams.OrderBy(p => p.masanpham).ToPagedList(pagenumber, pagesize);
        }
        //public IEnumerable<SanPham> dsSanPhamTheoUuTien(int uutien)
        //{
        //    return db.SanPhams.Where(p => p.uutien == uutien).OrderByDescending(p=>p.masanpham);
        //}
        public IEnumerable<SanPham> dsSanPhamTheoUuTien(int uutien,int page,int pagesize)
        {
            return db.SanPhams.Where(p => p.uutien == uutien).OrderByDescending(p => p.masanpham).ToPagedList(page, pagesize);
        }
        public IEnumerable<SanPham> dsSanPhamTheoLoai(int loaisanpham,int page,int pagesize)
        {
            return db.SanPhams.Where(p => p.maloaisanpham == loaisanpham).OrderByDescending(p=>p.masanpham).ToPagedList(page,pagesize);
        }
        public IEnumerable<SanPham> dsSanPhamTheoDanhMuc(int madanhmuc,int page,int pagesize)
        {
            return db.SanPhams.Where(p => p.uutien == madanhmuc).OrderByDescending(p=>p.masanpham).ToPagedList(page,pagesize);
        }
    }
}
