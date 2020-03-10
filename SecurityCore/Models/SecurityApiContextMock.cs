using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SecurityCore.Models
{
    public class SecurityApiContextMock : SecurityApiContext
    {
        public SecurityApiContextMock()
        {
            List<UserEntity> listUserEntity = new List<UserEntity>()
            {
                new UserEntity()
                {
                    UserEntityTypeCd = "USR",
                    IsEnabled = true,
                    IsDeleted = false,
                    LastModDt = DateTime.Now,
                    //UserEntityId = 1
                },
                new UserEntity()
                {
                    UserEntityTypeCd = "USR",
                    IsEnabled = true,
                    IsDeleted = false,
                    LastModDt = DateTime.Now,
                    //UserEntityId = 2
                },
                new UserEntity()
                {
                    UserEntityTypeCd = "USR",
                    IsEnabled = true,
                    IsDeleted = false,
                    LastModDt = DateTime.Now,
                    //UserEntityId = 3
                }
            };

            List<EndUser> ListendUsers = new List<EndUser>()
            {
                new EndUser()
                {
                    //UserId = 1,
                    UserName = "USERNAME1",
                    FirstName = "FirstName",
                    LastName = "LastName",
                    Password = new byte[] { 1 },
                    DomainId = 1,
                    UserEntityId = listUserEntity[0].UserEntityId,
                    UserTypeCd = "EXT",
                    IsEnabled = true,
                    IsDeleted = false,
                    LastModDt = DateTime.Now,
                    ExpirateDate = DateTime.Now
                },
                new EndUser()
                {
                    //UserId = 2,
                    UserName = "USERNAME2",
                    FirstName = "FirstName",
                    LastName = "LastName",
                    Password = new byte[] { 2 },
                    DomainId = 1,
                    UserEntityId = listUserEntity[1].UserEntityId,
                    UserTypeCd = "EXT",
                    IsEnabled = true,
                    IsDeleted = false,
                    LastModDt = DateTime.Now,
                    ExpirateDate = DateTime.Now
                },
                new EndUser()
                {
                    //UserId = 3,
                    UserName = "USERNAME3",
                    FirstName = "FirstName",
                    LastName = "LastName",
                    Password = new byte[] { 3 },
                    DomainId = 1,
                    UserEntityId = listUserEntity[2].UserEntityId,
                    UserTypeCd = "EXT",
                    IsEnabled = true,
                    IsDeleted = false,
                    LastModDt = DateTime.Now,
                    ExpirateDate = DateTime.Now
                }
            };
            UserEntity.AddRange(listUserEntity);
            EndUser.AddRange(ListendUsers);
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase();
            }
        }
    }
}
