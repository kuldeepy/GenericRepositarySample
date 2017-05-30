using BusinessEntities.User;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorServices.Tests.BusinessEntity
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void Test_UserSerilizationAndDeSerilization()
        {
            //Arrange
            User user = CreateUserInstance();
            var serilaizeObj = JsonConvert.SerializeObject(user);

            //Act
            var result = JsonConvert.DeserializeObject<User>(serilaizeObj);

            //Assert
            Assert.AreEqual(result.Id, user.Id);
        }

        private User CreateUserInstance()
        {
            return new User {
                AllowAllocationAccess =  true,
                AllowClaimImportDelete = true,
                AllowCustomerDelete =  true,
                DateFormat = "mm/dd/yyyy",
                Email = "test@test.com",
                FailedLoginAttempts = 1,
                FirstName = "test",
                Id =1,
                IPAddress = "120.10.50.1",
                IsDeleted = true,
                LastName = "test",
                LoginName = "test.test",
                PasswordHash = "hash",
                PasswordSalt = "salt",
                RecordSetsClaimSection = 10,
                RecordsPerPageClRL = "10",
                RecordsPerPageCuRL = "10" ,
                RecordsSearchClaimSection = 10,
                RecordsSearchCustomerSection = 10,
                RecordsSetsClaimSection = 10,
                Rights = "internal",
                StartPage = "customer",
                Type = "internal",

            };
        }
    }
}
