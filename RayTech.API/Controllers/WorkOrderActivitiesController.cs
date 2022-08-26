using RayTech.API.Security;
using RayTech.DAL;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace RayTech.API.Controllers
{
    public class WorkOrderActivitiesController : ApiController
    {
        //crud işlemlerimizi yapabilmek için WorkOrdeActivitiesDal'ı çağırdık
        WorkOrderActivitiesDal WorkOrderActivitiesDal = new WorkOrderActivitiesDal();

        //get -READ İŞLEMİ İÇİN
        [ResponseType(typeof(IEnumerable<WorkOrderActivities>))]
        [APIAuthorize(Roles = "A,U")]
        public IHttpActionResult Get()
        {
            var WorkOrderActivities = WorkOrderActivitiesDal.GetAllWorkOrderActivities();
            return Ok(WorkOrderActivities);
        }

        //GET  - READ İD YE GÖRE 
        [ResponseType(typeof(WorkOrderActivities))]
        [APIAuthorize(Roles = "A,U")]
        public IHttpActionResult Get(int id)
        {
            var workactivitiesid = WorkOrderActivitiesDal.GetWorkOrderActivitiesID(id);
            if (workactivitiesid == null)
            {
                return NotFound();
            }
            return Ok(workactivitiesid);
        }




        [ResponseType(typeof(List<WorkOrderActivities>))]
        [APIAuthorize(Roles = "A,U")]
        //tarihe göre listeleme
        public IHttpActionResult Get(DateTime startDate, DateTime endDate)
        {
            var workactivitiesdate = WorkOrderActivitiesDal.GetWorkOrderByDate(startDate, endDate);
            if (workactivitiesdate == null)
            {
                return NotFound();
            }
            return Ok(workactivitiesdate);
        }



        //Post - Create İşlemi için  
        [ResponseType(typeof(WorkOrderActivities))]
        [APIAuthorize(Roles = "A")]
        public IHttpActionResult Post(WorkOrderActivities WorkOrderActivities)
        {
            if (ModelState.IsValid)
            {
                var createdWorkOrderActivities = WorkOrderActivitiesDal.CreateWorkOrderActivities(WorkOrderActivities);
                return CreatedAtRoute("DefaultApi", new { id = createdWorkOrderActivities.WorkOrderCode }, createdWorkOrderActivities);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        //Put - Update İşlemleri İçin
        [ResponseType(typeof(WorkOrderActivities))]
        [APIAuthorize(Roles = "A")]
        public IHttpActionResult Put(int id, WorkOrderActivities workOrderActivities)
        {
            //id ye ait kayıt yok ise
            if (WorkOrderActivitiesDal.IsThereAnyWorkOrderActivities(id) == false)
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
                return Ok(WorkOrderActivitiesDal.UpdateWorkOrderActivities(id, workOrderActivities));
            }

        }

        //Delete İçin
        [APIAuthorize(Roles = "A")]
        public IHttpActionResult Delete(int id)
        {
            if (WorkOrderActivitiesDal.IsThereAnyWorkOrderActivities(id) == false)
            {
                return NotFound();
            }
            else
            {
                WorkOrderActivitiesDal.DeleteWorkOrderActivities(id);
                return Ok();
            }
        }
    }
}
