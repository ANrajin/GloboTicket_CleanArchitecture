﻿using System.Security.Claims;
using GloboTicket.TicketManagement.Application.Contracts;

namespace GloboTicket.TicketManagement.Api.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public LoggedInUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string UserId => _contextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)!;
    }
}
