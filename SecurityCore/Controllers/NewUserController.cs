using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurityCore.Models;

namespace SecurityCore.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewUserController : ControllerBase
    {
        SecurityApiContext db = new SecurityApiContext();
        public ActionResult CreateUser(NewUser newUser)
        {
            if (db.EndUser.Any(x => x.UserName.ToUpper() == newUser.UserName.ToUpper()))
            {
                return Content("repeated");
            }
            else
            {
                UserEntity usEnt = new UserEntity()
                {
                    UserEntityTypeCd = "USR",
                    IsEnabled = true,
                    IsDeleted = false,
                    LastModDt = DateTime.Now
                };
                db.UserEntity.Add(usEnt);

                EndUser newUserTodb = new EndUser()
                {
                    UserName = newUser.UserName.ToUpper(),
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    Password = new MySps().EncriptaSp(newUser.Password),
                    DomainId = 1,
                    UserEntityId = usEnt.UserEntityId,
                    UserTypeCd = "EXT",
                    IsEnabled = true,
                    IsDeleted = false,
                    LastModDt = DateTime.Now,
                    ExpirateDate = DateTime.Now
                };
                db.EndUser.Add(newUserTodb);
                db.SaveChanges();

                return Ok();
            }
        }
    }
}