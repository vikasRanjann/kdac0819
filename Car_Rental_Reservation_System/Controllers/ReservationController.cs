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
    public class ReservationController : ApiController
    {
        FinalProject_DBEntities dalobj = new FinalProject_DBEntities();
        // GET: api/Reservation
        public IEnumerable<T_Reservation> Get()
        {
            return dalobj.T_Reservation.ToList();
        }

        // GET: api/Reservation/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Reservation
        public ResponseData Post([FromBody]T_Reservation res)
        {
            ResponseData response = new ResponseData();
            res.ResId = 2;
            if (res != null)
            {
                dalobj.T_Reservation.Add(res);
                dalobj.SaveChanges();
                response.Error = null;
                response.Status = "Success";
                return response;
            }
            else
            {
                response.Error = null;
                response.Status = "plz enter valid data";
                return response;
            }
        
    }

        
        // PUT: api/Reservation/5
        public void Put(int id, [FromBody]T_Reservation value)
        {

            T_Reservation res = dalobj.T_Reservation.Find(id);
            res.ResDate = value.ResDate;
            res.PickupDate = value.PickupDate;
            res.ReturnDate = value.ReturnDate;
            //res.CarId = value.CarId;
            //res.UserId = value.UserId;
            dalobj.SaveChanges();
        }

        // DELETE: api/Reservation/5
        public void Delete(int id)
        {

            T_Car car = dalobj.T_Car.Find(id);
            dalobj.T_Car.Remove(car);
            dalobj.SaveChanges();


        }
    }
}
