﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.DTO
{
    public class DALTag:IDALEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
