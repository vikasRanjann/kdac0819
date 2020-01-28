using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Car_Rental_Reservation_System.Models;
using System.Web.Http.Cors;

namespace Car_Rental_Reservation_System.Controllers
{
    // Allow CORS for all origins. (Caution!)
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class RolesController : ApiController
    {
        FinalProject_DBEntities dalobj = new FinalProject_DBEntities();
        RolesController()
        {
            dalobj.Configuration.ProxyCreationEnabled = false;
        }
        // GET: api/Roles
        public IEnumerable<T_Roles> Get()
        {
            return dalobj.T_Roles.ToList();
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Roles/5
        public T_Roles Get(int id)
        {
            return dalobj.T_Roles.Find(id);
        }

        // POST: api/Roles
        public void Post([FromBody]T_Roles value)
        {
            dalobj.T_Roles.Add(value);
            dalobj.SaveChanges();
        }

        // PUT: api/Roles/5
        public void Put(int id, [FromBody]T_Roles value)
        {
            T_Roles role = dalobj.T_Roles.Find(id);
            role.RoleName_= value.RoleName_;
            dalobj.SaveChanges();
            
        }

        // DELETE: api/Roles/5
        public void Delete(int id)
        {
            T_Roles role = dalobj.T_Roles.Find(id);
            dalobj.T_Roles.Remove(role);
            dalobj.SaveChanges();


        }
    }
}
