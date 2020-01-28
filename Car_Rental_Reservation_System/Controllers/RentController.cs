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
    public class RentController : ApiController
    {
        FinalProject_DBEntities dalobj = new FinalProject_DBEntities();

        // GET: api/Rent
        public IEnumerable<T_Rent> Get()
        {



            return dalobj.T_Rent.ToList();
        }

        // GET: api/Rent/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Rent
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Rent/5
        public void Put(int id, [FromBody]T_Rent value)
        {
            T_Rent rent = dalobj.T_Rent.Find(id);
            rent.TotalRentDay = value.TotalRentDay;
            rent.DailyRentFee = value.DailyRentFee;
            rent.FuelCharge = value.FuelCharge;
            rent.Total = value.Total;
            rent.Refund = value.Refund;
            //rent.CarId = value.CarId;
            //rent.UserId = value.UserId;
            //rent.ResId = value.ResId;

        }

        // DELETE: api/Rent/5
        public void Delete(int id)
        {
            T_Rent role = dalobj.T_Rent.Find(id);
            dalobj.T_Rent.Remove(role);
            dalobj.SaveChanges();


        }
    }
}

