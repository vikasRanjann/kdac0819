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
    // Allow CORS for all origins. (Caution!)
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    
    public class AddressController : ApiController
    {
        FinalProject_DBEntities dalobj = new FinalProject_DBEntities();

        AddressController()
        {
            dalobj.Configuration.ProxyCreationEnabled = false;
        }
        // GET: api/Address
        public IEnumerable<T_Address> Get()
        {
            return dalobj.T_Address.ToList();
        }

        // GET: api/Address/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Address
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Address/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Address/5
        public void Delete(int id)
        {
        }
    }
}
