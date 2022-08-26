using RayTech.API.Security;
using RayTech.DAL;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace RayTech.API.Controllers
{
    public class WorkOrderController : ApiController
    {
        //crud işlemlerimizi yapabilmek için WorkOrderDal'ı çağırdık
        WorkOrderDAL WorkOrderDal = new WorkOrderDAL();

        //get -READ İŞLEMİ İÇİN
        [ResponseType(typeof(IEnumerable<WorkOrder>))]

        //[Authorize] isteğe göre standart authorize kullanılabilir


        [APIAuthorize(Roles = "A,U")]  //admin veya user bu metoda erişebilir
        public IHttpActionResult Get()
        {
            var workorder = WorkOrderDal.GetAllWorkOrder();
            return Ok(workorder);
        }

        //GET  - READ İD YE GÖRE 
        [ResponseType(typeof(WorkOrder))]
        [APIAuthorize(Roles = "A,U")]
        public IHttpActionResult Get(int id)
        {
            var workorderid = WorkOrderDal.GetWorkOrderID(id);
            if (workorderid == null)
            {
                return NotFound();
            }
            return Ok(workorderid);
        }



        //Post - Create İşlemi için  
        [ResponseType(typeof(WorkOrder))]
        [APIAuthorize(Roles = "A")]
        public IHttpActionResult Post(WorkOrder workorder)
        {
            if (ModelState.IsValid)
            {
                var createdWorkOrder = WorkOrderDal.CreateWorkOrder(workorder);
                return CreatedAtRoute("DefaultApi", new { id = createdWorkOrder.WorkOrderCode }, createdWorkOrder);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        //Put - Update İşlemleri İçin
        [ResponseType(typeof(WorkOrder))]
        [APIAuthorize(Roles = "A")]
        public IHttpActionResult Put(int id, WorkOrder workorder)
        {
            //id ye ait kayıt yok ise
            if (WorkOrderDal.IsThereAnyWorkOrder(id) == false)
            {
                return NotFound();
            }

            //workorder modeli doğrulanmadıysa
            else if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            //ok her şeyi karşılıyorsa
            else
            {
                return Ok(WorkOrderDal.UpdateWorkOrder(id, workorder));
            }

        }

        //Delete İçin
        [APIAuthorize(Roles = "A")]
        public IHttpActionResult Delete(int id)
        {
            if (WorkOrderDal.IsThereAnyWorkOrder(id) == false)
            {
                return NotFound();
            }
            else
            {
                WorkOrderDal.DeleteWorkOrder(id);
                return Ok();
            }
        }
    }
}
