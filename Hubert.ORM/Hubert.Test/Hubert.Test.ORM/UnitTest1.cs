using Hubert.Entities.System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Hubert.Test.ORM
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var model = (new User {
                Id=Guid.NewGuid(),
                UserName="hubert",
                Email="15130079715@163.com",
                Phone="15130079715",
                Lng=Convert.ToDecimal(114.542101),
                Lat=Convert.ToDecimal(36.620703),
                Location= "�ӱ�ʡ��̨������·13��",
                Remark="��������",
            });

            var result = Hubert.Service.System.UserService.Instance.Add(model);
        }
    }
}
