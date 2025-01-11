﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AccessControl.Infra.CrossCutting.Models.Email
{
    public class EmailSettings
    {
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
