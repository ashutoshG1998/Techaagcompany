﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechAgCompany.Entities
{
    public class Country
    {
        public int Id { get; set; } 
        public string Name { get; set; } = "Default Country";

        public ICollection<State> states { get; set;} = new  HashSet<State>();
    }
}
