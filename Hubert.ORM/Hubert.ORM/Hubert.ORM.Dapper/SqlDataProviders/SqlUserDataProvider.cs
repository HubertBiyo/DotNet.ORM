using Dapper;
using Hubert.Entities.System;
using Hubert.ORM.Dapper.IDataProviders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
            using (IDbConnection conn = DapperContext.GetSqlConnection())
            {
                return conn.Execute(sql.ToString(), model) > 0;

            }
        }

        public bool Delete(Guid Id)
        {
            StringBuilder sql = new StringBuilder(@"
DELETE  FROM [dbo].[User]
WHERE   Id = @Id
");
            using (IDbConnection conn = DapperContext.GetSqlConnection())
            {
                return conn.Execute(sql.ToString(), new { Id }) > 0;
            }
        }

        public bool Edit(User model)
        {
            StringBuilder sql = new StringBuilder(@"
UPDATE  [dbo].[User]
SET     [UserName] = @UserName ,
        [Email] = @Email ,
        [Phone] = @Phone ,
        [Lng] = @Lng ,
        [Lat] = @Lat ,
        [Location] = @Location ,
        [Remark] = @Remark 
WHERE   Id = @Id
");
            using (IDbConnection conn = DapperContext.GetSqlConnection())
            {
                return conn.Execute(sql.ToString(), model) > 0;
            }
        }

        public List<User> SearchList(UserSearchCondition condition)
        {
            StringBuilder sql = new StringBuilder(@"
SELECT  *
FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY CreateTime DESC ) AS RowNum,*
          FROM      dbo.[User]
        ) tb
WHERE   RowNum BETWEEN STR(@PageIndex - 1) * @PageSize + 1
               AND     STR(@PageIndex * @PageSize)
");
            var list = new List<User>();
            using (IDbConnection conn = DapperContext.GetSqlConnection())
            {
                return conn.Query<User>(sql.ToString(), condition).ToList();
            }
        }
        public int SearchListCount(UserSearchCondition condition)
        {
            StringBuilder sql = new StringBuilder(@"
SELECT COUNT(0) Total FROM dbo.[User]
");
            using (IDbConnection conn = DapperContext.GetSqlConnection())
            {
                return conn.Query<User>(sql.ToString(), null).ToList().Count();
            }
        }
    }
}
