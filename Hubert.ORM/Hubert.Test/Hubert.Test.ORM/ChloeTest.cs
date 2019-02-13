using Hubert.Entities.System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Hubert.Test.ORM
{
    class ChloeTest
    {
        #region ORM.Chloe
        [TestMethod]
        public void AddByChloe()
        {
            var model = new UserMySql
            {
                ID = Guid.NewGuid().ToString("N"),
                Name = "豆子11",
                Address = "河北邯郸",
                Email = "305752065@qq.com",
                Phone = "15130079715"
            };
            var result = Hubert.Service.System.UserService.Instance.AddByChloe(model);
        }
        [TestMethod]
        public void UpdateByChloe()
        {
            var model = new UserMySql
            {
                ID = "3D9ED995-3AD9-4AA5-8B0D-2741146148F9",
                Name = "缘分",
                Phone = "15130079715",
                Address = "北京昌平区天通西苑三区",
                Email = "15130079715@163.com",
            };
            var result = Hubert.Service.System.UserService.Instance.UpdateByChloe(model);
        }
        [TestMethod]
        public void DeleteByChloe()
        {
            var ID = "99ab329384be47f08d26e9c35701e225";
            var result = Hubert.Service.System.UserService.Instance.DeleteByChloe(ID);
        }
        [TestMethod]
        public void SearchListByChloe()
        {
            var condition = new UserSearchCondition
            {
                PageIndex = 1,
                PageSize = 10,
            };
            var result = Hubert.Service.System.UserService.Instance.SearchListByChloe(condition);
        }
        #endregion
    }
}
