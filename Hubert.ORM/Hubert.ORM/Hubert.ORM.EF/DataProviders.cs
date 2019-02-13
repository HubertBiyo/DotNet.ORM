using Hubert.Common.Method.Data;
using Hubert.Entities.System;
using Hubert.ORM.EF.IDataProviders;
using Hubert.ORM.EF.MySqlDataProviders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Hubert.ORM.EF
{
    public class DataProviders
    {
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
    /// <summary>
    /// ORM.EF 框架的使用
    /// </summary>
    public class MySqlDbContext : DbContext
    {
        public DbSet<UserMySql> UserMySql { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=173.82.240.222;Uid=root;Pwd=bo79715...;Database=Hubert_Test;Charset=utf8;Allow User Variables=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserMySql>().HasIndex(u => u.ID).IsUnique();
        }
    }
}
