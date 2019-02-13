using Hubert.Common.Method.Configuration;
using Hubert.Common.Method.Data;
using Hubert.ORM.Dapper.IDataProviders;
using Hubert.ORM.Dapper.SqlDataProviders;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Hubert.ORM.Dapper
{
    public class DataProviders
    {
        public static IUserDataProvider UserDataProvider
        {
            get {return Get<IUserDataProvider, SqlUserDataProvider>(); }
        }
        private static U Get<T,U>()
            where T:IDataProvider
            where U:IDataProvider
        {
            Type internalType = typeof(T);
            Type classType = typeof(U);
            U instance;
            lock(_instanceDic)
            {
                if(_instanceDic.ContainsKey(internalType))
                {
                    instance = (U)_instanceDic[internalType];
                }
                else
                {
                    instance = (U)Activator.CreateInstance(classType);
                    _instanceDic.Add(internalType, instance);
                }
            }
            return instance;
        }
        static DataProviders()
        {
            _instanceDic = new Dictionary<Type, object>();
        }
        private static readonly Dictionary<Type, object> _instanceDic;
    }
    public class DapperContext
    {
        public static SqlConnection GetSqlConnection()
        {
            SqlConnection conn = new SqlConnection(ConfigHelper.GetString("AppSettings:SqlConnectionString:ConnectionString"));
            conn.Open();
            return conn;
        }
    }
}
