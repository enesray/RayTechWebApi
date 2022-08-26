using System.Collections.Generic;
using System.Linq;

namespace RayTech.DAL
{
    public class WorkOrderDAL
    {
        //veritabanı bağlantımız 
        RayTechDbEntities db = new RayTechDbEntities();


        //verilerin liste içinde dönmesini sağlamak için
        public IEnumerable<WorkOrder> GetAllWorkOrder()
        {
            return db.WorkOrder;
        }

        //id'ye göre veri çekecek     
        public WorkOrder GetWorkOrderID(int id)
        {
            return db.WorkOrder.Find(id);
        }

        //ekleme için 
        public WorkOrder CreateWorkOrder(WorkOrder workOrder)
        {
            db.WorkOrder.Add(workOrder);
            db.SaveChanges();
            return workOrder;
        }

        //güncelleme için 
        public WorkOrder UpdateWorkOrder(int id, WorkOrder workOrder)
        {
            db.Entry(workOrder).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return workOrder;
        }

        //silme için
        public void DeleteWorkOrder(int id)
        {
            db.WorkOrder.Remove(db.WorkOrder.Find(id));
            db.SaveChanges();

        }

        public bool IsThereAnyWorkOrder(int id)
        {
            return db.WorkOrder.Any(x => x.WorkOrderCode == id);
        }



    }
}
