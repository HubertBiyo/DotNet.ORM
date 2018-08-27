using System;
using System.Collections.Generic;
using System.Text;
using Hubert.Common.Method.Data;
using Hubert.Entities.System;

namespace Hubert.ORM.Dapper.IDataProviders
{
    public interface IUserDataProvider:IDataProvider
    {
        bool Add(User model);
        bool Edit(User model);
        bool Delete(Guid Id);
        List<User> SearchList(UserSearchCondition condition);
    }
}
