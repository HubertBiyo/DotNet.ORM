﻿using Hubert.Common.Method.Data;
using Hubert.Common.Method.Log;
using Hubert.Entities.System;
using System;

namespace Hubert.Service.System
{
    public class UserService
    {
        #region ORM.Dapper
        public Result Add(User model)
        {
            try
            {
                if (model == null)
                    return new Result(-1, "参数错误");
                var isOk = Hubert.ORM.Dapper.DataProviders.UserDataProvider.Add(model);
                // var isOk = Hubert.DataProviders.UserDataProvider.Add(model);
                return isOk ? new Result(0, "创建成功") : new Result(-1, "创建失败");
            }
            catch (Exception ex)
            {
                Logger.Error("Add is Error", GetType(), ex);
                return new Result(-1, "服务器异常");
            }
        }

        public Result Update(User model)
        {
            try
            {
                if (model is null)
                    return new Result(-1, "参数错误");
                var isOk = Hubert.ORM.Dapper.DataProviders.UserDataProvider.Edit(model);
                return isOk ? new Result(0, "更新成功") : new Result(-1, "更新失败");
            }
            catch (Exception e)
            {
                Logger.Error("Update is Error", GetType(), e);
                return new Result(-1, "服务器异常");
            }
        }

        public Result Delete(Guid Id)
        {
            try
            {
                if (Guid.Empty == Id)
                    return new Result(-1, "参数错误");
                var isOk = Hubert.ORM.Dapper.DataProviders.UserDataProvider.Delete(Id);
                return isOk ? new Result(0, "删除成功") : new Result(-1, "删除失败");
            }
            catch (Exception e)
            {
                Logger.Error("Delete is Error", GetType(), e);
                return new Result(-1, "服务器异常");
            }
        }


        public PagingResult SearchList(UserSearchCondition condition)
        {
            try
            {
                if (condition is null)
                    return new PagingResult(-1, "服务器异常", null, 0);
                var list = Hubert.ORM.Dapper.DataProviders.UserDataProvider.SearchList(condition);
                var count = Hubert.ORM.Dapper.DataProviders.UserDataProvider.SearchListCount(condition);
                return new PagingResult(0, "查询成功", list, count);
            }
            catch (Exception e)
            {
                Logger.Error("SearchList is error", GetType(), e);
                return new PagingResult(-1, "服务器异常", null, 0);
            }
        }

        #endregion

        #region ORM.Chloe
        public Result AddByChloe(UserMySql model)
        {
            try
            {
                if (model == null)
                    return new Result(-1, "参数错误");
                var isOk = Hubert.ORM.Chloe.DataProviders.UserDataProvider.Add(model);
                return isOk ? new Result(0, "创建成功") : new Result(-1, "创建失败");
            }
            catch (Exception ex)
            {
                Logger.Error("AddMySql is Error", GetType(), ex);
                return new Result(-1, "服务器异常");
            }
        }

        public Result UpdateByChloe(UserMySql model)
        {
            try
            {
                if (model is null)
                    return new Result(-1, "参数错误");
                var isOk = Hubert.ORM.Chloe.DataProviders.UserDataProvider.Edit(model);
                return isOk ? new Result(0, "更新成功") : new Result(-1, "更新失败");
            }
            catch (Exception e)
            {
                Logger.Error("UpdateMySql is Error", GetType(), e);
                return new Result(-1, "服务器异常");
            }
        }

        public Result DeleteByChloe(string Id)
        {
            try
            {
                if (string.IsNullOrEmpty(Id))
                    return new Result(-1, "参数错误");
                var isOk = Hubert.ORM.Chloe.DataProviders.UserDataProvider.Delete(Id);
                return isOk ? new Result(0, "删除成功") : new Result(-1, "删除失败");
            }
            catch (Exception e)
            {
                Logger.Error("DeleteMySql is Error", GetType(), e);
                return new Result(-1, "服务器异常");
            }
        }

        public PagingResult SearchListByChloe(UserSearchCondition condition)
        {
            try
            {
                if (condition is null)
                    return new PagingResult(-1, "服务器异常", null, 0);
                var list = Hubert.ORM.Chloe.DataProviders.UserDataProvider.SearchList(condition);
                var count = Hubert.ORM.Chloe.DataProviders.UserDataProvider.SearchListCount(condition);
                return new PagingResult(0, "查询成功", list, count);
            }
            catch (Exception e)
            {
                Logger.Error("SearchList is error", GetType(), e);
                return new PagingResult(-1, "服务器异常", null, 0);
            }
        }
        #endregion


        #region ORM.EF
        public Result AddMySqlByEF(UserMySql model)
        {
            try
            {
                if (model == null)
                    return new Result(-1, "参数错误");
                var isOk = Hubert.ORM.EF.DataProviders.UserDataProvider.Add(model);
                return isOk ? new Result(0, "创建成功") : new Result(-1, "创建失败");
            }
            catch (Exception ex)
            {
                Logger.Error("AddMySql is Error", GetType(), ex);
                return new Result(-1, "服务器异常");
            }
        }

        public Result DeleteByEF(string Id)
        {
            try
            {
                if (string.IsNullOrEmpty(Id))
                    return new Result(-1, "参数错误");
                var isOk = Hubert.ORM.EF.DataProviders.UserDataProvider.Delete(Id);
                return isOk ? new Result(0, "删除成功") : new Result(-1, "删除失败");
            }
            catch (Exception ex)
            {
                Logger.Error("DeleteUser is error", GetType(), ex);
                return new Result(-1, "系统异常");
            }
        }
        public Result UpdateByEF(UserMySql model)
        {
            try
            {
                if (model == null || string.IsNullOrEmpty(model.ID))
                    return new Result(-1, "参数错误");
                var isOk = Hubert.ORM.EF.DataProviders.UserDataProvider.Edit(model);
                return isOk ? new Result(0, "更新成功") : new Result(-1, "更新失败");
            }
            catch (Exception ex)
            {
                Logger.Error("UpdateUser is error", GetType(), ex);
                return new Result(-1, "系统异常");
            }
        }
        public PagingResult SearchListByEF(UserSearchCondition condition)
        {
            try
            {
                if (condition == null)
                    return new PagingResult(-1, "参数错误", null, 0);
                var list = Hubert.ORM.EF.DataProviders.UserDataProvider.SearchList(condition);
                var count = Hubert.ORM.EF.DataProviders.UserDataProvider.SearchListCount(condition);
                return new PagingResult(0, "查询成功", list, count);
            }
            catch (Exception ex)
            {
                Logger.Error("SearchListByEF is error", GetType(), ex);
                return new PagingResult(-1,"系统异常",null,0);
            }
        }
        #endregion
        public UserService() { }
        public static UserService Instance { get; } = new UserService();
    }
}
