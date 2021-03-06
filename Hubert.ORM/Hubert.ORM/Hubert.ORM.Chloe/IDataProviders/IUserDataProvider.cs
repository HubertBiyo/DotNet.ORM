﻿using Hubert.Common.Method.Data;
using Hubert.Entities.System;
using System.Collections.Generic;

namespace Hubert.ORM.Chloe.IDataProviders
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
