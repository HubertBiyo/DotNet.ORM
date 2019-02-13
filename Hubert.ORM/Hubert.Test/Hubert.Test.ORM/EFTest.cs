using Hubert.Entities.System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Hubert.Test.ORM
{
    public class EFTest
    {
        #region ORM.EF
        [TestMethod]
        public void AddUserByEF()
        {
            var model = new UserMySql
            {
                ID = Guid.NewGuid().ToString("N"),
                Name = "EF框架的使用",
                Address = "河北邯郸",
                Email = "305752065@qq.com",
                Phone = "15130079715"
            };
            var result = Hubert.Service.System.UserService.Instance.AddMySqlByEF(model);
        }

        [TestMethod]
        public void DeleteUserByEF()
        {
            var Id = "8698ef263abb4ff199a26ea51aabc96c";
            var result = Hubert.Service.System.UserService.Instance.DeleteByEF(Id);
        }
        [TestMethod]
        public void UpdateUserByEF()
        {
            var model = new UserMySql
            {
                ID = "4ce34ce90c42468b9a4a574ff0620e0e",
                Name = "HubertBiyo",
                Phone = "15130079715",
                Address = "北京昌平区天通西苑三区",
                Email = "15130079715@163.com",
            };
            var result = Hubert.Service.System.UserService.Instance.UpdateByEF(model);
        }
        [TestMethod]
        public void SearchListByEF()
        {
            var condition = new UserSearchCondition
            {
                PageIndex = 1,
                PageSize = 10,
            };
            var result = Hubert.Service.System.UserService.Instance.SearchListByEF(condition);
        }
        #endregion
    }
}
