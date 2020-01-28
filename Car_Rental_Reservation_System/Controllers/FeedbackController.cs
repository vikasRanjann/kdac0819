using Car_Rental_Reservation_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Car_Rental_Reservation_System.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FeedbackController : ApiController
    {
        FinalProject_DBEntities dalobj = new FinalProject_DBEntities();
        FeedbackController()
        {
            dalobj.Configuration.ProxyCreationEnabled = false;
        }
        // GET: api/Feedback
        public IEnumerable<T_Feedback> Get()
        {
            return dalobj.T_Feedback.ToList();

        }

        // GET: api/Feedback/5
        public ResponseData Get(T_Feedback id)
        {
            ResponseData response = new ResponseData();
                T_Car car = dalobj.T_Car.Find(id);
                    response.Data = car;
                       return response;
        }

        // POST: api/Feedback
        public ResponseData Get(int id)
        {

            ResponseData response = new ResponseData();

            T_Feedback car = dalobj.T_Feedback.Find(id);
            response.Data = car;
            return response;
        }

        // PUT: api/Feedback/5
        public ResponseData Put(int id, [FromBody]T_Feedback value)
        {
            ResponseData response = new ResponseData();


            T_Feedback feed = dalobj.T_Feedback.Find(id);
            feed.Name = value.Name;
            feed.EmailId = value.EmailId;
            feed.Message = value.Message;
            dalobj.SaveChanges();
            response.Status = "Car Details Updated successfully";
            return response;
        }

        // DELETE: api/Feedback/5
        public void Delete(int id)
        {
            T_Feedback feed = dalobj.T_Feedback.Find(id);
            dalobj.T_Feedback.Remove(feed);
            dalobj.SaveChanges();
        }
    }
}
