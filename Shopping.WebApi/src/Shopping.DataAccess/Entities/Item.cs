﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.DataAccess.Entities
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
