﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseDataLayer
{
    public class Product (int Id, int Quantity, string Name)
    {
        public int Id { get; set; } = Id;
        public int Quantity { get; set; } = Quantity;
        public string Name { get; set; } = Name;
    }
}
