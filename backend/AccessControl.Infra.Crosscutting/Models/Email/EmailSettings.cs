using System;
using System.Collections.Generic;
using System.Text;

namespace AccessControl.Infra.CrossCutting.Models.Email
{
    public class EmailSettings
    {
        public string Mail { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
    }
}
