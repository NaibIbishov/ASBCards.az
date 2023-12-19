﻿using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Role
    {

        public int ID { get; set; }
        public string? Name { get; set; }
        public DateTime Create { get; set; }
        public DateTime Update { get; set; }
        public List<User> Users { get; set; } = new List<User>();

    }
}
