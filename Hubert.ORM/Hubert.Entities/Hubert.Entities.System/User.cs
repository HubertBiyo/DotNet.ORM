using System;

namespace Hubert.Entities.System
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public decimal Lng { get; set; }
        public decimal Lat { get; set; }
        public string Location { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }
        public string Remark { get; set; }

    }

    /// <summary>
    /// ORM 之 MySql数据库使用  映射数据库 UserMySql 表   
    /// add time  2019.02.12    
    /// author  HubertBiyo
    /// </summary>
    public class UserMySql
    {
        public string ID { get; set; }
        public string  Name { get; set; }
        public string  Phone { get; set; }
        public string Address { get; set; }
        public string  Email { get; set; }
    }
}
