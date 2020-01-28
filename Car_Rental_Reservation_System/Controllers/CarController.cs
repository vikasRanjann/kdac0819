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
    public class CarController : ApiController
    {
        FinalProject_DBEntities dalobj = new FinalProject_DBEntities();
        CarController()
        {
            dalobj.Configuration.ProxyCreationEnabled = false;
        }
        // GET: api/Car
        public List<T_Car> Get()
        {
            return dalobj.T_Car.ToList();
        }

        // GET: api/Car/5
        public ResponseData Get(int id)
        {
            ResponseData response = new ResponseData();

            T_Car car = dalobj.T_Car.Find(id);
            response.Data = car;
            return response;
        }

    // POST: api/Car
    [HttpPost]
        [Route("api/Car/addcar")]
        public ResponseData Post([FromBody]T_Car cars)
        {
            ResponseData response = new ResponseData();
          
            if (cars != null)
            {
                dalobj.T_Car.Add(cars);
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

        //Getting hotels based on search
        [HttpPost]
        [Route("api/Car/Findcar")]
        public ResponseData FindRoom([FromBody]T_Reservation value)
        {
            ResponseData response = new ResponseData();

            List<T_Reservation> scarlist = dalobj.T_Reservation.ToList();
            List<T_Car> carlist = dalobj.T_Car.ToList();
            /* IEnumerable<T_TrainInfo> trains*/
            var cars = from car in carlist
                        join scar in scarlist on car.CarId equals scar.CarId
                        where car.CarId == value.CarId
                        select new { car.CarId, car.Brand, car.DailyPrice, scar.ResId, scar.ResDate,scar.PickupDate,scar.ReturnDate};
            /*&& t.Date == value.Date*/

            if (cars != null)
            {
                response.Status = "Success";
                response.Data = cars;
                response.Error = null;
            }
            else
            {
                response.Status = "Something went wrong";
                response.Data = null;
                response.Error = null;
            }
            return response;
        }

        // PUT: api/Car/5
        public ResponseData Put(int id, [FromBody]T_Car value)
        {
            ResponseData response = new ResponseData();

            T_Car car = dalobj.T_Car.Find(id);
            car.Brand = value.Brand;
            car.Type = value.Type;
            car.Stock = value.Stock;
            car.Model = value.Model;
            car.SeatQuantity = value.SeatQuantity;
            car.FuelType = value.FuelType;
            car.Mileage = value.Mileage;
            car.DailyPrice = value.DailyPrice;
            dalobj.SaveChanges();
            response.Status = "Car Details Updated successfully";
            return response;
        }

        // DELETE: api/Car/5
        public void Delete(int id)

        {
            T_Car car = dalobj.T_Car.Find(id);
            dalobj.T_Car.Remove(car);
            dalobj.SaveChanges();
        }
    }
}
