using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LogicUniversityStationeryStore;

namespace LogicUniversityStationeryStore.Controller
{
    public class RequestDetailsController : ApiController
    {


        //LogicUniversityEntities2 db = new LogicUniversityEntities2();
       

        //// GET: api/RequestDetails
        //public IQueryable<RequestDetail> GetRequestDetails()
        //{
        //    return db.RequestDetails;
        //}

        //// GET: api/RequestDetails/5
        //[ResponseType(typeof(RequestDetail))]
        //public IHttpActionResult GetRequestDetail(int id)
        //{
        //    RequestDetail requestDetail = db.RequestDetails.Find(id);
        //    if (requestDetail == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(requestDetail);
        //}

        //// PUT: api/RequestDetails/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutRequestDetail(int id, RequestDetail requestDetail)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != requestDetail.id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(requestDetail).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RequestDetailExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/RequestDetails
        //[ResponseType(typeof(RequestDetail))]
        //public IHttpActionResult PostRequestDetail(RequestDetail requestDetail)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.RequestDetails.Add(requestDetail);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = requestDetail.id }, requestDetail);
        //}

        //// DELETE: api/RequestDetails/5
        //[ResponseType(typeof(RequestDetail))]
        //public IHttpActionResult DeleteRequestDetail(int id)
        //{
        //    RequestDetail requestDetail = db.RequestDetails.Find(id);
        //    if (requestDetail == null)
        //    {
        //        return NotFound();
        //    }

        //    db.RequestDetails.Remove(requestDetail);
        //    db.SaveChanges();

        //    return Ok(requestDetail);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool RequestDetailExists(int id)
        //{
        //    return db.RequestDetails.Count(e => e.id == id) > 0;
        //}
    }
}