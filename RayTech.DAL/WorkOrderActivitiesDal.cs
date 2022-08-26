using System;
using System.Collections.Generic;
using System.Linq;

namespace RayTech.DAL
{
    public class WorkOrderActivitiesDal
    {

        //veritabanı bağlantımız 
        RayTechDbEntities db = new RayTechDbEntities();


        //verilerin liste içinde dönmesini sağlamak için

        public IEnumerable<WorkOrderActivities> GetAllWorkOrderActivities()
        {
            return db.WorkOrderActivities;
        }

        //id'ye göre veri çekecek     
        public WorkOrderActivities GetWorkOrderActivitiesID(int id)
        {
            return db.WorkOrderActivities.Find(id);
        }



        //iki tarih arası listeleme
        public List<WorkOrderActivities> GetWorkOrderByDate(DateTime startDate, DateTime endDate)
        {
            return db.WorkOrderActivities.Where(w => w.StartDate >= startDate.Date && w.EndDate <= endDate.Date).ToList();
        }



        //ekleme için 
        public WorkOrderActivities CreateWorkOrderActivities(WorkOrderActivities WorkOrderActivities)
        {
            db.WorkOrderActivities.Add(WorkOrderActivities);
            db.SaveChanges();
            return WorkOrderActivities;
        }

        //güncelleme için 
        public WorkOrderActivities UpdateWorkOrderActivities(int id, WorkOrderActivities WorkOrderActivities)
        {
            db.Entry(WorkOrderActivities).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return WorkOrderActivities;
        }

        //silme için
        public void DeleteWorkOrderActivities(int id)
        {
            db.WorkOrderActivities.Remove(db.WorkOrderActivities.Find(id));
            db.SaveChanges();

        }
        public bool IsThereAnyWorkOrderActivities(int id)
        {
            return db.WorkOrderActivities.Any(x => x.WorkOrderCode == id);
        }
    }
}
