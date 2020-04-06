using DotNetCore.Security;
using DotNetCoreArchitecture.Infra;
using DotNetCoreArchitecture.Model;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.UnitTests.Infra
{
    [TestFixture]
    public class SignInServiceTest
    {
        private Mock<IHashService> hashServiceMock;
        private Mock<IJsonWebTokenService> webTokenServiceMock;
        private ISignInService taskService;

        [SetUp]
        public void SetUp()
        {
            hashServiceMock = new Mock<IHashService>();
            webTokenServiceMock = new Mock<IJsonWebTokenService>();
            taskService = new SignInService(hashServiceMock.Object, webTokenServiceMock.Object);
        }

        [Test]
        public void CreateSignIn_Success()
        {
            var result = taskService.CreateSignIn(new SignInModel { Login = "Login", Password = "password", Salt = "" });

            Assert.AreNotEqual("password", result.Password);
        }

        [Test]
        public void CreateToken_Success()
        {

        }

        [Test]
        public void Validate_Success()
        {

        }
    }
}
