using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CT.DDS.Training.DevExpressBlazor.Pages
{
    
    public class UserInfoBase: ComponentBase
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public IAccessTokenProvider AuthenticationService { get; set; }

       

        public ClaimsPrincipal User { get; set; } = new ClaimsPrincipal();

        public string Token { get; set; }

        protected override async Task OnInitializedAsync()
        {
            
            var tokenResult = await AuthenticationService.RequestAccessToken();
            if (tokenResult.TryGetToken(out var token))
            {
                Token = token.Value;
            }



        }

    }
}
