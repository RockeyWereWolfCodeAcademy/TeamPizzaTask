﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPizzaTask.Models
{
    public class User
    {
        static uint _id = 0;
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public User() // Rufat added parameters here
        {
            _id++;
            Id = _id;
        }
        
                    
    }
}
