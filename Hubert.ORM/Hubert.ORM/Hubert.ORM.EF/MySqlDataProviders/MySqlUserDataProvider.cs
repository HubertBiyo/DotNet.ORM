using Hubert.Entities.System;
using Hubert.ORM.EF.IDataProviders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hubert.ORM.EF.MySqlDataProviders
{
    public class MySqlUserDataProvider : IUserDataProvider
    {
        public bool Add(UserMySql model)
        {
            using (var context = new MySqlDbContext())
            {
                context.UserMySql.Add(new UserMySql
                {
                    ID = model.ID,
                    Name = model.Name,
                    Address = model.Address,
                    Email = model.Email,
                    Phone = model.Phone
                });
                return context.SaveChanges() > 0;
            }
        }

        public bool Delete(string Id)
        {
            var model = new UserMySql { ID = Id };
            using (var context = new MySqlDbContext())
            {
                context.UserMySql.Remove(model);
                return context.SaveChanges() > 0;
            }

        }

        public bool Edit(UserMySql model)
        {
            using (var context = new MySqlDbContext())
            {
                context.UserMySql.Update(model);
                return context.SaveChanges() > 0;
            }
        }

        public List<UserMySql> SearchList(UserSearchCondition condition)
        {
            using (var context = new MySqlDbContext())
            {
                var list = context.UserMySql.OrderByDescending(m => m.ID).Skip(condition.PageIndex).Take(condition.PageSize).ToList();
                return list;
            }
        }

        public int SearchListCount(UserSearchCondition condition)
        {
            using (var context = new MySqlDbContext())
            {
                var count = context.UserMySql.Count();
                return count;
            }
        }
    }
}
