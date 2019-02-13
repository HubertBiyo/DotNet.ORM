using Chloe;
using Chloe.MySql;
using Hubert.Entities.System;
using Hubert.ORM.Chloe.IDataProviders;
using System.Collections.Generic;

namespace Hubert.ORM.Chloe.MySqlDataProviders
{
    public class MySqlUserDataProvider : IUserDataProvider
    {
        static DbContext context = new MySqlContext(new MySqlConnectionFactory(DataProviders.Connection_Sql));
        public bool Add(UserMySql model)
        {
            UserMySql user = new UserMySql();
            user = context.Insert(model);

            if (user == null || string.IsNullOrEmpty(user.ID))
            {
                return false;
            }
            return true;
        }
        public bool Delete(string Id)
        {
            return context.Delete<UserMySql>(a => a.ID == Id) > 0;
        }
        public bool Edit(UserMySql model)
        {
            UserMySql user = new UserMySql();
            return context.Update(model) > 0;
        }
        public List<UserMySql> SearchList(UserSearchCondition condition)
        {
            var query = context.Query<UserMySql>();
            var list = query.Where(a => !string.IsNullOrEmpty(a.ID)).OrderBy(a => a.ID).Skip(condition.PageIndex).Take(condition.PageSize).ToList();
            return list;
        }
        public int SearchListCount(UserSearchCondition condition)
        {
            var query = context.Query<UserMySql>();
            var count = query.Count();
            return count;
        }
    }
}
