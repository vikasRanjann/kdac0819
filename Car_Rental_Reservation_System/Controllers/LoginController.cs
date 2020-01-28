using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Car_Rental_Reservation_System.Models;
namespace Car_Rental_Reservation_System.Controllers
{
    public class LoginController : ApiController
    {
        FinalProject_DBEntities dalobj = new FinalProject_DBEntities();
        T_Users user = new T_Users();

        public LoginController()
        {
            dalobj.Configuration.ProxyCreationEnabled = false;
        }

        // POST: api/Login
        public ResponseData Post([FromBody]T_Users login)
        {
            ResponseData response = new ResponseData();
            if (login.EmailId != null && login.Password != null)
            {
                var listuser = dalobj.T_Users.ToList();
                T_Users validUser = (from user in listuser
                                     where user.EmailId == login.EmailId &&
                                     user.Password == login.Password
                                     select user).SingleOrDefault();
                if (validUser != null)
                {
                    response.Data = validUser;
                    response.Error = null;
                    response.Status = "success";
                    return response;
                }
                else
                {
                    response.Error = null;
                    response.Status = "Incorrect Credentials";
                    return response;

                }
            }
            else
            {
                response.Error = null;
                response.Status = "Field are empty";
                return response;

            }
        }

        #region PasswordHistoryLog
        [Route("api/passhistory")]
        public IEnumerable<T_PasswordHistoryLog> Get()
        {
            return dalobj.T_PasswordHistoryLog.ToList();   
        }
        #endregion
    }
}
      