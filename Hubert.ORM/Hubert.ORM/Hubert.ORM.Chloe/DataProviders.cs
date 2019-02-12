using Chloe.Infrastructure;
using Hubert.Common.Method.Configuration;
using Hubert.Common.Method.Data;
using Hubert.ORM.Chloe.IDataProviders;
using Hubert.ORM.Chloe.MySqlDataProviders;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Hubert
{
    public class DataProviders
    {
        internal static string Connection_Sql
        {
            get
            {
                string connectionString = ConfigHelper.GetString("AppSettings:MysqlConnectionString:ConnectionString");
                return connectionString;
            }
        }
        public static IUserDataProvider UserDataProvider
        {
            get { return Get<IUserDataProvider, MySqlUserDataProvider>(); }
        }
        private static U Get<T, U>()
            where T : IDataProvider
            where U : IDataProvider
        {
            Type internalType = typeof(T);
            Type classType = typeof(U);
            U instance;
            lock (_instanceDic)
            {
                if (_instanceDic.ContainsKey(internalType))
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
    public class MySqlConnectionFactory : IDbConnectionFactory
    {
        string _connString = null;
        public MySqlConnectionFactory(string connString)
        {
            this._connString = connString;
        }
        public IDbConnection CreateConnection()
        {
            IDbConnection conn = new MySqlConnection(this._connString);
            conn = new Chloe.MySql.ChloeMySqlConnection(conn);
            return conn;
        }
    }
}
