﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccessControl.Infra.CrossCutting.Models.Email
{
    public class EmailRequest
    {
        public string ToEmail { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public List<IFormFile> Attachments { get; set; } = new List<IFormFile>();
    }
}