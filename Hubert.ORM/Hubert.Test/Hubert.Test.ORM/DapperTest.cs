using Hubert.Entities.System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Hubert.Test.ORM
{
    [TestClass]
    public class UnitTest1
    {
        #region Dapper��ɾ�Ĳ�

        /// <summary>
        /// ����
        /// </summary>
        [TestMethod]
        public void AddMethod()
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

        /// <summary>
        /// �޸�
        /// </summary>
        [TestMethod]
        public void UpdateMethod()
        {
            string UserId = "CC67E622-E9C6-4E7D-86AC-A9927060EE73";
            var model = new User {
                Id = new Guid(UserId),
                UserName="HubertBiyo",
                Email = "15130079715@163.com",
                Phone = "15130079715",
                Lng = Convert.ToDecimal(114.542101),
                Lat = Convert.ToDecimal(36.620703),
                Location = "�ӱ�ʡ��̨������·13��",
                Remark = "��������",
            };
            var result = Hubert.Service.System.UserService.Instance.Update(model);
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        [TestMethod]
        public void DeleteMethod()
        {
            var  Id =new Guid("CC67E622-E9C6-4E7D-86AC-A9927060EE73");
            var result = Hubert.Service.System.UserService.Instance.Delete(Id);
            
        }

        /// <summary>
        /// ��ѯ
        /// </summary>
        [TestMethod]
        public void SearchListMethod()
        {
            var condition = new UserSearchCondition {
                PageIndex = 1,
                PageSize=10,
            };
            var result = Hubert.Service.System.UserService.Instance.SearchList(condition);
        }

        #endregion



    }
}
