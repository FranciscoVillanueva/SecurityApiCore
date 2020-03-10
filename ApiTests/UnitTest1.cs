using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityCore.Controllers;
using SecurityCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSessionsController()
        {
            SessionsController ns = new SessionsController(true);
            Assert.AreEqual(new UserLogged() { IsLogged = true, UserName = "USERNAME1", Role = "EXT" },
                ns.Login(new User() { UserName = "USERNAME1", Password = "pass1" }));
            Assert.AreEqual(new UserLogged() { IsLogged = true, UserName = "USERNAME1", Role = "EXT" },
                ns.Login(new User() { UserName = "Username1", Password = "pass1" }));
            Assert.AreEqual(new UserLogged() { IsLogged = false, UserName = "USERNAME1", Role = "EXT" },
                ns.Login(new User() { UserName = "Username1", Password = "pass" }));
            Assert.AreEqual(new UserLogged() { IsLogged = false, UserName = "Not registered", Role = "Not registered" },
                ns.Login(new User() { UserName = "juan", Password = "pass1" }));
        }

        [TestMethod]
        public void TestNewPassWordController()
        {
            NewPasswordController nw = new NewPasswordController(true);
            Assert.AreEqual(true, nw.ChangePassword(new ChangePassword { UserName = "USERNAME1", NewPassword = "pass" }));
            Assert.AreEqual(true, nw.ChangePassword(new ChangePassword { UserName = "Username1", NewPassword = "pass" }));
            Assert.AreEqual(false, nw.ChangePassword(new ChangePassword { UserName = "User", NewPassword = "pass" }));
        }

        [TestMethod]
        public void TestNewUserController()
        {
            NewUserController nu = new NewUserController(true);
            string output1 = JsonConvert.SerializeObject(new OkResult());
            string output2 = JsonConvert.SerializeObject(new ContentResult() { Content = "repeated" });
            Assert.AreEqual(output1, JsonConvert.SerializeObject(nu.CreateUser(new NewUser() {LastName = "Treviño", FirstName = "Manolo",UserName = "Manolo90", Password = "afeb2019" })));
            Assert.AreEqual(output2, JsonConvert.SerializeObject(nu.CreateUser(new NewUser() { LastName = "Treviño", FirstName = "Manolo", UserName = "USERNAME1", Password = "afeb2019" })));
            Assert.AreEqual(output2, JsonConvert.SerializeObject(nu.CreateUser(new NewUser() { LastName = "Treviño", FirstName = "Manolo", UserName = "Username2", Password = "afeb2019" })));
        }
    }
}
