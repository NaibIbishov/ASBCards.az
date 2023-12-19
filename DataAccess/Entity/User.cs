﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class User
    {
        public int ID { get; set; }
        public string? Image { get; set; }
        public string? ImageURL { get; set; }

        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Salt { get; set; }
        public string? PasswordHash { get; set; }
        public string? Password { get; set; }
        public string? Company { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public DateTime Create { get; set; }
        public DateTime Update { get; set; }


        public IEnumerable<OrderCard> OrderCards { get; set; }


    }
}
