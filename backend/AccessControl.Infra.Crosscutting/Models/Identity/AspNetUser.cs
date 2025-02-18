﻿using AccessControl.Infra.CrossCutting.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace AccessControl.Infra.CrossCutting.Models.Identity
{
    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AspNetUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Name => _accessor.HttpContext?.User?.Identity?.Name ?? string.Empty;

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext?.User?.Claims ?? Enumerable.Empty<Claim>();
        }

        public Guid GetUserId()
        {
            return IsAuthenticated() && _accessor.HttpContext?.User != null ? Guid.Parse(_accessor.HttpContext.User.GetUserId()) : Guid.NewGuid();
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
        }
    }
}