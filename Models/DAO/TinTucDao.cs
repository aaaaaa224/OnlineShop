using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using PagedList.Mvc;
namespace Models.DAO
{
    public class TinTucDao
    {
        OnlineShopDbContext db = null;
        public TinTucDao()
        {
            db = new OnlineShopDbContext();
        }
        public void Create(TinTuc t)
        {
            db.TinTucs.Add(t);
            db.SaveChanges();
        }
        public IEnumerable<TinTuc> listNews(int page, int pagesize)
        {
            return db.TinTucs.OrderBy(p => p.ma).ToPagedList(page, pagesize);
        }
        public TinTuc Detail(int id)
        {
            return db.TinTucs.Find(id);
        }
        public void Delete(int id)
        {
            TinTuc tt = db.TinTucs.Find(id);
            db.TinTucs.Remove(tt);
            db.SaveChanges();
        }
        public TinTuc search(int id)
        {
           return  db.TinTucs.Find(id);
        }
        public void Edit(TinTuc tt)
        {
            try
            {
                db.Entry(tt).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {

                
            }
        }
    }
}
