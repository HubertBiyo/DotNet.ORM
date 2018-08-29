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
}
