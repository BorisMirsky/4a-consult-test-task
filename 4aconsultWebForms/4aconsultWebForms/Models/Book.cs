﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _4aconsultWebForms.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public int? Year { get; set; }
    }
}