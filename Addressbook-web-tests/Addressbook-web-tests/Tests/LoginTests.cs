﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase 
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            //Готовим тестовую ситуацию
            applicationManager.Auth.Logout();

            //Действие
            AccountData account = new AccountData("admin", "secret");
            
            //Проверка
            applicationManager.Auth.Login(account);

            Assert.IsTrue(applicationManager.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            //Готовим тестовую ситуацию
            applicationManager.Auth.Logout();

            //Действие
            AccountData account = new AccountData("admin", "popopo");

            //Проверка
            applicationManager.Auth.Login(account);

            Assert.IsFalse(applicationManager.Auth.IsLoggedIn(account));
        }
    }
}
