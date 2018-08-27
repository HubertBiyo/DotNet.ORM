using Dapper;
using Hubert.Entities.System;
using Hubert.ORM.Dapper.IDataProviders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Hubert.ORM.Dapper.SqlDataProviders
{
    public class SqlUserDataProvider : IUserDataProvider
    {
        public bool Add(User model)
        {
            StringBuilder sql = new StringBuilder(@"
INSERT  INTO dbo.[User]
        ( Id ,
          UserName ,
          Email ,
          Phone ,
          Lng ,
          Lat ,
          Location ,
          Remark
        )
VALUES  ( @Id ,
          @UserName ,
          @Email ,
          @Phone ,
          @Lng ,
          @Lat ,
          @Location ,
          @Remark 
        )
");
            using (IDbConnection conn = GetSqlConnection(""))
            {
                return  conn.Execute(sql.ToString(), model)>0;
                
            }
        }

        public bool Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(User model)
        {
            throw new NotImplementedException();
        }

        public List<User> SearchList(UserSearchCondition condition)
        {
            throw new NotImplementedException();
        }
        private static SqlConnection GetSqlConnection(string sqlConnectionString)
        {
            SqlConnection conn = new SqlConnection(sqlConnectionString);
            conn.Open();
            return conn;
        }
    }
}
