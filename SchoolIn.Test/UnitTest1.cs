using System;
using SchoolIn.API.Controllers;
using SchoolIn.API.EF;
using SchoolIn.API.Models;
using Xunit;

namespace SchoolIn.Test
{
    public class UnitTest1
    {
        [Fact]
        public void UserSoma()
        {
            MathUtil util = new MathUtil();
            Assert.Equal(util.Soma(10, 10), 20);
        }
    }
}
