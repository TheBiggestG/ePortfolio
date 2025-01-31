﻿using Microsoft.AspNetCore.Components;

namespace RandallDiscordBotUI_Revision.Model
{
    public class CheckForAuthorization : ComponentBase
    {
        [Inject]
        protected GlobalVariable GlobalState { get; set; }

        [Inject]
        protected NavigationManager Navigation { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (!GlobalState.IsSessionActive)
            {
                Navigation.NavigateTo("/login");
            }
            await base.OnInitializedAsync();
        }
    }
}
