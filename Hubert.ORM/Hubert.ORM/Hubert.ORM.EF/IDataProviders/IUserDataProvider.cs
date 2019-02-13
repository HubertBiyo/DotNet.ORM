using Hubert.Common.Method.Data;
using Hubert.Entities.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hubert.ORM.EF.IDataProviders
{
    public interface IUserDataProvider:IDataProvider
    {
        bool Add(UserMySql model);
        bool Edit(UserMySql model);
        bool Delete(string Id);
        List<UserMySql> SearchList(UserSearchCondition condition);
        int SearchListCount(UserSearchCondition condition);
    }
}
