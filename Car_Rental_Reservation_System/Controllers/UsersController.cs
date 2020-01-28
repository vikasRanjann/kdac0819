using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Car_Rental_Reservation_System.Models;
using System.Net.Mail;
using System.Web.Http.Cors;

namespace Car_Rental_Reservation_System.Controllers
{
    // Allow CORS for all origins. (Caution!)
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class UsersController : ApiController
    {
        FinalProject_DBEntities dalobj = new FinalProject_DBEntities();

         UsersController()
        {
            dalobj.Configuration.ProxyCreationEnabled = false;
        }
        // GET: api/Users
        public IEnumerable<T_Users> Get()
        {
            return dalobj.T_Users.ToList();
           // return new string[] { "value1", "value2" };
        }

        // GET: api/Users/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Users
        [HttpPost]
        [Route("api/Registration")]
        public ResponseData Registration([FromBody]T_Users user)
        {
            ResponseData response = new ResponseData();
            user.RoleId = 2;
            if (user!=null)
            {
                dalobj.T_Users.Add(user);
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

        // PUT: api/Users/5
        public void Put(int id, [FromBody]T_Users value)
        {
            T_Users role = dalobj.T_Users.Find(id);
            role.EmailId = value.EmailId;
            role.Name = value.Name;
            role.Password = value.Password;
            role.MobileNo = value.MobileNo;
            role.IsOnline = value.IsOnline;
            role.IsLocked = value.IsLocked;
            role.RoleId = value.RoleId;
            dalobj.SaveChanges();
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }

        //email logic
        [HttpPost]
        [Route("api/User/sendmail")]
        public ResponseData sendmail([FromBody]Email e)
        {
            ResponseData rs = new ResponseData();
            string to = e.to;
            string body = e.body;
            string subject = e.body;
     string result = "Message Sent Successfully..!!";
     string senderID = "vikash.ranjan933@gmail.com";// use sender’s email id here..
     const string senderPassword = "vikash.4690"; // sender password here…
     try
     {
       SmtpClient smtp = new SmtpClient
       {
         Host = "smtp.gmail.com", // smtp server address here…
         Port = 587,
         EnableSsl = true,
         DeliveryMethod = SmtpDeliveryMethod.Network,
         Credentials = new System.Net.NetworkCredential(senderID, senderPassword),
         Timeout = 30000,
       };
       MailMessage message = new MailMessage(senderID, to, subject, body);
       smtp.Send(message);
     }
     catch (Exception ex)
     {
       result = "Error sending email.!!!";
                rs.Error = ex;
     }
     return rs;
   }


        [HttpPost]
        [Route("api/OTP")]
        public ResponseData OTP([FromBody]dynamic otpDetails)
        {
            string email = otpDetails.EmailId.ToString();
            
            var userlist = dalobj.T_Users.ToList();
            var User = (from u in userlist
                        where u.EmailId == email
                        select u).SingleOrDefault();
            string o = otpDetails.OTP.ToString();

            var otpd = dalobj.T_OTP_Details.ToList();
            var vOTP = (from v in otpd
                        where v.UserId == User.UserId_ && v.OTP == o
                        select v).SingleOrDefault();

            if (vOTP != null)
            {
                ResponseData RC = new ResponseData();
                RC.Status = "success";
                RC.Error = null;
                RC.Data = vOTP;
                return RC;
            }
            else
            {
                ResponseData RC = new ResponseData();
                RC.Status = "fail";
                RC.Error = null;
                RC.Data = false;
                return RC;
            }
        }




        [HttpPost]
        [Route("api/IsExist")]
        public ResponseData IsExist([FromBody]T_Users value)
        {
            Email e = new Email();
            var userlist = dalobj.T_Users.ToList();
            var User = (from u in userlist
                        where u.EmailId == value.EmailId
                        select u).SingleOrDefault();
            if (User != null)
            {
                ResponseData RC = new ResponseData();
                string mails = GetOTP();

                T_OTP_Details otp = new T_OTP_Details();
                otp.UserId = User.UserId_;
                otp.C_DateTime_Not_Null = DateTime.Now;
                otp.GeneratedOn = DateTime.Now;
                otp.OTP = mails;
                dalobj.T_OTP_Details.Add(otp);
                dalobj.SaveChanges();
                //
                e.body = "OTP Is " + mails;
                e.to = User.EmailId;
                e.subject = "OTP:";

                sendmail(e);
                RC.Status = "success";
                RC.Error = null;
                RC.Data = mails;
                return RC;
            }
            else
            {
                ResponseData RC = new ResponseData();
                RC.Status = "fail";
                RC.Error = null;
                RC.Data = false;
                return RC;
            }

        }


        [HttpPut]
        [Route("api/UpdatePassword")]
        public ResponseData updatepassword([FromBody]T_Users value)
        {

            var userlist = dalobj.T_Users.ToList();
            var User = (from u in userlist
                        where u.EmailId == value.EmailId
                        select u).SingleOrDefault();

            if (User != null)
            {
                User.Password = value.Password;
                dalobj.SaveChanges();
                ResponseData rc = new ResponseData();
                rc.Status = "success";
                rc.Error = null;
                rc.Data = User;
                return rc;
            }
            else
            {
                ResponseData rc = new ResponseData();
                rc.Status = "fail";
                rc.Error = null;
                rc.Data = null;
                return rc;
            }
        }
        private string GetOTP(string otpType = "1", int len = 5)
        {
            //otptype 1 = alpha numeric
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";

            string characters = numbers;
            if (otpType == "1")
            {
                characters += alphabets + small_alphabets + numbers;
            }
            int length = 5;
            string otp = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }
            return otp;
        }

    }
}
