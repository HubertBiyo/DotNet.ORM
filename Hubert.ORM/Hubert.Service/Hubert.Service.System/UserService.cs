using Hubert.Common.Method.Data;
using Hubert.Common.Method.Log;
using Hubert.Entities.System;
using System;

namespace Hubert.Service.System
{
    public class UserService
    {

        public Result Add(User model)
        {
            try
            {
                if (model == null)
                    return new Result(-1, "参数错误");
                var isOk = Hubert.ORM.Dapper.DataProviders.UserDataProvider.Add(model);
                return isOk ? new Result(0, "创建成功") : new Result(-1, "创建失败");
            }
            catch (Exception ex)
            {
                Logger.Error("Add is Error", GetType(), ex);
                return new Result(-1, "服务器异常");
            }
        }
        public UserService() { }
        public static UserService Instance { get; } = new UserService();
    }
}
