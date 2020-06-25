﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CT.DDS.Training.DevExpressBlazor.AuthorizationHandler
{
    public class EmployeeApiAuthorizationMessageHandler : AuthorizationMessageHandler
    {
        public EmployeeApiAuthorizationMessageHandler(IAccessTokenProvider provider,
            NavigationManager navigationManager)
            : base(provider, navigationManager)
        {
            ConfigureHandler(
                authorizedUrls: new[] { "https://localhost:44329/" });
        }
    }
}
