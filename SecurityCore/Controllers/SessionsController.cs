using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurityCore.Models;
using Microsoft.EntityFrameworkCore;

namespace SecurityCore.Controllers
{
    //https://www.youtube.com/watch?v=e90p1Pvvl84
    //https://stackoverflow.com/questions/51017703/error-cs1061-dbsett-does-not-contain-a-definition-for-fromsql-and-no-exte
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        SecurityApiContext db;
        MySps Sp;

        public SessionsController(bool test = false)
        {
            if (test)
            {
                db = new SecurityApiContextMock();
                Sp = new MySpsMock();
            }
            else
            {
                db = new SecurityApiContext();
                Sp = new MySps();
            }
        }
        
        [HttpPost]
        public UserLogged Login(User user)
        {
            try
            {
                EndUser UserReg = db.EndUser.Where(x => x.UserName.ToUpper() == user.UserName.ToUpper()).FirstOrDefault();
                string passDb = Sp.DesencriptaSp(UserReg.Password);
                bool isLogged = db.EndUser.Any(x => x.UserName.ToUpper() == user.UserName.ToUpper() &&
                    passDb == user.Password);
                return new UserLogged() { IsLogged = isLogged, UserName = user.UserName.ToUpper(), Role = UserReg.UserTypeCd };
            }
            catch (Exception e)
            {
                return new UserLogged() { IsLogged = false, UserName = "Not registered", Role = "Not registered" };
                throw e;
            }
        }
    }
}