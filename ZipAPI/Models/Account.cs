﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZipAPI.Models
{
    public class Account
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
