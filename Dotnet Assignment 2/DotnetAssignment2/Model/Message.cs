﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetAssignment2.Model
{
    public class Message
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserMessage { get; set; }
        public string Comment { get; set; }
        public int Like { get; set; }
    }
}
