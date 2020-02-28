using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurityCore.Models;
//using AcademyLog;
namespace SecurityCore.Controllers
{ 
    [ApiController]
    public class NewPasswordController : ControllerBase
    {
        //LogEntity log = new LogEntity();
        SecurityApiContext db = new SecurityApiContext();
        [HttpPost]
        [Route("api/NewPassword/ChangePassword")]
        public bool ChangePassword(ChangePassword user)
        {
            try
            {
                EndUser UserFromBd = db.EndUser.Where(x => x.UserName.ToUpper() == user.UserName.ToUpper()).First();
                byte[] newPass = new MySps().EncriptaSp(user.NewPassword);
                UserFromBd.Password = newPass;
                //log.mensaje = "the user " + user.UserName + " changed password";
                //log.aplicacion = "security";
                //log.fecha = DateTime.Now;
                //new Log().ConnectToWebAPI(log);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
        }
    }
}